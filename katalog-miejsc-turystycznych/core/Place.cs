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
    }
}
