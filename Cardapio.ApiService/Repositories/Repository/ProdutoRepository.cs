using Cardapio.ApiService.Data;
using Cardapio.ApiService.Entities;
using Cardapio.ApiService.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cardapio.ApiService.Repositories.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private AppContextData _context;

        public ProdutoRepository(AppContextData context)
        {
            _context = context;
        }

        public async Task<ProdutoEntity?> SelecionarProdutoPeloCodigo(int codigo)
        {
            try
            {
                return await _context.Produto.FirstOrDefaultAsync(p => p.Codigo == codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar produto pelo código.", ex);
            }
        }
    }
}
