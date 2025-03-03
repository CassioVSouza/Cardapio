using Cardapio.ApiService.Entities;

namespace Cardapio.ApiService.Services.Interface
{
    public interface IProdutoService
    {
        Task<ProdutoEntity> AdicionarAsync(ProdutoEntity entity);
        Task<ProdutoEntity> AtualizarAsync(ProdutoEntity entity);
        Task<ProdutoEntity> RemoverAsync(ProdutoEntity entity);
        Task<List<ProdutoEntity>> SelecionarTodosAsync(ProdutoEntity produto);
    }
}
