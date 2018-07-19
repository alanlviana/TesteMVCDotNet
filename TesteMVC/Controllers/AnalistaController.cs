using Microsoft.AspNetCore.Mvc;
using TesteMVC.Models;
using TesteMVC.Models.ViewModel;
using TesteMVC.Repositories;

namespace TesteMVC.Controllers{
    public class AnalistaController : Controller{
        public IAnalistaRepository AnalistaRepository { get; }

        public AnalistaController(IAnalistaRepository analistaRepository){
            AnalistaRepository = analistaRepository;
        }

        private ActionResult ObterAnalista(int id){
            Analista analista = AnalistaRepository.BuscarPorCodigo(id);
            if (analista == null){
                return new StatusCodeResult(404);
            }
            AnalistaViewModel analistaViewModel = analista;
            return View(analistaViewModel);
        }

        [HttpGet]
        public ActionResult Formulario(int id){
            ViewData["Message"] = "Cadastro de análista.";
            if (id > 0){
                return ObterAnalista(id);
            }
            
            return View();
        }
        
        [HttpGet]
        public ActionResult ConfirmarExcluir(int id){
            ViewData["Message"] = "Exclusão de análista.";
            return ObterAnalista(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id){
            AnalistaRepository.Excluir(id);
            return RedirectToAction("lista");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Formulario(AnalistaViewModel analistaViewModel){
            if (ModelState.IsValid){
                Analista analista = analistaViewModel;
                AnalistaRepository.Salvar(analista);
                return RedirectToAction("lista");
            }

            return View(analistaViewModel);
        }
        public ActionResult Lista(){
            ViewData["Message"] = "Análistas ativos.";

            var analistas = AnalistaRepository.ListaTodos();
            var listaViewModel = new ListaAnalistaViewModel(analistas);
            return View(listaViewModel);
        }
    }
}