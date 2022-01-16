using System;
using System.Collections.Generic;
using System.Text;

namespace core
{
    internal interface JsonHandler
    {
        string Serialize(List<PlaceEntry> places);

        List<PlaceEntry> Deserialize(string json); 
    }
}
