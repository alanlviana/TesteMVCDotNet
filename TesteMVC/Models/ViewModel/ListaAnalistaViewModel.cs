using System;
using System.Collections.Generic;

namespace TesteMVC.Models.ViewModel{
    public class ListaAnalistaViewModel{
        public IList<AnalistaViewModel> AnalistasViewModel { get; }
        public ListaAnalistaViewModel(){
            AnalistasViewModel = new List<AnalistaViewModel>();
        }
        public ListaAnalistaViewModel(IList<Analista> analistas){
            if (analistas == null){
                throw new ArgumentException("Lista de analistas não pode ser nula.",nameof(analistas));
            }
            
            AnalistasViewModel = AnalistaViewModel.CriarDaLista(analistas);
        }

    }
}