using HandShakerAdmin.Hash;
using HandShakerAdmin.UserLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HandShakerAdmin.Request
{
    public class AddUserRequest(User user) : IRequest
    {
        public RequestType RequestType => RequestType.AddUser;

        public string Serialize()
        {
            var attrRequestType = "RequestType".GetSHA256();
            var attrUser = "User".GetSHA256();

            var attrDict = new Dictionary<string, string>
            {
                [attrRequestType] = RequestType.AddUser.ToString().GetSHA256(),
                [attrUser] = user.Serialize()
            };

            var jsonString = JsonSerializer.Serialize(attrDict);
            return jsonString;
        }
    }
}
