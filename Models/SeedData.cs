using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace TeslaGame.Models
{
	public static class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			ApplicationDbContext context = app.ApplicationServices
											  .GetRequiredService<ApplicationDbContext>();
			context.Database.Migrate();
			if (!context.Products.Any())
			{
				context.Products.AddRange(
				  new Product
				  {
					  Name = "World War 3",
					  Description = "World War 3 - это многопользовательский военный шутер от первого лица в декорациях современного глобального конфликта.",
					  Category = "Steam",
					  Price = 15.24M,
					  NameImg = "ww3"
				  },
				  new Product
				  {
					  Name = "PLAYERUNKNOWN'S BATTLEGROUNDS",
					  Description = "PLAYERUNKNOWN'S BATTLEGROUNDS - это шутер в котором выигрывает последний оставшийся в живых участник. Летите, исследуйте окрестности, найдите оружие, припасы и станьте единственным выжившим. Это КОРОЛЕВСКАЯ БИТВА!",
					  Category = "Steam",
					  Price = 13.71M,
					  NameImg = "pubg"
				  },
				  new Product
				  {
					  Name = "Fallout 4",
					  Description = "Bethesda Game Studios, создатель популярнейших игр Fallout 3 и The Elder Scrolls V: Skyrim, приглашает вас в мир Fallout 4 – своей самой грандиозной игры нового поколения с открытым миром.",
					  Category = "Steam",
					  Price = 13,
					  NameImg = "fallout4"
				  },
				  new Product
				  {
					  Name = "Call of Duty: Black Ops 4",
					  Description = "Call of Duty: Black Ops 4 - это суровая, жесткая и динамичная сетевая игра, целых три приключения с мертвецами в режиме <<Зомби>>, и режим <<Затмение>>, где вселенная Black Ops воплотится в грандиозной <<королевской битве>>.",
					  Category = "Battle.net",
					  Price = 30.49M,
					  NameImg = "blackops4"
				  },
				  new Product
				  {
					  Name = "Overwatch",
					  Description = "Миру нужны герои! Присоединяйтесь к более чем 40 миллионам игроков со всего мира и откройте для себя мир Overwatch. В вашем распоряжении множество разнообразных героев: солдаты, ученые, авантюристы и совершенно уникальные создания.",
					  Category = "Battle.net",
					  Price = 30.49M,
					  NameImg = "overwatch"
				  },
				  new Product
				  {
					  Name = "Assassin's Creed Odyssey",
					  Description = "Определите свою судьбу в <<Assassin's Creed Одиссея>>. Пройдите путь от изгоя до живой легенды: отправьтесь в далекое странствие, чтобы раскрыть тайны своего прошлого и изменить будущее Древней Греции.",
					  Category = "Uplay",
					  Price = 30.49M,
					  NameImg = "odyssey"
				  },
				  new Product
				  {
					  Name = "Tom Clancy's Rainbow Six Siege",
					  Description = "Tom Clancy's Rainbow Six Осада – это продолжение нашумевшего шутера от первого лица, разработанного студией Ubisoft Montreal.",
					  Category = "Uplay",
					  Price = 7.61M,
					  NameImg = "siege"
				  },
				  new Product
				  {
					  Name = "Tom Clancy’s The Division 2",
					  Description = "Судьба мира зависит от вас Возглавьте отряд спецагентов и наведите порядок в Вашингтоне, пострадавшем от эпидемии.",
					  Category = "Uplay",
					  Price = 30.49M,
					  NameImg = "division2"
				  },
				  new Product
				  {
					  Name = "Battlefield V",
					  Description = "Приготовьтесь вступить в привычные для Второй мировой схватки — от атак парашютистов до танковых боёв. Это не та Вторая мировая, которую вы привыкли видеть — это Battlefield V.",
					  Category = "Origin",
					  Price = 30.49M,
					  NameImg = "bfv"
				  }
				);
				context.SaveChanges();
			}
		}
	}
}
