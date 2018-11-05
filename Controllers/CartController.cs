using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TeslaGame.Infrastructure;
using TeslaGame.Models;

namespace TeslaGame.Controllers
{
    public class CartController : Controller
    {
		private IProductRepository repository;

		public CartController(IProductRepository repo)
		{
			repository = repo;
		}

		public RedirectToActionResult AddToCart(int productId, string returnUrl)
		{
			Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

			if (product != null)
			{
				Cart cart = GetCart();
				cart.AddItem(product, 1);
				SaveCart(cart);
			}

			return RedirecctToAction("Index", new { returnUrl });
		}

		public RedirectToActionResult RemoveToCart(int productId, string returnUrl)
		{
			Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

			if (product != null)
			{
				Cart cart = GetCart();
				cart.RemoveLine(product);
				SaveCart(cart);
			}

			return RedirectToAction("Index", new { returnUrl });
		}

		private void SaveCart(Cart cart)
		{
			HttpContext.Session.SetJson("Cart", cart);
		}

		private Cart GetCart()
		{

			Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
			return cart;
		}
	}
}
