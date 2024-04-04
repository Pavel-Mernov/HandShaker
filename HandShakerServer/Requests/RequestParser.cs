using HandShakerServer.Hash;
using System.Text.Json;

namespace HandShakerServer.Requests
{
    public static class RequestParser
    {
        public static IDictionary<string, object> ParseRequest(this string request)
        {
            var requestDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(request);
            
            if (requestDictionary == null)
            {
                return new Dictionary<string, object>();
            }
            
            var requestKey = "RequestType".GetSHA256();

            if (!requestDictionary.ContainsKey(requestKey))
            {
                return new Dictionary<string, object>
                {
                    ["Type"] = RequestType.Unknown,
                };
            }

            var requestType = requestDictionary[requestKey].ToString();

            return requestDictionary;
        }
    }
}
