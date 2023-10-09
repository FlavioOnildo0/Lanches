using Microsoft.AspNetCore.Mvc;
using SiteLanches.Interfaces;
using SiteLanches.Models;
using SiteLanches.ViewModels;

namespace SiteLanches.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        //para acessar o carrinho de compra  e lanche preciso injetar um instancia de carrinhodeLanche e Lanche 
        // private readonly - varivel do tipo leitura
        private readonly ILanchesRepository _lanchesRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        //Construtor
        public CarrinhoCompraController(ILanchesRepository lanchesRepository, CarrinhoCompra carinhoCompra)
        {
            _lanchesRepository = lanchesRepository;
            _carrinhoCompra = carinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItems();
            _carrinhoCompra.CarrinhoCompraItems= itens;
            var carrinhoCompraVm = new CarrinhoCompraViewModel
            {
                CarinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()

            };
            return View(carrinhoCompraVm);//retornando um carrinhoDeCompra como parametro
        }

        public IActionResult AdicionarIntemCarrinhoCompra (int lancheId)
        {
            var lancheSelecionado = _lanchesRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);

            if (lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarinho(lancheSelecionado);
            }
            return RedirectToAction("Index");

        }


        public IActionResult RemoverItemDICarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lanchesRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);

            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoveDoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");

        }

    }
}
