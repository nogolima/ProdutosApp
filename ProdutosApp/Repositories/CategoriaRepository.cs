using ProdutosApp.Contexts;
using ProdutosApp.Entities;

namespace ProdutosApp.Repositories
{
    public class CategoriaRepository
    {
        public List<Categoria> Consultar()
        {
            using(var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Categoria>()
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
        }
    }
}
