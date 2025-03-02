using System.ComponentModel.DataAnnotations;

namespace Cardapio.ApiService.Entities
{
    public class MesaEntity
    {
        [Key]
        public int Codigo { get; set; }
        [StringLength(50)]
        public string Nome { get; set; } = null!;
    }
}
