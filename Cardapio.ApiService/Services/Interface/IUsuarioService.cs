using Cardapio.ApiService.Entities;

namespace Cardapio.ApiService.Services.Interface
{
    public interface IUsuarioService
    {
        Task<UsuarioEntity> AdicionarUsuario(UsuarioEntity usuario);
        Task<UsuarioEntity> AtualizarUsuario(UsuarioEntity usuario);
        Task<UsuarioEntity> RemoverUsuario(UsuarioEntity usuario);
        Task<List<UsuarioEntity>> SelecionarTodosUsuarios(UsuarioEntity usuario);
        Task<bool> ValidarUsuarioPeloNomeESenha(string nome, string senha);
    }
}
