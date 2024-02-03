using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Context
{
    public class ECommerceDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=FERHATSOLMAZZ\\SQLEXPRESS; Database=ECommerceDb; User Id=ferhat; Password=12345; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Product>()
			.HasOne(p => p.Size)
			.WithMany()
			.HasForeignKey(p => p.SizeId)
			.OnDelete(DeleteBehavior.Restrict); // İlişkinin otomatik olarak eklenmesini engeller

			modelBuilder.Entity<Product>()
				.HasOne(p => p.Color)
				.WithMany()
				.HasForeignKey(p => p.ColorId)
				.OnDelete(DeleteBehavior.Restrict); // İlişkinin otomatik olarak eklenmesini engeller

			// İlişkiyi Include ederken dış anahtarı eklememek için aşağıdaki kodu kullanın
			modelBuilder.Entity<Product>().Navigation(p => p.Size).UsePropertyAccessMode(PropertyAccessMode.Property);
			modelBuilder.Entity<Product>().Navigation(p => p.Color).UsePropertyAccessMode(PropertyAccessMode.Property);
			base.OnModelCreating(modelBuilder);
           
        }

       public DbSet<Product> Products { get; set;}
       public  DbSet<Category> Categories { get; set;}
       public  DbSet<ParameterDefinition> ParameterDefinitions { get; set; }


	}

    
}
