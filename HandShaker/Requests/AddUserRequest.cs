using HandShaker.UserLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandShaker.Requests
{
    public class AddUserRequest : IRequest
    {
        private User _user;

        public AddUserRequest(User user)
        {
            _user = user;
        }

        public RequestType RequestType => RequestType.AddUser;

        public string Serialize()
        {
            throw new NotImplementedException();
        }
    }
}
