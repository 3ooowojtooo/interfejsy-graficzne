using System;
using System.Collections.Generic;

namespace core
{
    public class Place
    {
        public int Id { get;  }
        public string Name { get; }
        public string Description { get; }
        public List<double> Reviews { get; }
        public string Localization { get; }
        public List<InterestingPlace> InterestingPlaces { get; }
        public double ReviewsMean { get; private set; }

        public Place(int id, string name, string description, List<double> reviews, string localization, List<InterestingPlace> interestingPlaces)
        {
            Id = id;
            Name = name;
            Description = description;
            Reviews = reviews;
            Localization = localization;
            InterestingPlaces = interestingPlaces;
            ReviewsMean = Utils.computeMean(reviews);
        }

        public void AddReview(double review)
        {
            Reviews.Add(review);
            ReviewsMean = Utils.computeMean(Reviews);
        }

        public override bool Equals(object obj)
        {
            var place = obj as Place;
            return place != null &&
                   Id == place.Id &&
                   Name == place.Name &&
                   Description == place.Description &&
                   EqualityComparer<List<double>>.Default.Equals(Reviews, place.Reviews) &&
                   Localization == place.Localization &&
                   InterestingPlaces.TrueForAll(place.InterestingPlaces.Contains) && place.InterestingPlaces.TrueForAll(InterestingPlaces.Contains) &&
                   ReviewsMean == place.ReviewsMean;
        }

        public override int GetHashCode()
        {
            var hashCode = -1324455003;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<double>>.Default.GetHashCode(Reviews);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Localization);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<InterestingPlace>>.Default.GetHashCode(InterestingPlaces);
            hashCode = hashCode * -1521134295 + ReviewsMean.GetHashCode();
            return hashCode;
        }
    }
}
