using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandShaker.UserLib
{
    public static class Examples
    {
        public static User ExampleUser { get; }
    = new User(1, UserType.User, "Павел Мернов", "HandShaker Inc.", "Junior .NET-разработчик", "paulmernov@gmail.com", "11111111", "/UserLib/PhotoMeCaucasus.jpg");

        public static User ExampleAdmin { get; }
            = new User(0, UserType.Admin, "Павел Мернов", "HandShaker Inc.", "Администратор", "paulmernov@gmail.com", "11111111", "/UserLib/PhotoMeCaucasus.jpg");

        public static User OtherUser { get; }
            = new User(2, UserType.User, "Юлия Кошкина", "HandShaker Inc.", "Менеджер", "jkkoshkina@handshaker.org", "2222222222", "/UserLib/photoOtherUser.jpg")
            {
                IsOnline = true,
            };

        public static Chat ExampleChat
        {
            get
            {
                var chat = new Chat(new[] { ExampleAdmin, OtherUser });

                var firstMessage = new Message("Здравствуйте, Юлия! Как я могу подать заявку на весенний певческий конкурс НИУ ВШЭ?", ExampleAdmin, DateTime.Now - 
                    TimeSpan.FromHours(2.2));

                var secondMessage = new Message("Здравствуйте, Павел! От Вас мне нужна копия паспорта и заявление:)", OtherUser, DateTime.Now -
                    TimeSpan.FromHours(1.5));

                chat.AddMessage(firstMessage);
                chat.AddMessage(secondMessage);

                return chat;
            }
        }
    }
}
