﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace core
{
    public class PlaceEntry
    {
        public String Name { get; }
        public String Description { get; }
        public List<Double> Reviews { get; }
        public String Localization { get; }
        public List<InterestingPlaceEntry> InterestingPlaces { get; }

        [JsonConstructorAttribute]
        public PlaceEntry(String name, String description, List<Double> reviews, String localization, List<InterestingPlaceEntry> interestingPlaces)
        {
            this.Name = name;
            this.Description = description;
            this.Reviews = reviews;
            this.Localization = localization;
            this.InterestingPlaces = interestingPlaces;
        }
    }
}
