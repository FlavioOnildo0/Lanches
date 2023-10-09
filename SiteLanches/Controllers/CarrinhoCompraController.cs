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
        private readonly CarinhoCompra _carinhoCompra;

        //Construtor
        public CarrinhoCompraController(ILanchesRepository lanchesRepository, CarinhoCompra carinhoCompra)
        {
            _lanchesRepository = lanchesRepository;
            _carinhoCompra = carinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carinhoCompra.GetCarrinhoCompraItems();
            _carinhoCompra.CarrinhoCompraItems= itens;
            var carrinhoCompraVm = new CarrinhoCompraViewModel
            {
                CarinhoCompra = _carinhoCompra,
                CarrinhoCompraTotal = _carinhoCompra.GetCarrinhoCompraTotal()

            };
            return View(carrinhoCompraVm);//retornando um carrinhoDeCompra como parametro
        }

        public IActionResult AdicionarIntemCarrinhoCompra (int lancheId)
        {
            var lancheSelecionado = _lanchesRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);

            if (lancheSelecionado != null)
            {
                _carinhoCompra.AdicionarAoCarinho(lancheSelecionado);
            }
            return RedirectToAction("Index");

        }


        public IActionResult RemoverItemDICarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lanchesRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);

            if (lancheSelecionado != null)
            {
                _carinhoCompra.RemoveDoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");

        }

    }
}
