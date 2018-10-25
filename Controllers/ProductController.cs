using Microsoft.AspNetCore.Mvc;
using TeslaGame.Models;
namespace SportsStore.Controllers
{
	public class ProductController : Controller
	{
		IProductRepository repository;
		public ProductController(IProductRepository repo)
		{
			repository = repo;
		}
		public ViewResult List() => View(repository.Products);
	}
}
