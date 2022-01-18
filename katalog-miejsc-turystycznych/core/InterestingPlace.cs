using System;
using System.Collections.Generic;

namespace core
{
    public class InterestingPlace
    {
        public string Name { get; }
        public string Localization { get; }
        public string Description { get; }

        public InterestingPlace(string name, string localization, string description)
        {
            this.Name = name;
            this.Localization = localization;
            this.Description = description;
        }

        public override bool Equals(object obj)
        {
            var place = obj as InterestingPlace;
            return place != null &&
                   Name == place.Name &&
                   Localization == place.Localization &&
                   Description == place.Description;
        }

        public override int GetHashCode()
        {
            var hashCode = 477090895;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Localization);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            return hashCode;
        }
    }
}
