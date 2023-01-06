using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConCreate
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
<<<<<<< HEAD
            //optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server=LAPTOP-GC0KUGMH\\SQLEXPRESS; ; database=Starbucks ;Encrypt=False; Integrated Security=True;");
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server=RUZGAR; database=Starbucks ;Encrypt=False; User ID=sa;Password=1234");
          // optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server=405-14; database=Starbucks ;Encrypt=False; User ID=sa;Password=1234");
=======
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server=LAPTOP-GC0KUGMH\\SQLEXPRESS; ; database=Starbucks ;Encrypt=False; Integrated Security=True;");
            //optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server=RUZGAR; database=Starbucks ;Encrypt=False; User ID=sa;Password=1234");
           //optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server=405-14; database=Starbucks ;Encrypt=False; User ID=sa;Password=1234");
>>>>>>> a8bc19fe68808101e9989993b00009f5aba77f4a
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CargoProcess> CargoProcesses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customization> Customizations { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionType> OptionTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCustomization> ProductCustomizations { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreFavorite> StoreFavorites { get; set; }
        public DbSet<StoreOpeningHour> StoreOpeningHours { get; set; }
        public DbSet<StoreProduct> StoreProducts { get; set; }
        public DbSet<StoreProperty> StoreProperties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<WorkTime> WorkTimes { get; set; }
	}
}
