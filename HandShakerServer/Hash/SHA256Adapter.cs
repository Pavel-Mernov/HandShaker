using System.Security.Cryptography;
using System.Text;

namespace HandShakerServer.Hash
{
    public static class SHA256Adapter
    {
        private static readonly SHA256 _sha256 = SHA256.Create();

        public static string GetSHA256(this string data, Encoding encoding)
        {
            if (string.IsNullOrEmpty(data))
            {
                return string.Empty;
            }

            var bytes = encoding.GetBytes(data);

            var resultButes = _sha256.ComputeHash(bytes);

            return encoding.GetString(resultButes);
        }


        public static string GetSHA256(this string data) => GetSHA256(data, Encoding.UTF8);

        public static string GetSHA256(this object obj, Encoding encoding) => GetSHA256(obj.ToString(), encoding);

        public static string GetSHA256(this object obj) => GetSHA256(obj.ToString());
    }
}
