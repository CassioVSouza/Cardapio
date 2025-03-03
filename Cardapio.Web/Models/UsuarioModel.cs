using System.ComponentModel.DataAnnotations;

namespace Cardapio.Web.Models
{
    public class UsuarioModel
    {
        public int Codigo { get; set; }
        [StringLength(50)]
        public string Nome { get; set; } = null!;
        [StringLength(50)]
        public string Senha { get; set; } = null!;
        public bool eCozinha { get; set; }
    }
}
