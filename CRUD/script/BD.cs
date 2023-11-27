using Microsoft.EntityFrameworkCore;

namespace SeuProjeto.Models
{
    public class MeuContexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<ItemCarrinho> ItensCarrinho { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MARYTOP\SQLEXPRESS;Database=Marketplace;Trusted_Connection=True;");
        }
    }
}
