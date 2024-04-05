namespace HandShakerServer.Data
{
    public class UserEntity
    {
        public string Id { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public string Password {  get; set; } = string.Empty;

        public string Salt { get; private set; } = string.Empty;

        public string UserInfo { get; set; } = string.Empty;

        public UserEntity()
        {
            Salt = SaltGenerator.CreateSalt();
        }

        private static class SaltGenerator
        {
            static readonly Random random = new();
            internal static string CreateSalt()
            {
                var length = random.Next(16, 32);

                var chars = new char[length];

                for (int i = 0; i < length; ++i)
                {
                    var charType = random.Next(3);

                    if (charType == 0)
                    {
                        // cur char = digit
                        chars[i] = (char)random.Next('0', '9' + 1);
                    }
                    else if (charType == 1)
                    {
                        // cur char = a small latin letter
                        chars[i] = (char)random.Next('a', 'z' + 1);
                    }
                    else
                    {
                        chars[i] = (char)random.Next('A', 'Z' + 1);
                    }
                }

                return new string(chars);
            }
        }
    }
}
