using Cardapio.ApiService.Entities;

namespace Cardapio.ApiService.Repositories.Interface
{
    public interface IPedidoRepository
    {
        Task<List<PedidoEntity>> RetornarPedidosPeloStatus(string status);
    }
}
