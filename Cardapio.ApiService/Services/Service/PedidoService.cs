using Cardapio.ApiService.Entities;
using Cardapio.ApiService.Repositories.Interface;
using Cardapio.ApiService.Services.Interface;
using Grpc.Core;

namespace Cardapio.ApiService.Services.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly IGenericoRepository<PedidoEntity> _genericoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IGenericoRepository<PedidoEntity> genericoRepository, IPedidoRepository pedido)
        {
            _genericoRepository = genericoRepository;
            _pedidoRepository = pedido;
        }

        public async Task<PedidoEntity> AdicionarPedidoAsync(PedidoEntity pedido)
        {
            try
            {
                pedido.DataHoraCriado = DateTime.Now;
                return await _genericoRepository.AdicionarAsync(pedido);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<PedidoEntity> AtualizarPedidoAsync(PedidoEntity pedido)
        {
            try
            {
                return await _genericoRepository.AtualizarAsync(pedido);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<PedidoEntity> RemoverPedidoAsync(PedidoEntity pedido)
        {
            try
            {
                return await _genericoRepository.RemoverAsync(pedido);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<List<PedidoEntity>> SelecionarTodosPedidosAsync(PedidoEntity pedido)
        {
            try
            {
                return await _genericoRepository.SelecionarTodosAsync(pedido);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<List<PedidoEntity>> RetornarPedidosPeloStatus(string status)
        {
            try
            {
                return await _pedidoRepository.RetornarPedidosPeloStatus(status);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }
    }
}
