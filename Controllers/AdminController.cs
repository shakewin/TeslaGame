using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeslaGame.Models;

namespace TeslaGame.Controllers
{
	public class AdminController : Controller
	{
		private IProductRepository repository;
		public AdminController(IProductRepository repo)
		{
			repository = repo;
		}

		public ViewResult Index() => View(repository.Products);

		public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductID == productId));
	}
}
