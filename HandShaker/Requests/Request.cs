using HandShaker.Hash;
using HandShaker.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandShaker.Requests
{
    public interface IRequest : IJsonSerializable
    {
        RequestType RequestType { get; }

        IDictionary<string, object> Attributes { get; }
    }
}
