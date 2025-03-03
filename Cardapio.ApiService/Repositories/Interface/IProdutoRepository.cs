using Cardapio.ApiService.Entities;

namespace Cardapio.ApiService.Repositories.Interface
{
    public interface IProdutoRepository
    {
        Task<ProdutoEntity?> SelecionarProdutoPeloCodigo(int codigo);
    }
}
