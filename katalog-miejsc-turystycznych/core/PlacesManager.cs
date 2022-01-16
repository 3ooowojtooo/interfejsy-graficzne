using System.Collections.Generic;

namespace core
{
    public class PlacesManager
    {

        private readonly static string DATA_FILENAME = @"Data/data.json";
        private static PlacesManager Instance;

        public List<Place> Places { get; private set; }
        private readonly JsonHandler JsonHandler;
        private readonly FileHandler FileHandler;

        public static PlacesManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new PlacesManager();
            }
            return Instance;
        }

        private PlacesManager()
        {
            JsonHandler = new JsonHandlerImpl();
            FileHandler = new FileHandlerImpl();
            LoadPlacesFromFile();
        }

        internal PlacesManager(JsonHandler jsonHandler, FileHandler fileHandler)
        {
            JsonHandler = jsonHandler;
            FileHandler = fileHandler;
            LoadPlacesFromFile();
        }

        public Place GetPlace(int id)
        {
            return Places[id];
        }

        public void AddPlace(string name, string description, List<double> reviews, string localization, List<InterestingPlace> interestingPlaces)
        {
            Place newPlace = new Place(Places.Count, name, description, reviews, localization, interestingPlaces);
            Places.Add(newPlace);
            WritePlacesToFile();
        }

        public void DeletePlace(int id)
        {
            Places.RemoveAt(id);
            WritePlacesToFile();
        }

        private void LoadPlacesFromFile()
        {
            string dataFileContent = FileHandler.ReadFile(DATA_FILENAME);
            List<PlaceEntry> places = JsonHandler.Deserialize(dataFileContent);
            Places = Mapper.Map(places);
        }

        private void WritePlacesToFile()
        {
            string placesJson = JsonHandler.Serialize(Mapper.Map(Places));
            FileHandler.WriteToFile(DATA_FILENAME, placesJson);
        }
    }
}
