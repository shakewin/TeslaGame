using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeslaGame.Models
{
	public class Order
	{
		[BindNever]
		public int OrderID { get; set; }
		[BindNever]
		public ICollection<CartLine> Lines { get; set; }

		[Required(ErrorMessage = "Введите свой идентификатор")]
		public string Nickname { get; set; }

		[Required(ErrorMessage = "Введите свою страну")]
		public string Country { get; set; }

		[Required(ErrorMessage = "Ввeдите свой e-mail")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Выберите способ оплаты")]
		public string Pay { get; set; }

	}
}