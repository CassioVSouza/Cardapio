using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cardapio.Web.Models
{
    public class PedidoEntity
    {
        [Key]
        public int Codigo { get; set; }
        [ForeignKey("Mesa")]
        public int MesaCodigo { get; set; }
        [ForeignKey("Produto")]
        public int CodigoProduto { get; set; }
        public DateTime DataHoraCriado { get; set; }
        [StringLength(20)]
        public string Status { get; set; } = null!;
        public ProdutoModel Produto { get; set; } = null!;
        public MesaEntity Mesa { get; set; } = null!;
    }
}
