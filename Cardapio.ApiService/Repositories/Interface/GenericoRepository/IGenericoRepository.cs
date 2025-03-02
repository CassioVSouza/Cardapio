namespace Cardapio.ApiService.Repositories.Interface.GenericoRepository
{
    public interface IGenericoRepository<T> where T : class
    {
        Task<T> AdicionarAsync(T entity);
        Task<T> AtualizarAsync(T entity);
        Task<T> RemoverAsync(T entity);
        Task<List<T>> SelecionarTodosAsync(T entity);
    }
}
