using System.Collections.Generic;
using TesteMVC.Models;

namespace TesteMVC.Repositories{
    public interface IAnalistaRepository{
        IList<Analista> ListaTodos();
        void Salvar(Analista analista);
        Analista BuscarPorCodigo(int id);
        void Excluir(int id);
    }
}