using System.Collections.Generic;
using Newtonsoft.Json;

namespace core
{ 
    public sealed class JsonHandlerImpl : JsonHandler
    {
        public string Serialize(List<Place> places)
        {
            return JsonConvert.SerializeObject(Mapper.Map(places));
        }

        public List<Place> Deserialize(string json)
        {
            return Mapper.Map(JsonConvert.DeserializeObject<List<PlaceEntry>>(json));
        }
    }
}
