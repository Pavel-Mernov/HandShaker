using HandShakerServer.Hash;
using System.Text.Json;

namespace HandShakerServer.Requests
{
    public static class RequestParser
    {
        public static IDictionary<RequestAttributes, object> ParseRequest(this string request)
        {
            var requestDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(request);
            
            if (requestDictionary == null)
            {
                return new Dictionary<RequestAttributes, object>
                {
                    [RequestAttributes.RequestType] = RequestType.Unknown,
                };
            }
            
            var requestKey = "RequestType".GetSHA256();

            if (!requestDictionary.TryGetValue(requestKey, out object? value))
            {
                return new Dictionary<RequestAttributes, object>
                {
                    [RequestAttributes.RequestType] = RequestType.Unknown,
                };
            }

            var result = new Dictionary<RequestAttributes, object>();
            var requestType = value.ToString();

            if (requestType == RequestType.Auth.GetSHA256())
            {
                result[RequestAttributes.RequestType] = RequestType.Auth;
                result[RequestAttributes.Login] = requestDictionary[RequestAttributes.Login.GetSHA256()];
                result[RequestAttributes.Password] = requestDictionary[RequestAttributes.Password.GetSHA256()];

                return result;
            }
            else if (requestType == RequestType.UpdateState.GetSHA256())
            {
                result[RequestAttributes.RequestType] = RequestType.UpdateState;
            }
            // add other a

            return result;
        }
    }
}
