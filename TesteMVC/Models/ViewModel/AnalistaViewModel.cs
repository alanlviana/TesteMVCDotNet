using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TesteMVC.Models.ViewModel{
    public class AnalistaViewModel{
        public AnalistaViewModel(){

        }

        public static implicit operator AnalistaViewModel(Analista analista){
            return new AnalistaViewModel(){
                Id = analista.Id,
                Nome = analista.Nome
            };
        }

        public static implicit operator Analista(AnalistaViewModel model){
            return new Analista(){
                Id = model.Id,
                Nome = model.Nome
            };
        }
        public static IList<AnalistaViewModel> CriarDaLista(IList<Analista> analistas){
            if (analistas == null){
                throw new ArgumentException("Lista de analistas para viewmodel não pode ser nula.",nameof(analistas));
            }
            var listaViewModel = new List<AnalistaViewModel>();
            foreach(Analista analista in analistas){
                AnalistaViewModel analistaViewModel = analista;
                listaViewModel.Add(analistaViewModel);
            }
            return listaViewModel;

        }
        public int Id{get;set;}
        [Required(ErrorMessage="O campo Nome deve ser preenchido.")]
        [MinLength(5,ErrorMessage="O campo Nome deve ter no mínimo 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "O campo Nome deve ter no mínimo 5 caracteres.")]
        public string Nome{get;set;}
    }
}