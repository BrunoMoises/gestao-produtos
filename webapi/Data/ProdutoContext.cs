using Microsoft.EntityFrameworkCore;
using webapi.Model;

public class ProdutoContext : DbContext
{
    public ProdutoContext(DbContextOptions<ProdutoContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Produto>()
            .HasKey(produto =>  produto.Id );
    }

    public DbSet<Produto> Produtos { get; set; }
}