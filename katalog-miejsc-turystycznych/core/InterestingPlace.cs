using System;

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
    }
}
