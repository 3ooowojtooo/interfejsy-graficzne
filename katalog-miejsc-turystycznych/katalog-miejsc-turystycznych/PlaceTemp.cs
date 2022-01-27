using core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace katalog_miejsc_turystycznych
{
    public class PlaceTemp
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Localization { get { return Street + " " + City + ", " + Country; } }
        public List<InterestingPlace> InterestingPlaces { get; }

        public PlaceTemp()
        {
            InterestingPlaces = new List<InterestingPlace>();
        }

        public void AddInterestingPlace(InterestingPlace interestingPlace)
        {
            InterestingPlaces.Add(interestingPlace);
        }
    }
}
