using HandShaker.UserLib.Chats;
using HandShaker.UserLib.Messages;
using HandShaker.UserLib.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandShaker.UserLib
{
	public static class Examples
	{
		public static User ExampleUser 
		{ 
			get
			{
				var user = User.CreateBuilder()
                .SetStatus(UserType.User)
				.SetId(0)
				.SetUserName("Павел Мернов")
				.SetCompany("HandShaker Inc.")
				.SetPosition("Junior .NET-разработчик")
				.SetEmail("paulmernov@gmail.com")
				.SetPassword("11111111")
				.SetImage("/UserLib/Photos/PhotoMeCaucasus.jpg")
				.Build();

				// user.Chats.Add(AdminJuliaChat);

				return user;
            } 
		}
			

		public static User Admin { get; } =
				 User.CreateBuilder()
				.SetStatus(UserType.Admin)
				.SetId(1)
				.SetOnline(true)
				.SetUserName("Павел Мернов")
				.SetCompany("HandShaker Inc.")
				.SetPosition("Администратор")
				.SetEmail("paulmernov@gmail.com")
				.SetPassword("11111111")
				.SetImage("/UserLib/Photos/PhotoMeCaucasus.jpg")
				.Build();


		private static User Julia { get; } =
                User.CreateBuilder()
                .SetId(2)
				.SetStatus(UserType.User)
				.SetOnline(true)
				.SetUserName("Юлия Кошкина")
				.SetPosition("Менеджер")
				.SetCompany("HandShaker Inc.")
				.SetEmail("juliapetrova@gmail.com")
				.SetPassword("1111111")
				.SetImage("/UserLib/Photos/PhotoJulia.jpg")
				.Build();

		private static User Sergey { get; } 
			= User.CreateBuilder()
            .SetId(3)
			.SetStatus(UserType.User)
			.SetUserName("Сергей Виденин")
			.SetCompany("HandShaker Inc.")
			.SetPosition("Генеральный директор")
			.SetPassword("1111111")
			.SetEmail("sergeyvidenin@gmail.com")
			.SetImage("/UserLib/Photos/photoSergey.jpg")
            .Build();

		private static User Alexander { get; } = User.CreateBuilder()
			.SetId(4)
			.SetStatus(UserType.User)
			.SetUserName("Александр Гуреев")
			.SetCompany("HandShaker Inc.")
			.SetPosition("Middle Kotlin-разработчик")
			.SetEmail("alexgureev@hanshaker.org")
			.SetPassword("11111111")
			.SetImage("/UserLib/Photos/photoAlexander.jpg")
			.SetLastTime(DateTime.Now - TimeSpan.FromHours(2.1))
            .Build();

		private static User Artyom { get; } = User.CreateBuilder()
			.SetId(5)
			.SetStatus(UserType.User)
			.SetUserName("Артём Малофеев")
			.SetCompany("HandShaker Inc.")
			.SetPosition("Senior Kotlin-разработчик")
			.SetEmail("artemmalofeev@hanshaker.org")
			.SetPassword("111111111")
			.SetImage("/UserLib/Photos/photoArtyom.jpg")
			.SetLastTime(DateTime.Now - (TimeSpan.FromHours(12.4) - TimeSpan.FromDays(150)))
            .Build();


		public static IEnumerable<User> Users { get; } =
			new User[] { Admin, Julia, Sergey, Alexander, Artyom };

		public static Chat AdminJuliaChat
		{
			get
			{
				var chat = new ChatForTwo(Admin, Julia);

				var firstMessage = Message.CreateBuilder()
					.SetFrom(Admin)
					.SetText("Здравствуйте, Юлия! Я хотел бы записаться на конкурс начинающих программистов \"IT-Весна-2024\". Как я могу подать заявку?")
					.SetDateTime(DateTime.Now - TimeSpan.FromMinutes(72)).Build();

				var secondMessage = Message.CreateBuilder()
					.SetFrom(Julia)
					.SetText("Здравствуйте, Павел! От Вас мне нужно заявляение, шаблон пришлю позже.")
					.SetDateTime(DateTime.Now - TimeSpan.FromMinutes(20))
					.Build();

				firstMessage.Status = ReadStatus.Seen;
				secondMessage.Status = ReadStatus.Seen;

				chat.AddMessage(firstMessage);
				chat.AddMessage(secondMessage);
				

				return chat;
			}
		}

		public static Chat AdminAlexanderChat
		{
			get
			{
				var chat = new ChatForTwo(Admin, Alexander);

				var firstMessage = Message.CreateBuilder()
					.SetFrom(Admin)
					.SetText("Привет,Саша! Получилось сделать подключение к базе данных?")
					.SetDateTime(DateTime.Now - TimeSpan.FromHours(1.2))
					.Build();

				firstMessage.Status = ReadStatus.Received;
				chat.AddMessage(firstMessage);

				return chat;
			}
		}

		public static Chat AdminArtyomChat
		{
			get
			{
				var chat = new ChatForTwo(Admin, Artyom);

				var message = Message.CreateBuilder()
					.SetFrom(Admin)
					.SetDateTime(DateTime.Now - TimeSpan.FromDays(106) + TimeSpan.FromHours(14) + TimeSpan.FromMinutes(24))
					.SetText("Привет, Артём! Давай сходим на вечеринку в воскресенье!")
					.Build();

				message.Status = ReadStatus.Received;
				chat.AddMessage(message);

				return chat;
			}
		}

		public static IEnumerable<Chat> AdminChats { get; } = new Chat[] { AdminJuliaChat, AdminAlexanderChat, AdminArtyomChat, AdminAlexanderChat, AdminJuliaChat, AdminArtyomChat,
			AdminJuliaChat, AdminArtyomChat, AdminAlexanderChat, AdminJuliaChat };
	}
}
