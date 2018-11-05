using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeslaGame.Infrastructure;
using TeslaGame.Models;
using TeslaGame.Models.ViewModels;

namespace TeslaGame.Controllers
{
    public class CartController : Controller
    {
		private IProductRepository repository;
		private Cart cart;

		public CartController(IProductRepository repo, Cart cartService)
		{
			repository = repo;
			cart = cartService;
		}

		public ViewResult Index(string returnUrl) =>
			View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });

		public RedirectToActionResult AddToCart(int productId, string returnUrl)
		{
			Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

			if (product != null)
			{
				cart.AddItem(product, 1);
			}

			return RedirectToAction("Index", new { returnUrl });
		}

		public RedirectToActionResult RemoveToCart(int productId, string returnUrl)
		{
			Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

			if (product != null)
			{
				cart.RemoveLine(product);
			}

			return RedirectToAction("Index", new { returnUrl });
		}
	}
}
