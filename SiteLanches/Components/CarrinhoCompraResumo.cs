using Microsoft.AspNetCore.Mvc;
using SiteLanches.Models;
using SiteLanches.ViewModels;

namespace SiteLanches.Components
{
    public class CarrinhoCompraResumo:ViewComponent
    {
        //injenção de dependência
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItems();

           /*/ var itens = new List<CarrinhoCompraItem>()- criando 3 items de carrinho manualmente
            {
                new CarrinhoCompraItem(),
                 new CarrinhoCompraItem(),
                 new CarrinhoCompraItem()
            };
            */
            _carrinhoCompra.CarrinhoCompraItems = itens;
            var carrinhoCompraVm = new CarrinhoCompraViewModel
            {
                CarinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()

            };
            return View(carrinhoCompraVm);//retornando um carrinhoDeCompra como parametro

        }

    }
}
