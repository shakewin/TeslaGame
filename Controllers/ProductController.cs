using Microsoft.AspNetCore.Mvc;
using TeslaGame.Models;
using System.Linq;
using TeslaGame.Models.ViewModels;

namespace SportsStore.Controllers
{
	public class ProductController : Controller
	{
		IProductRepository repository;
		public int PageSize = 6;

		public ProductController(IProductRepository repo)
		{
			repository = repo;
		}
		public ViewResult List(string category, int productPage = 1) =>
			View(new ProductListViewModel
			{
				Products = repository.Products
							 .Where(p => category == null || p.Category == category)
							 .OrderBy(p => p.ProductID)
							 .Skip((productPage - 1) * PageSize)
							 .Take(PageSize),
				PagingInfo = new PagingInfo
				{
					CurrentPage = productPage,
					ItemsPerPage = PageSize,
					TotalItems = (category == null) ? repository.Products.Count() : repository.Products.Where(p => p.Category == category).Count()
				},
				CurrentCategory = category
			});
	}
}
