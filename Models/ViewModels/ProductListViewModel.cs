using System.Collections.Generic;
using TeslaGame.Models;

namespace TeslaGame.Models.ViewModels
{
    public class ProductListViewModel
    {
		public IEnumerable<Product> Products { get; set; }
		public PagingInfo PagingInfo { get; set; }
		public string CurrentCategory { get; set; }
    }
}
