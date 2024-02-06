using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HandShaker.UserLib
{
    public class User : FrameworkElement
    {


        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string), typeof(User), new PropertyMetadata(string.Empty));



        public string Company
        {
            get { return (string)GetValue(CompanyProperty); }
            set { SetValue(CompanyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Company.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompanyProperty =
            DependencyProperty.Register("Company", typeof(string), typeof(User), new PropertyMetadata(string.Empty));



        public string Position
        {
            get { return (string)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Position.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(string), typeof(User), new PropertyMetadata(string.Empty));




        public string Email
        {
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Email.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmailProperty =
            DependencyProperty.Register("Email", typeof(string), typeof(User), new PropertyMetadata(string.Empty));





        public string PasswordHash
        {
            get { return (string)GetValue(PasswordHashProperty); }
            set { SetValue(PasswordHashProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PasswordHash.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordHashProperty =
            DependencyProperty.Register("PasswordHash", typeof(string), typeof(User), new PropertyMetadata(string.Empty));

        public User() { }

        public User(string userName, string company, string position, string email, string passwordHash)
        {
            UserName = userName;
            Company = company;
            Position = position;
            Email = email;
            PasswordHash = passwordHash;

        }


        public static User ExampleUser { get; } = new User("Pavel Mernov", "HandShaker Inc.", "Junior C# .NET Developer", "paulmernov@gmail.com", "11111111");
    }
}
