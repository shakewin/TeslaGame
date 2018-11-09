using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeslaGame.Models;

namespace TeslaGame.Controllers
{
    public class OrderController : Controller
    {
		private IOrderRepository repository;
		private Cart cart;

		public OrderController(IOrderRepository repo, Cart cartService)
		{
			repository = repo;
			cart = cartService;
		}

		[Authorize]
		public ViewResult List() => View(repository.Orders.Where(o => !o.Shipped));

		[HttpPost]
		[Authorize]
		public IActionResult MarkShipped(int orderID)
		{
			Order order = repository.Orders.FirstOrDefault(o => o.OrderID == orderID);

			if (order != null)
			{
				order.Shipped = true;
				repository.SaveOrder(order);
			}
			return RedirectToAction(nameof(List));
		}

		public ViewResult Checkout() => View(new Order());

		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			if (!cart.Lines.Any())
			{
				ModelState.AddModelError("", "Ваша корзина пуста!");
			}
			if (ModelState.IsValid)
			{
				order.Lines = cart.Lines.ToArray();
				repository.SaveOrder(order);
				return RedirectToAction(nameof(Completed));
			}
			return View(order);
		}

		public ViewResult Completed()
		{
			cart.Clear();
			return View();
		}
	}
}
