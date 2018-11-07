using Microsoft.AspNetCore.Mvc;
using TeslaGame.Models;

namespace TeslaGame.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
		private Cart cart;

		public CartSummaryViewComponent(Cart cartService)
		{
			cart = cartService;
		}

		public IViewComponentResult Invoke() => View(cart);
	}
}
