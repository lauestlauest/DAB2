using DABAssignment2.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using DAB_2_Solution.Model;

namespace DABAssignment2.Data
{
    

    public class AUCanteens : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AUcanteens;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

			protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
				modelBuilder.Entity<Customer>().HasKey(c => c.CustomerCPR);

				modelBuilder.Entity<Reservations>()
					.HasKey(r => r.MealId);
				modelBuilder.Entity<Reservations>()
					.HasOne(r => r.Menu).WithMany(r => r.Reservations).OnDelete(DeleteBehavior.ClientCascade);

				modelBuilder.Entity<Canteens>().HasKey(ca => ca.CanteenName);
				modelBuilder.Entity<Canteens>().Property(c => c.PostCode);

				modelBuilder.Entity<Menu>().HasKey(m => m.MenuItemsId);
			}

			public DbSet<Canteens> Canteens { get; set; }
			public DbSet<Customer> Customer { get; set; }
			public DbSet<Ratings> Ratings { get; set; }
			public DbSet<Reservations> Reservations { get; set; }
			public DbSet<Menu> Menu { get; set; }
			public DbSet<Staff> Staff { get; set; }

		}
	}
