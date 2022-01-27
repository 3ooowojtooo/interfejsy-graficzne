using System;
using System.Collections.Generic;
using System.Text;

namespace core
{
    internal class Mapper
    {
        internal static InterestingPlace Map(InterestingPlaceEntry entry)
        {
            return new InterestingPlace(entry.Name, entry.Localization, entry.Description);
        }

        internal static InterestingPlaceEntry Map(InterestingPlace place)
        {
            return new InterestingPlaceEntry(place.Name, place.Localization, place.Description);
        }

        internal static List<InterestingPlace> Map(List<InterestingPlaceEntry> interestingPlaces)
        {
            List<InterestingPlace> interestingPlacesMapped = new List<InterestingPlace>();
            foreach (var place in interestingPlaces)
            {
                interestingPlacesMapped.Add(Map(place));
            }
            return interestingPlacesMapped;
        }

        internal static List<InterestingPlaceEntry> Map(List<InterestingPlace> interestingPlaces)
        {
            List<InterestingPlaceEntry> interestingPlacesMapped = new List<InterestingPlaceEntry>();
            foreach (var place in interestingPlaces)
            {
                interestingPlacesMapped.Add(Map(place));
            }
            return interestingPlacesMapped;
        }

        internal static List<Place> Map(List<PlaceEntry> places)
        {
            List<Place> placesMapped = new List<Place>();
            for(int i = 0; i < places.Count; i++)
            {
                placesMapped.Add(Map(i, places[i]));
            }
            return placesMapped;
        }

        internal static List<PlaceEntry> Map(List<Place> places)
        {
            List<PlaceEntry> placesMapped = new List<PlaceEntry>();
            foreach (var place in places)
            {
                placesMapped.Add(Map(place));
            }
            return placesMapped;
        }

        internal static Place Map(int id, PlaceEntry entry)
        {
            return new Place(id, entry.Name, entry.Description, entry.Reviews, entry.Localization, Map(entry.InterestingPlaces));
        }

        internal static PlaceEntry Map(Place place)
        {
            return new PlaceEntry(place.Name, place.Description, place.Reviews, place.Localization, Map(place.InterestingPlaces));
        }
    }
}
