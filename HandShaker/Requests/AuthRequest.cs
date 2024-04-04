using HandShaker.Hash;
//using Newtonsoft.Json;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandShaker.Requests
{
    public class AuthRequest : IRequest
    {
        public RequestType RequestType => RequestType.Auth;

        public string Login { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public AuthRequest(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public IDictionary<string, object> Attributes
        {
            get
            {
                var result = new Dictionary<string, object>();

                var requestType = RequestType.Auth.ToString().GetSHA256();

                result["RequestType".GetSHA256()] = requestType.GetSHA256();
                result["Login".GetSHA256()] = Login.GetSHA256();
                result["Password".GetSHA256()] = Password.GetSHA256();

                return result;
            }
        }

        public string Serialize()
        {
            var attrs = Attributes;
            
            var jsonString = JsonSerializer.Serialize(attrs);

            return jsonString;
        }
    }
}
