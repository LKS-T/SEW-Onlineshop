using Microsoft.EntityFrameworkCore;

namespace Model;

public class OnlineShopContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderedProduct> OrderedProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderedProduct>()
            .HasOne<Product>(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId);
    }

    //docker run -d --name marianne -e MARIADB_ROOT_PASSWORD=123mariadb -p 3306:3306 mariadb:latest
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conn = Environment.GetEnvironmentVariable("CONNECTION_STRING")
                   ?? "Server=localhost;Port=3306;Database=onlineshopdb;User=root;Password=123mariadb";

        optionsBuilder.UseMySql(
            conn,
            new MySqlServerVersion(new Version(8, 0, 29))
        );
    }
}