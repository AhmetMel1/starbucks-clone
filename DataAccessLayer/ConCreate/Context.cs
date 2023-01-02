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
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server=LAPTOP-GC0KUGMH\\SQLEXPRESS; ; database=DBBusBilet ;Encrypt=False; Integrated Security=True;");
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
	}
}
