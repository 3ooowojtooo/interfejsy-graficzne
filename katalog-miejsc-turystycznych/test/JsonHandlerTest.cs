using NUnit.Framework;
using core;
using System.Collections.Generic;

namespace test
{
    [TestFixture]
    public class JsonHandlerTest
    {

        private JsonHandler Handler;

        [SetUp]
        public void Init()
        {
            Handler = new JsonHandlerImpl();
        }

        [Test]
        public void ShouldSerializeCorrectly()
        {
            var interestingPlace1 = new InterestingPlace("interestingName1", "interestingLocalization1", "interestingDescription1");
            var interestingPlace2 = new InterestingPlace("interestingName2", "interestingLocalization2", "interestingDescription2");
            var reviews1 = new List<double> { 1.5, 2.5 };
            var place1 = new Place(1, "name1", "desc1", reviews1, "localization1", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });

            var interestingPlace3 = new InterestingPlace("interestingName3", "interestingLocalization3", "interestingDescription3");
            var interestingPlace4 = new InterestingPlace("interestingName4", "interestingLocalization4", "interestingDescription4");
            var reviews2 = new List<double> { 10, 20 };
            var place2 = new Place(2, "name2", "desc2", reviews2, "localization2", new List<InterestingPlace> { interestingPlace3, interestingPlace4 });

            var expectedSerializationResult = "[{\"Name\":\"name1\",\"Description\":\"desc1\",\"Reviews\":[1.5,2.5],\"Localization\":\"localization1\",\"InterestingPlaces\":[{\"Name\":\"interestingName1\",\"Localization\":\"interestingLocalization1\",\"Description\":\"interestingDescription1\"},{\"Name\":\"interestingName2\",\"Localization\":\"interestingLocalization2\",\"Description\":\"interestingDescription2\"}]},{\"Name\":\"name2\",\"Description\":\"desc2\",\"Reviews\":[10.0,20.0],\"Localization\":\"localization2\",\"InterestingPlaces\":[{\"Name\":\"interestingName3\",\"Localization\":\"interestingLocalization3\",\"Description\":\"interestingDescription3\"},{\"Name\":\"interestingName4\",\"Localization\":\"interestingLocalization4\",\"Description\":\"interestingDescription4\"}]}]";

            var serializationResult = Handler.Serialize(new List<Place> { place1, place2 });

            Assert.AreEqual(expectedSerializationResult, serializationResult);
        }

        [Test]
        public void ShouldDeserializeCorrectly()
        {
            var json = "[{\"Name\":\"name1\",\"Description\":\"desc1\",\"Reviews\":[1.5,2.5],\"Localization\":\"localization1\",\"InterestingPlaces\":[{\"Name\":\"interestingName1\",\"Localization\":\"interestingLocalization1\",\"Description\":\"interestingDescription1\"},{\"Name\":\"interestingName2\",\"Localization\":\"interestingLocalization2\",\"Description\":\"interestingDescription2\"}]},{\"Name\":\"name2\",\"Description\":\"desc2\",\"Reviews\":[10.0,20.0],\"Localization\":\"localization2\",\"InterestingPlaces\":[{\"Name\":\"interestingName3\",\"Localization\":\"interestingLocalization3\",\"Description\":\"interestingDescription3\"},{\"Name\":\"interestingName4\",\"Localization\":\"interestingLocalization4\",\"Description\":\"interestingDescription4\"}]}]";

            var deserializationResult = Handler.Deserialize(json);

            var pl1 = deserializationResult[0];
            var pl2 = deserializationResult[1];

            Assert.AreEqual(0, pl1.Id);
            Assert.AreEqual("name1", pl1.Name);
            Assert.AreEqual("desc1", pl1.Description);
            Assert.AreEqual(1.5, pl1.Reviews[0]);
            Assert.AreEqual(2.5, pl1.Reviews[1]);
            Assert.AreEqual("localization1", pl1.Localization);
            Assert.AreEqual("interestingName1", pl1.InterestingPlaces[0].Name);
            Assert.AreEqual("interestingLocalization1", pl1.InterestingPlaces[0].Localization);
            Assert.AreEqual("interestingDescription1", pl1.InterestingPlaces[0].Description);
            Assert.AreEqual("interestingName2", pl1.InterestingPlaces[1].Name);
            Assert.AreEqual("interestingLocalization2", pl1.InterestingPlaces[1].Localization);
            Assert.AreEqual("interestingDescription2", pl1.InterestingPlaces[1].Description);

            Assert.AreEqual(1, pl2.Id);
            Assert.AreEqual("name2", pl2.Name);
            Assert.AreEqual("desc2", pl2.Description);
            Assert.AreEqual(10, pl2.Reviews[0]);
            Assert.AreEqual(20, pl2.Reviews[1]);
            Assert.AreEqual("localization2", pl2.Localization);
            Assert.AreEqual("interestingName3", pl2.InterestingPlaces[0].Name);
            Assert.AreEqual("interestingLocalization3", pl2.InterestingPlaces[0].Localization);
            Assert.AreEqual("interestingDescription3", pl2.InterestingPlaces[0].Description);
            Assert.AreEqual("interestingName4", pl2.InterestingPlaces[1].Name);
            Assert.AreEqual("interestingLocalization4", pl2.InterestingPlaces[1].Localization);
            Assert.AreEqual("interestingDescription4", pl2.InterestingPlaces[1].Description);
        }
    }
}
