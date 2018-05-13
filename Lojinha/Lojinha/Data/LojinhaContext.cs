using Lojinha.Models;
using Microsoft.EntityFrameworkCore;

namespace Lojinha.Data
{
    public class LojinhaContext : DbContext
    {
        public LojinhaContext(DbContextOptions<LojinhaContext> options) : base(options)
        { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Itens> Itens { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Itens>().HasKey(t => new { t.PedidoId, t.ProdutoId });
            modelBuilder.Entity<Pedido>().HasIndex(i => i.UsuarioId).IsUnique(false);
        }
    }
}
