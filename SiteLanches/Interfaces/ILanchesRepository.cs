using SiteLanches.Models;

namespace SiteLanches.Interfaces
{
    public interface ILanchesRepository
    {
        IEnumerable<Lanches> Lanches { get; } //retorna uma lista de lanches
        IEnumerable<Lanches> LanchesPreferidos { get; }
        Lanches GetLanchesById(int id);//retorna um objeto lanche pelo seu identificador LancheId

        //acessar lanche especifico pelo seu id
    }
}
