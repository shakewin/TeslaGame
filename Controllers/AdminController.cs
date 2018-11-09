using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeslaGame.Models;

namespace TeslaGame.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		private IProductRepository repository;
		public AdminController(IProductRepository repo)
		{
			repository = repo;
		}

		public ViewResult Index() => View(repository.Products);

		public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductID == productId));

		[HttpPost]
		public IActionResult Edit(Product product)
		{
			if (ModelState.IsValid)
			{
				repository.SaveProduct(product);
				TempData["message"] = $"{product.Name}: изменения сохранены";
				return RedirectToAction("Index");
			}
			
			return View(product);
		}

		public ViewResult Create() => View("Edit", new Product());

		[HttpPost]
		public IActionResult Delete(int productId)
		{
			Product deletedProduct = repository.DeleteProduct(productId);
			if (deletedProduct != null)
			{
				TempData["message"] = $"{deletedProduct.Name} was deleted";
			}
			return RedirectToAction("Index");
		}

	}
}
