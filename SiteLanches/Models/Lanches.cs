using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteLanches.Models
{
    [Table("Lanches")]
    public class Lanches
    {
        [Key]
        public int LancheId { get; set; }

        [Required(ErrorMessage ="O nome do lanche deve ser informado")]
        [Display(Name ="Nome") ]
        [StringLength(80, MinimumLength =10, ErrorMessage ="0 {0} deve ter no mínimo {1} e no maxímo {2}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informado")]
        [Display(Name = "Descrição Curta")]
        [MinLength(50,  ErrorMessage = "Descrição detalhada dever ter no mínimo {1} caracteres")]
        [MaxLength(200,ErrorMessage ="Descrição detalhada dever ter no mínimo {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informado")]
        [Display(Name = "Descrição detalhada")]
        [MinLength(50, ErrorMessage = "Descrição detalhada dever ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada dever ter no mínimo {1} caracteres")]
        public string DescricaoDetalhada { get; set; }
        
        
        [Required(ErrorMessage ="informe o Preço")]
        [Column(TypeName ="Decimal(10,2)")]
        [Range(1,999.99, ErrorMessage ="O preço deve está entre 1 e 999.99")]// preço minimo e maximo
        public decimal Preco { get; set; }

        [Display(Name ="Caminho imagem normal")]
        [StringLength(200, ErrorMessage ="o {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }


        [Display(Name = "Caminho imagem miniatura")]
        [StringLength(200, ErrorMessage = "o {0} deve ter no máximo {1} caracteres")]

        public string ImagemThumbnailUrl { get; set; }

        [Required(ErrorMessage ="Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Required(ErrorMessage = "Estoque")]
        public bool EmEstoque { get; set; }

       
        public int CategoriaId { get; set; } //Chave estrangeira
        public virtual Categoria Categoria { get; set; }



    }
}
