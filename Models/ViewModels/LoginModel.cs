using System.ComponentModel.DataAnnotations;

namespace TeslaGame.Models.ViewModels
{
	public class LoginModel
	{
		[Required(ErrorMessage = "Введите Логин")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Введите пароль")]
		[UIHint("password")]
		public string Password { get; set; }
		public string ReturnUrl { get; set; } = "/";
	}
}
