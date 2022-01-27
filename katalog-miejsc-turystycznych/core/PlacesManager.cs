using System.Collections.Generic;
using System.Collections.Specialized;

namespace core
{
    public class PlacesManager
    {

        private readonly static string DATA_FILENAME = @"Data/data.json";
        private static PlacesManager Instance;

        private OrderedDictionary Places = new OrderedDictionary();
        private int MaxPlaceIdentifier = 0;
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

        public PlacesManager(JsonHandler jsonHandler, FileHandler fileHandler)
        {
            JsonHandler = jsonHandler;
            FileHandler = fileHandler;
            LoadPlacesFromFile();
        }

        public List<Place> GetPlaces()
        {
            return BuildListOfPlaces();
        }

        private List<Place> BuildListOfPlaces()
        {
            List<Place> result = new List<Place>();
            foreach (var place in Places.Values)
            {
                result.Add(place as Place);
            }
            return result;
        }

        public Place GetPlace(int id)
        {
            return Places[id] as Place;
        }

        public void Update(Place place)
        {
            if (Places.Contains(place.Id))
            {
                Places[place.Id] = place;
                WritePlacesToFile();
            }
        }

        public void AddPlace(string name, string description, List<double> reviews, string localization, List<InterestingPlace> interestingPlaces)
        {
            MaxPlaceIdentifier += 1;
            Place newPlace = new Place(MaxPlaceIdentifier, name, description, reviews, localization, interestingPlaces);
            Places.Add(MaxPlaceIdentifier, newPlace);
            WritePlacesToFile();
        }

        public void DeletePlace(int id)
        {
            if (Places.Contains(id))
            {
                Places.Remove(id);
                WritePlacesToFile();
            }
        }

        private void LoadPlacesFromFile()
        {
            string dataFileContent = FileHandler.ReadFile(DATA_FILENAME);
            List<Place> places = JsonHandler.Deserialize(dataFileContent);
            foreach (var place in places)
            {
                Places.Add(place.Id, place);
            }
            MaxPlaceIdentifier = places.Count - 1;
        }

        private void WritePlacesToFile()
        {
            string placesJson = JsonHandler.Serialize(GetPlaces());
            FileHandler.WriteToFile(DATA_FILENAME, placesJson);
        }
    }
}
