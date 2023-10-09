using Microsoft.EntityFrameworkCore;
using SiteLanches.Context;
using SiteLanches.Interfaces;
using SiteLanches.Models;
using SiteLanches.Repositories;

namespace SiteLanches;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.
        UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddTransient<ILanchesRepository, LancheRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped(sp => CarrinhoCompra.GetCarinho(sp)); 
        //AddTransient<> - criado toda vez que o serviço é solicitado
        //AddScoped<> - criado a cada request- a cada requisição temos uma nova instancia do servico
        //AddSingleton<> Criada se ainda não tiver registrada como uma instancia - todas as requisição
        //obtem o mesmo objeto

        services.AddControllersWithViews();
        services.AddMemoryCache();//habilitando o caches
        services.AddSession();// adicionando o serviço session
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //Tempo de vida - addsingleton -vai valer por todo tempo de vida da aplicação 
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSession();//ativando o session
        

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}