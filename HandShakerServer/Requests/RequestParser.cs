using HandShakerServer.Hash;
using System.Text.Json;

namespace HandShakerServer.Requests
{
    public static class RequestParser
    {
        public static IDictionary<RequestAttributes, object> ParseRequest(this string request)
        {
            var requestDictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(request);
            
            if (requestDictionary == null)
            {
                return new Dictionary<RequestAttributes, object>
                {
                    [RequestAttributes.RequestType] = RequestType.Unknown,
                };
            }
            
            var requestKey = "RequestType".GetSHA256();

            if (!requestDictionary.TryGetValue(requestKey, out string? value))
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
            else if (requestType == RequestType.AddUser.GetSHA256())
            {
                result[RequestAttributes.RequestType] = RequestType.AddUser;
                var userKey = "User".GetSHA256();

                if (!requestDictionary.TryGetValue(userKey, out string? userString))
                {
                    result[RequestAttributes.RequestType] = RequestType.Unknown;
                    return result;
                }

                var userData = JsonSerializer.Deserialize<Dictionary<string, string>>(userString);

                if (userData == null)
                {
                    result[RequestAttributes.RequestType] = RequestType.Unknown;
                    return result;
                }

                if (!userData.TryGetValue("Key".GetSHA256(), out string? userCipherKey))
                {
                    return new Dictionary<RequestAttributes, object>()
                    {
                        [RequestAttributes.RequestType] = RequestType.Unknown,
                    };
                }

                userCipherKey = userCipherKey.DecodeAES(AESAdapter.GetUniversalKey());

            }
            // add other a

            return result;
        }
    }
}
