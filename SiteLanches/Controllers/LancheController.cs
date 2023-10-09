using Microsoft.AspNetCore.Mvc;
using SiteLanches.Interfaces;
using SiteLanches.ViewModels;

namespace SiteLanches.Controllers
{
    public class LancheController : Controller
    {
        //criando uma variavel 
        private readonly ILanchesRepository _lanchesRepository;

        //Construtor
        //instancia do repositorio sendo injetada
        public LancheController(ILanchesRepository lanchesRepository)
        {
            _lanchesRepository = lanchesRepository;
        }

        public IActionResult Listar()
        {
            // retornando uma Ienumerable(lista) Lanches e colocando variavel lanches
            //retornando em uma view Lista a lista de Lanche
            // var lanches = _lanchesRepository.Lanches; //armazena uma lista de lanches
            //return View(lanches);                   
            var lancheslistViewModel = new LancheListViewModel();                                     // 
            lancheslistViewModel.Lanches = _lanchesRepository.Lanches;// a variavel
            lancheslistViewModel.CategoriaAtual = "Categoria Atual";                                                        // lancheslistViewModel vai recber o que tem em _lancheRepository

            return View(lancheslistViewModel);
        }
    }
}
