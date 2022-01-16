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
        public double ReviewsMean { get; }

        public Place(int id, string name, string description, List<double> reviews, string localization, List<InterestingPlace> interestingPlaces)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Reviews = reviews;
            this.Localization = localization;
            this.InterestingPlaces = interestingPlaces;
            this.ReviewsMean = Utils.computeMean(reviews);
        }
    }
}
