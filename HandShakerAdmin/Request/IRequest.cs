using HandShakerAdmin.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandShakerAdmin.Request
{
    public interface IRequest : IJsonSerializable
    {
        RequestType RequestType { get; }
    }
}
