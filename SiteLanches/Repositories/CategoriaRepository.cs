using SiteLanches.Context;
using SiteLanches.Interfaces;
using SiteLanches.Models;

namespace SiteLanches.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context; //criação de um variavel que recebe o apppDbContext

        //metodo construtor 
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categoria => _context.Categorias;
   
    }
}
