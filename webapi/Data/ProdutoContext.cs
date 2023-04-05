using Microsoft.EntityFrameworkCore;
using webapi.Model;

public class ProdutoContext : DbContext
{
    private readonly IConfiguration configuration;
    public DbSet<Produto> Produtos { get; set; }
    
    public ProdutoContext(IConfiguration configuration)
    {
        this.configuration = configuration;

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DBConnection"));
    }
}