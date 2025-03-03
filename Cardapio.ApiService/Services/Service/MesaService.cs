using Cardapio.ApiService.Entities;
using Cardapio.ApiService.Repositories.Interface;
using Cardapio.ApiService.Services.Interface;
using Grpc.Core;

namespace Cardapio.ApiService.Services.Service
{
    public class MesaService : IMesaService
    {
        private readonly IGenericoRepository<MesaEntity> _genericoRepository;

        public MesaService(IGenericoRepository<MesaEntity> genericoRepository)
        {
            _genericoRepository = genericoRepository;
        }

        public async Task<MesaEntity> AdicionarAsync(MesaEntity mesa)
        {
            try
            {
                return await _genericoRepository.AdicionarAsync(mesa);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<MesaEntity> AtualizarAsync(MesaEntity mesa)
        {
            try
            {
                return await _genericoRepository.AtualizarAsync(mesa);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<MesaEntity> RemoverAsync(MesaEntity mesa)
        {
            try
            {
                return await _genericoRepository.RemoverAsync(mesa);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<List<MesaEntity>> SelecionarTodosAsync(MesaEntity mesa)
        {
            try
            {
                return await _genericoRepository.SelecionarTodosAsync(mesa);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }
    }
}
