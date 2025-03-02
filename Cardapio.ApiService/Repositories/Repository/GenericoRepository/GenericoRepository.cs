using Cardapio.ApiService.Data;
using Cardapio.ApiService.Repositories.Interface.GenericoRepository;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Cardapio.ApiService.Repositories.Repository.GenericoRepository
{
    public class GenericoRepository<T> : IGenericoRepository<T> where T : class
    {
        private readonly AppContextData _context;
        private readonly ILogger<GenericoRepository<T>> _logger;

        public GenericoRepository(AppContextData context, ILogger<GenericoRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<T> AdicionarAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<T> AtualizarAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<T> RemoverAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async Task<List<T>> SelecionarTodosAsync(T entity)
        {
            try
            {
                var resultados = await _context.Set<T>().ToListAsync();
                return resultados;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }


    }
}
