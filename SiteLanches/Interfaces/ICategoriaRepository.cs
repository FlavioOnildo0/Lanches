using SiteLanches.Models;
using System.Collections.Generic;

namespace SiteLanches.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categoria { get; } //retorna uma lista de Categoria
    }
}
