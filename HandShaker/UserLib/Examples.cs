using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandShaker.UserLib
{
	public static class Examples
	{
		private static readonly User UserJulia = new User(UserType.User, 1,
			"Юлия Кошкина", "HandShaker Inc.", "Junior Python-разработчик",
			"juliapetrova@gmail.com", "11111111", "/UserLib/PhotoJulia.jpg");

		private static readonly User Sergey = new User(UserType.User, 2, "Сергей Виденин",
			"HandShaker Inc.", "Генеральный директор", "sergeyvidenin@gmail.com",
			"11111111", "/UserLib/photoSergey.jpg");

		private static readonly User Alexander = new User(UserType.User, 3, "Александр Гуреев",
			"HandShaker Inc.", "Middle Kotlin-разработчик", "alexgureev@hanshaker.org",
			"111111111", "/UserLib/photoAlexander.jpg");

		private static readonly User Artyom = new User(UserType.User, 4, "Артём Малофеев",
			"HandShaker Inc.", "Senior Kotlin-разработчик", "artemmalofeev@hanshaker.org",
			"1111111111", "/UserLib/photoArtyom.jpg");


		public static IEnumerable<User> Users { get; } =
			new User[] { User.ExampleAdmin, UserJulia, Sergey, Alexander, Artyom };
	}
}
