using Cardapio.ApiService.Entities;

namespace Cardapio.ApiService.Services.Interface
{
    public interface IMesaService
    {
        Task<MesaEntity> AdicionarAsync(MesaEntity mesa);
        Task<MesaEntity> AtualizarAsync(MesaEntity mesa);
        Task<MesaEntity> RemoverAsync(MesaEntity mesa);
        Task<List<MesaEntity>> SelecionarTodosAsync(MesaEntity mesa);
    }
}
