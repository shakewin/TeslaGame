using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace TeslaGame.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
	}

	public class ToDoContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
			builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TeslaGame;Trusted_Connection=True;MultipleActiveResultSets=true");
			return new ApplicationDbContext(builder.Options);
		}
	}
}
