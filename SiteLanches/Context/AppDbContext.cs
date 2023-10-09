using Microsoft.EntityFrameworkCore;
using SiteLanches.Models;

namespace SiteLanches.Context
{
    public class AppDbContext:DbContext
    {
        //metodo construtor
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {
            //config necessaria do dbContext

        }

       
       public DbSet<Categoria> Categorias{ get; set; }//seja mapeada quando for criado o banco de dados e as tabelas
       public DbSet<Lanches> Lanches { get; set; }        //crie uma  tabela chamada Lanche
        public DbSet<CarrinhoCompraItem>  CarrinhoCompraItens { get; set; }



    }
}
