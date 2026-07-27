using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Orders>()
            .HasOne(o => o.ShipmentDelivery)
            .WithOne(s => s.orders)
            .HasForeignKey<shipmentDelivery>(s => s.orderID);

        modelBuilder.Entity<Addresses>()
            .HasOne(a => a.user)
        .WithMany(u => u.Addresses)
        .HasForeignKey(a => a.userID);

        modelBuilder.Entity<Admins>()
        .Property(a => a.AccessLevel)
        .HasConversion<string>();

        modelBuilder.Entity<users>()
        .Property(u => u.Role)
        .HasConversion<string>();

         modelBuilder.Entity<Customer>()
        .HasOne(c => c.PreferredPaymentMethod)
        .WithMany(pm => pm.Customers)
        .HasForeignKey(c => c.PreferredPaymentMethodID)
        .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<CartItem>()
        .HasOne(ci => ci.carts)
        .WithMany(c => c.cartItems)
        .HasForeignKey(ci => ci.cartItemID);
    }
    
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Admins> Admins { get; set; }
        public DbSet<Cart> Cart {  get; set; }
        public DbSet<CartItem>  CartItem { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<payment> payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<products> products { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<shipmentDelivery> shipmentDelivery { get; set; }
        public DbSet<SupportAgent> SupportAgent { get; set; }
        public DbSet<users> users { get; set; }
    }

