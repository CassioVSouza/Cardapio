using Cardapio.ApiService.Entities;
using Cardapio.ApiService.Repositories.Interface;
using Cardapio.ApiService.Services.Interface;
using Grpc.Core;

namespace Cardapio.ApiService.Services.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IGenericoRepository<ProdutoEntity> _genericoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IGenericoRepository<ProdutoEntity> genericoRepository, IProdutoRepository produtoRepository)
        {
            _genericoRepository = genericoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoEntity> AdicionarAsync(ProdutoEntity entity)
        {
            try
            {
                return await _genericoRepository.AdicionarAsync(entity);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<ProdutoEntity> AtualizarAsync(ProdutoEntity entity)
        {
            try
            {
                return await _genericoRepository.AtualizarAsync(entity);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<ProdutoEntity> RemoverAsync(ProdutoEntity entity)
        {
            try
            {
                return await _genericoRepository.RemoverAsync(entity);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<List<ProdutoEntity>> SelecionarTodosAsync(ProdutoEntity produto)
        {
            try
            {
                return await _genericoRepository.SelecionarTodosAsync(produto);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<ProdutoEntity?> SelecionarProdutoPeloCodigo(int codigo)
        {
            try
            {
                return await _produtoRepository.SelecionarProdutoPeloCodigo(codigo);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }
    }
}
