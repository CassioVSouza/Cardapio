using Cardapio.ApiService.Entities;

namespace Cardapio.ApiService.Services.Interface
{
    public interface IPedidoService
    {
        Task<PedidoEntity> AdicionarPedidoAsync(PedidoEntity pedido);
        Task<PedidoEntity> AtualizarPedidoAsync(PedidoEntity pedido);
        Task<PedidoEntity> RemoverPedidoAsync(PedidoEntity pedido);
        Task<List<PedidoEntity>> SelecionarTodosPedidosAsync(PedidoEntity pedido);
        Task<List<PedidoEntity>> RetornarPedidosPeloStatus(string status);
    }
}
