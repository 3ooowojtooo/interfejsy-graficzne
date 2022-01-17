using System;
using System.Collections.Generic;
using System.Text;

namespace core
{
    public interface JsonHandler
    {
        string Serialize(List<Place> places);

        List<Place> Deserialize(string json); 
    }
}
