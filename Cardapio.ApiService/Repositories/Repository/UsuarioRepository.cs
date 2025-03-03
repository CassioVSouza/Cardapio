using Cardapio.ApiService.Data;
using Cardapio.ApiService.Entities;
using Cardapio.ApiService.Repositories.Interface;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Cardapio.ApiService.Repositories.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppContextData _context;
        private readonly ILogger<UsuarioRepository> _logger;

        public UsuarioRepository(AppContextData context, ILogger<UsuarioRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<UsuarioEntity?> SelecionarUsuarioPeloNome(string nome)
        {
            try
            {
                return await _context.Usuario.FirstOrDefaultAsync(x => x.Nome == nome);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }
    }
}
