using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyAppContext: DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemClient>().HasKey(ic => new
            {
                ic.ItemId,
                ic.ClientId
            });

            modelBuilder.Entity<ItemClient>().HasOne(i => i.Item).WithMany(ic => ic.ItemClients).HasForeignKey(i => i.ItemId);
            modelBuilder.Entity<ItemClient>().HasOne(i => i.Client).WithMany(ic => ic.ItemClients).HasForeignKey(i => i.ClientId);


            modelBuilder.Entity<Item>().HasData(
                new Item { Id=30, Name="Microphone", Description="Awesome Mic", Type="Computer Appliciances", Price=20, SerialNumberId=103}
                );

            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id= 103 , Name="MIC213", ItemId=4}
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Electronics"},
                new Category { Id = 2, Name = "Books" },
                new Category { Id = 3, Name = "Magazine" }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<SerialNumber> SerialNumbers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ItemClient> ItemClients { get; set; }
    }
}
