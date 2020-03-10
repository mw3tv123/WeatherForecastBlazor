using Newtonsoft.Json.Linq;
using System.Linq;

namespace WeatherForcast.Services {
    public static class JSON {
        public static object Deserialize( string json ) => ToObject(JToken.Parse(json));

        public static object ToObject( JToken token ) {
            switch (token.Type) {
                case JTokenType.Object:
                    return token.Children<JProperty>()
                                .ToDictionary(prop => prop.Name,
                                              prop => ToObject(prop.Value));
                case JTokenType.Array:
                    return token.Select(ToObject).ToList();
                default:
                    return ((JValue)token).Value;
            }
        }
    }
}
