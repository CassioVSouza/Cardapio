using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cardapio.ApiService.Entities
{
    public class PedidoEntity
    {
        [ForeignKey("Mesa")]
        public int MesaCodigo { get; set; }
        [ForeignKey("Produto")]
        public int CodigoProduto { get; set; }
        public ProdutoEntity Produto { get; set; } = null!;
        public MesaEntity Mesa { get; set; } = null!;
    }
}
