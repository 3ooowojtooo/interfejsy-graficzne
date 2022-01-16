using System;

namespace core
{
    public class InterestingPlace
    {
        public String Name { get; }
        public String Localization { get; }
        public String Description { get; }

        public InterestingPlace(String name, String localization, String description)
        {
            this.Name = name;
            this.Localization = localization;
            this.Description = description;
        }
    }
}
