using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lottery.UI.Models;
using Lottery.Domain.Application;

namespace Lottery.UI.Controllers
{
    public class HomeController : Controller
    {

        public ISorteioMegaSena AppService { get; private set; }

        public HomeController(ISorteioMegaSena appService)
        {
            AppService = appService;
        }


        public IActionResult Index()
        {
            return View(new MegaSenaViewModel());
        }

        [HttpPost]
        public IActionResult AdicionaBilhete(MegaSenaViewModel viewModel) {

            if(!ModelState.IsValid)
                return View("Index", viewModel);

            //viewModel.Bilhetes.Add(viewModel.Numeros);


            return View("Index", viewModel);
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
