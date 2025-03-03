using Cardapio.ApiService.Entities;

namespace Cardapio.ApiService.Repositories.Interface
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity?> SelecionarUsuarioPeloNome(string nome);
    }
}
