using Microsoft.EntityFrameworkCore;
using SiteLanches.Context;
using SiteLanches.Interfaces;
using SiteLanches.Models;

namespace SiteLanches.Repositories
{
    public class LancheRepository : ILanchesRepository
    {
        private readonly AppDbContext _context;
        //injeção da instancia do Contexto no Construtor

        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Lanches> Lanches => _context.Lanches.Include(c => c.Categoria);
        //obtendo todos os lanches incluindo (include) suas categorias
        
        public IEnumerable<Lanches> LanchesPreferidos => _context.Lanches.
            Where(p => p.IsLanchePreferido)
            .Include(c => c.Categoria);

   



        //pegue todos os lanches preferido onde a propriedade IsLanchePreferido seja igual a true incluindo sua categoria

        public Lanches GetLanchesById(int Lancheid)
        {
            
            return _context.Lanches.FirstOrDefault(i => i.LancheId == Lancheid);
            //FirstOrDefault retorne  o 1 elemento de um sequência ou um valor padrão caso não seja encontrado nenhum elemento 

        }
    }
}
