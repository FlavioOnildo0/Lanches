using Microsoft.AspNetCore.Mvc;
using SiteLanches.Context;
using SiteLanches.Interfaces;
using SiteLanches.Models;
using SiteLanches.Repositories;
using SiteLanches.ViewModels;
using System.Diagnostics;

namespace SiteLanches.Controllers
{
    public class HomeController : Controller
    {
        //injeção do repositorio de lanche
        private readonly ILanchesRepository _lanchesRepository;

        public HomeController(ILanchesRepository lanchesRepository)
        {
            _lanchesRepository = lanchesRepository;
        }

        public ILanchesRepository Get_lanchesRepository()
        {
            return _lanchesRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lanchesRepository.LanchesPreferidos

            };
            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}