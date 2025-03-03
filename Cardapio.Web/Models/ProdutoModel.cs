using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cardapio.Web.Models
{
    public class ProdutoModel
    {
        public int codigo { get; set; }
        [StringLength(50)]
        [Required]
        public string nome { get; set; } = null!;
        [Required]
        public decimal preco { get; set; }
        [StringLength(500)]
        public string? descricao { get; set; }
        public string? img { get; set; }
    }
}
