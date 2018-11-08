using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace TeslaGame.Models
{
    public class Product
    {
		public int ProductID { get; set; }

		[Required(ErrorMessage = "Введите название")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Добавте описание")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Укажите название промо-изображения")]
		public string NameImg { get; set; }

		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Введите положительное число")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Укажите игровую платформу")]
		public string Category { get; set; }
	}
}
