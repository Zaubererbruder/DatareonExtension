using Newtonsoft.Json.Linq;

namespace ProgramModules.Tests.Models
{
    public static class JTokenExtensions
    {
        public static bool IsNullOrEmpty(this JToken token)
        {
            return token == null || (token is JValue jvalue ? jvalue.Value.IsNullOrDefault() : !token.HasValues);
        }

        public static bool IsNull(this JToken token)
        {
            return IsNullOrEmpty(token);
        }
    }
}
