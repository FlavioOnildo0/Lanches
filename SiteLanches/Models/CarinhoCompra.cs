using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SiteLanches.Context;
using System.Security.Cryptography.X509Certificates;

namespace SiteLanches.Models
{
    public class CarinhoCompra
    {
        private readonly AppDbContext _context;

        //injetar o contexto no construtor
        public CarinhoCompra(AppDbContext Context)
        {
            _context = Context;
        }
        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarinhoCompra GetCarinho(IServiceProvider services)
        {

            // services.GetRequiredService<IHttpContextAccessor>() ? // se a minha requisição não

            //for null ele invoca uma session
            //definindo uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtendo um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //getstting obtem o dia  se não tiver um id?? ou gerar o id do carinho atraves do guid.newGuid().Tostring(); 
            string carrinhoId = session.GetString("CarinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessão 
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carinho com o contexto e o Id atribuido ou obtido
            return new CarinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId

            };
        
        }
        public void AdicionarAoCarinho(Lanches lanches)
        {
            //o carrinhocompraitem vai lá no meu / verificar se context  lancheId e o carinhoComprasId é igual carinhoComprasId
            //criando variavel para verificar ser lancheid  é igual ao lancheId e o carinhoComprasId é igual carinhoComprasId
            //ser for ele retorna a varivel CarrinhoComprasItem com todos os item 
            //SingleOrDefault retorna um unico elemento que vai ser retornado caso atenda as 2 condições informadas

            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
             s => s.Lanches.LancheId == lanches.LancheId && s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanches = lanches,
                    Quantidade = 1

                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }
        //metodo de remover
        public int RemoveDoCarrinho(Lanches lanches)
        {
            //tenta obter lanche pelo id atraves de condição 
            //retorna um unico elemento que satisfaça essa condição - SingleOrDefault
            var carrinhoCompraitem = _context.CarrinhoCompraItens.SingleOrDefault
               (a => a.Lanches.LancheId == lanches.LancheId && a.CarrinhoCompraId == CarrinhoCompraId);

            //Criação de um variavel com 0 

            var quantidadeLocal = 0;
            if (carrinhoCompraitem != null)  //se for diferente de null 
            {
                if (carrinhoCompraitem.Quantidade > 1) //se o carrinhocompraid.quantidade for maior do que 1
                {
                    carrinhoCompraitem.Quantidade--;
                    quantidadeLocal = carrinhoCompraitem.Quantidade; // atribuindo o valor a quantidade
                }
                else
                {
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraitem);
                }
            }
            _context.SaveChanges(); // persistindo a informação no banco de dados
            return quantidadeLocal;


            //para remover sem o void usa o mesmo metodo de adicionar alterando para .remove e quantidade --;

        }

        //Metodo que Vai retornar uma lista de compra do item do carrinho

        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            // ?? retorna um instancia se ela existir, se não ela vai cria todos os items do carrinho e vai retornar include- incluindo  lanche
            return CarrinhoCompraItems ?? (CarrinhoCompraItems = _context.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId).Include(s => s.Lanches).ToList());
        }

        //Metodo para limpar o carrinho 

        public void LimparCarrinho()
        {
            //obtendo os intens do carrinho com base no ID do Carrinho 
            var carrinhoItens = _context.CarrinhoCompraItens
                .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);//RemoverRanger- remove todos os intens do carrinho 
            _context.SaveChanges();
        }
        //METODO QUE RETORNA A SOMA TOTAL DO CARRIHO
        public decimal GetCarrinhoCompraTotal()
        {
            //criando uma variavel para ir no constexto buscar por id especifico selecionando o preeço*quantidade da tabela de lanches
            var total = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId).
                Select(c => c.Lanches.Preco * c.Quantidade).Sum();
            return total;
        }
    }
}

