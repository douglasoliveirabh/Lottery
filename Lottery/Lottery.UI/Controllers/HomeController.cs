using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lottery.UI.Models;
using Lottery.Domain.Application;
using Lottery.Domain.Entities;
using FluentValidation.Results;
using Lottery.Application;

namespace Lottery.UI.Controllers
{
    public class HomeController : Controller
    {
        //Limitando a quantidade de bilhetes aleatorios gerados
        private const int QUANTIDADE_BILHETES_ALEATORIOS = 10;

        public ISorteioMegaSena SorteioMegaSena { get; private set; }

        public HomeController(ISorteioMegaSena sorteioMegaSena)
        {
            SorteioMegaSena = sorteioMegaSena;
        }

        public IActionResult Index()
        {
            ((SorteioMegaSena)SorteioMegaSena).Clear();
            return View(new MegaSenaViewModel());
        }

        [HttpPost]
        public IActionResult AdicionaBilhete(MegaSenaViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var numerosDoBilhete = viewModel.Numeros.Split(",").Select(x => int.Parse(x)).ToArray();
                var result = SorteioMegaSena.RegistrarNovoBilhete(numerosDoBilhete);

                if (!result.IsValid)
                {
                    AddErrorsToModelState(result);
                }
                else
                {
                    viewModel = MapAppServiceToViewModel();
                    viewModel.Numeros = string.Empty;
                }

                return View("Index", viewModel);
            }            

            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult GeraAleatorios()
        {
            var viewModel = new MegaSenaViewModel();
            SorteioMegaSena.GeraBilhetesAleatorios(QUANTIDADE_BILHETES_ALEATORIOS);

            viewModel = MapAppServiceToViewModel();

            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult Sortear()
        {
            var viewModel = new MegaSenaViewModel();

            SorteioMegaSena.Sortear();
            viewModel = MapAppServiceToViewModelWithWinners();

            return View("Index", viewModel);
        }


        private MegaSenaViewModel MapAppServiceToViewModel()
        {
            var viewModel = new MegaSenaViewModel();

            ((SorteioMegaSena)SorteioMegaSena).Bilhetes.ToList().ForEach(x =>
            {
                var bilheteViewModel = new MegaSenaBilheteViewModel(x.Id, x.Numeros);
                viewModel.Bilhetes.Add(bilheteViewModel);
            });

            return viewModel;
        }

        private MegaSenaViewModel MapAppServiceToViewModelWithWinners()
        {
            var viewModel = new MegaSenaViewModel();

            viewModel = MapAppServiceToViewModel();

            ((SorteioMegaSena)SorteioMegaSena).ObtemBilhetesSemAcerto().ToList().ForEach(x =>
            {
                var bilheteViewModel = new MegaSenaBilheteViewModel(x.Id, x.Numeros);
                viewModel.BilhetesSemAcerto.Add(bilheteViewModel);
            });

            ((SorteioMegaSena)SorteioMegaSena).ObtemBilhetesComUmAcerto().ToList().ForEach(x =>
            {
                var bilheteViewModel = new MegaSenaBilheteViewModel(x.Id, x.Numeros);
                viewModel.BilhetesComUmAcerto.Add(bilheteViewModel);
            });

            ((SorteioMegaSena)SorteioMegaSena).ObtemBilhetesComDoisAcertos().ToList().ForEach(x =>
            {
                var bilheteViewModel = new MegaSenaBilheteViewModel(x.Id, x.Numeros);
                viewModel.BilhetesComDoisAcertos.Add(bilheteViewModel);
            });

            ((SorteioMegaSena)SorteioMegaSena).ObtemBilhetesComTresAcertos().ToList().ForEach(x =>
            {
                var bilheteViewModel = new MegaSenaBilheteViewModel(x.Id, x.Numeros);
                viewModel.BilhetesComTresAcertos.Add(bilheteViewModel);
            });

            ((SorteioMegaSena)SorteioMegaSena).ObtemVencedoresQuadra().ToList().ForEach(x =>
            {
                var bilheteViewModel = new MegaSenaBilheteViewModel(x.Id, x.Numeros);
                viewModel.BilhetesVencedoresQuadra.Add(bilheteViewModel);
            });

            ((SorteioMegaSena)SorteioMegaSena).ObtemVencedoresQuina().ToList().ForEach(x =>
            {
                var bilheteViewModel = new MegaSenaBilheteViewModel(x.Id, x.Numeros);
                viewModel.BilhetesVencedoresQuina.Add(bilheteViewModel);
            });

            ((SorteioMegaSena)SorteioMegaSena).ObtemVencedoresSena().ToList().ForEach(x =>
            {
                var bilheteViewModel = new MegaSenaBilheteViewModel(x.Id, x.Numeros);
                viewModel.BilhetesVencedoresSena.Add(bilheteViewModel);
            });

            viewModel.NumerosSorteados = string.Join(",", ((SorteioMegaSena)SorteioMegaSena).NumerosSorteados);

            return viewModel;
        }

        private void AddErrorsToModelState(ValidationResult result)
        {
            //ModelState.AddModelError("", )
            result.Errors.ToList().ForEach(e => ModelState.AddModelError("", e.ErrorMessage));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
