using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TeslaGame.Models;

namespace TeslaGame.Controllers
{
    public class OrderController : Controller
    {
		public ViewResult Checkout() => View(new Order());
    }
}
