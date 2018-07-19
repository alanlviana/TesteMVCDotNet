using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TesteMVC.Models;

namespace TesteMVC.Repositories.EF{
    public class AnalistaRepository: IAnalistaRepository{
        public ApplicationContext context { get; }
        public DbSet<Analista> Set { get; }

        public AnalistaRepository(ApplicationContext context){
            this.context = context;
            this.Set = context.Set<Analista>();
        }

        public IList<Analista> ListaTodos()
        {
            return Set.ToList();
        }

        public void Salvar(Analista analista)
        {
            if (analista.Id != 0){
                Set.Update(analista);
            }else{
                Set.Add(analista);
            }

            context.SaveChanges();
        }

        public Analista BuscarPorCodigo(int id)
        {
            return Set.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Excluir(int id)
        {
            var analista = BuscarPorCodigo(id);
            Set.Remove(analista);
            context.SaveChanges();
        }
    }
}