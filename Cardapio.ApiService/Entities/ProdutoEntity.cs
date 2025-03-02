using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cardapio.ApiService.Entities
{
    public class ProdutoEntity
    {
        [Key]
        public int Codigo { get; set; }
        [StringLength(50)]
        public string Nome { get; set; } = null!;
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }
        [StringLength(500)]
        public string? Descricao { get; set; }
        public string? Img { get; set; }
    }
}
