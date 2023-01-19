namespace Infrustructure.Data;
using  Microsoft.EntityFrameworkCore;
using  Domain.Entities;
public class DataContext : DbContext
{
    public  DataContext (DbContextOptions<DataContext>options):base(options)
    {
        
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
}