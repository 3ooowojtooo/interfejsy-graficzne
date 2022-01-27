using System;

namespace core
{
    public class InterestingPlaceEntry
    {
        public String Name { get; }
        public String Localization { get; }
        public String Description { get; }

        public InterestingPlaceEntry(String name, String localization, String description)
        {
            this.Name = name;
            this.Localization = localization;
            this.Description = description;
        }
    }
}
