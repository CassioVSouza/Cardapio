using System.ComponentModel.DataAnnotations;

namespace Cardapio.ApiService.Entities
{
    public class UsuarioEntity
    {
        [Key]
        public int Codigo { get; set; }
        [StringLength(50)]
        public string Nome { get; set; } = null!;
        [StringLength(50)]
        public string Senha { get; set; } = null!;
        public bool ECozinha { get; set; }
    }
}
