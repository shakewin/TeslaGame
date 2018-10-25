using System.Collections.Generic;
using System.Linq;

namespace TeslaGame.Models
{
	public class TestProductRepository : IProductRepository
	{
		public IQueryable<Product> Products => new List<Product>
		{
			new Product { Name = "World War 3", Price = 15.24M },
			new Product { Name = "PLAYERUNKNOWN'S BATTLEGROUNDS", Price = 13.71M },
			new Product { Name = "Fallout 4", Price = 13 }
		}.AsQueryable<Product>();
	}
}
