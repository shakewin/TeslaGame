using System.Linq;

namespace TeslaGame.Models
{
    public interface IProductRepository
    {
		IQueryable<Product> Products { get; }
		void SaveProduct(Product product);
	}
}
