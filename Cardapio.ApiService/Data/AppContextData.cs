
using Cardapio.ApiService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cardapio.ApiService.Data
{
    public class AppContextData : DbContext
    {
        public AppContextData(DbContextOptions<AppContextData> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MesaEntity> Mesa { get; set; }
        public DbSet<PedidoEntity> Pedido { get; set; }
        public DbSet<ProdutoEntity> Produto { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }

    }
}
