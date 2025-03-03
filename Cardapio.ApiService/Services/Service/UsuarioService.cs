using Cardapio.ApiService.Entities;
using Cardapio.ApiService.Exceptions;
using Cardapio.ApiService.Repositories.Interface;
using Cardapio.ApiService.Services.Interface;
using Grpc.Core;

namespace Cardapio.ApiService.Services.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericoRepository<UsuarioEntity> _genericoRepositorio;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IGenericoRepository<UsuarioEntity> usuarioRepository, IUsuarioRepository repoUsuario)
        {
            _genericoRepositorio = usuarioRepository;
            _usuarioRepository = repoUsuario;
        }

        public async Task<UsuarioEntity> AdicionarUsuario(UsuarioEntity usuario)
        {
            try
            {
                var usuarioExistente = await _usuarioRepository.SelecionarUsuarioPeloNome(usuario.Nome);

                if(usuarioExistente == null)
                    return await _genericoRepositorio.AdicionarAsync(usuario);
               
                throw new ErroUsuarioJaExiste("Usuário já existe");
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<bool> ValidarUsuarioPeloNomeESenha(string nome, string senha)
        {
            try
            {
                var usuario = await _usuarioRepository.SelecionarUsuarioPeloNome(nome);
                

                if(usuario == null)
                    return false;

                if (usuario.Nome.Equals(nome) && usuario.Senha.Equals(senha))
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<UsuarioEntity> AtualizarUsuario(UsuarioEntity usuario)
        {
            try
            {
                return await _genericoRepositorio.AtualizarAsync(usuario);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<UsuarioEntity> RemoverUsuario(UsuarioEntity usuario)
        {
            try
            {
                return await _genericoRepositorio.RemoverAsync(usuario);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<List<UsuarioEntity>> SelecionarTodosUsuarios(UsuarioEntity usuario)
        {
            try
            {
                return await _genericoRepositorio.SelecionarTodosAsync(usuario);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }
    }
}
