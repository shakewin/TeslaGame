using TeslaGame.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TeslaGame.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
		IProductRepository repository;

		public NavigationMenuViewComponent(IProductRepository repo)
		{
			repository = repo;
		}

		public IViewComponentResult Invoke()
		{
			ViewBag.SelectedCategory = RouteData?.Values["category"];
			return View(repository.Products
							.Select(p => p.Category)
							.Distinct()
							.OrderBy(x => x));
		}
	}
}
