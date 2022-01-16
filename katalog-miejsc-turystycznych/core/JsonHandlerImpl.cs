using System.Collections.Generic;
using System.Text.Json;

namespace core
{ 
    internal sealed class JsonHandlerImpl : JsonHandler
    {
        string JsonHandler.Serialize(List<PlaceEntry> places)
        {
            return JsonSerializer.Serialize(places);
        }

        List<PlaceEntry> JsonHandler.Deserialize(string json)
        {
            return JsonSerializer.Deserialize<List<PlaceEntry>>(json);
        }
    }
}
