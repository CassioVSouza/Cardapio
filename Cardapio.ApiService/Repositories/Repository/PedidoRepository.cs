using Cardapio.ApiService.Data;
using Cardapio.ApiService.Entities;
using Cardapio.ApiService.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cardapio.ApiService.Repositories.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppContextData _context;
        private readonly ILogger<PedidoRepository> _logger;
        public PedidoRepository(AppContextData context, ILogger<PedidoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<PedidoEntity>> RetornarPedidosPeloStatus(string status)
        {
            try
            {
                return await _context.Pedido.Where(p => p.Status == status).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao retornar pedidos pelo status.");
                throw;
            }
        }
    }
}
