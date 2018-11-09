using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TeslaGame.Models
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
	{
		public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
		{
		}
	}

	public class MyContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
	{
		public AppIdentityDbContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<AppIdentityDbContext>();
			builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TeslaIdentity;Trusted_Connection=True;MultipleActiveResultSets=true");
			return new AppIdentityDbContext(builder.Options);
		}
	}
}
