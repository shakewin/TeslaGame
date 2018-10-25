using System.Collections.Generic;
using System.Linq;

namespace TeslaGame.Models
{
    public class EFProductRepository : IProductRepository
    {
		ApplicationDbContext context;

		public EFProductRepository(ApplicationDbContext ctx)
		{
			context = ctx;
		}

		public IQueryable<Product> Products => context.Products;
	}
}
