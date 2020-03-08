using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace WeatherForcast.Services {
    public static class JSON {
        public static object ToCollections ( object obj ) {
            if ( obj is JObject jObj )
                return jObj.ToObject<Dictionary<string, object>>()
                           .ToDictionary(k => k.Key, v => ToCollections(v.Value));
            if ( obj is JArray jArr )
                return jArr.ToObject<List<object>>()
                           .Select(ToCollections)
                           .ToList();
            return obj;
        }

        public static object ToObject( string json ) => JsonConvert.DeserializeObject(json);
    }
}
