using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public IConfiguration _config {set; get; }  
    public ApplicationContext(IConfiguration config)
        { 
            _config  = config; 
        }

    public DbSet<User> Users { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CustomerCategory> CustomerCategories { get; set; }
    public DbSet<CustomerArea> CustomerAreas { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleDetails> SalesDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SaleDetails>()
            .HasKey(sd => new { sd.InvoiceCode, sd.Sno });

        modelBuilder.Entity<SaleDetails>()
            .HasOne(sd => sd.Sale)
            .WithMany(s => s.SalesDetails)
            .HasForeignKey(sd => sd.InvoiceCode);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    }
}
