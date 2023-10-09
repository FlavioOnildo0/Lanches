using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteLanches.Models
{
 
    public class CarrinhoCompraItem
    {
        
        public int CarrinhoCompraItemId { get; set; }
        public Lanches Lanches { get; set; }
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}
