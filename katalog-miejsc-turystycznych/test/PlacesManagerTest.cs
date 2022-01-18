using NUnit.Framework;
using core;
using System.Collections.Generic;
using Moq;

namespace test
{
    [TestFixture]
    public class PlacesManagerTest
    {

        private Mock<JsonHandler> JsonHandlerMock;
        private Mock<FileHandler> FileHandlerMock;

        [SetUp]
        public void Init()
        {
            JsonHandlerMock = new Mock<JsonHandler>(MockBehavior.Strict);
            FileHandlerMock = new Mock<FileHandler>(MockBehavior.Strict);
        }

        [Test]
        public void ShouldLoadDataFromFileUponManagerCreation()
        {
            var returnedJson = "abc";
            var interestingPlace1 = new InterestingPlace("interestingName1", "interestingLocalization1", "interestingDescription1");
            var interestingPlace2 = new InterestingPlace("interestingName2", "interestingLocalization2", "interestingDescription2");
            var reviews = new List<double> { 1.5, 2.5 };
            var place = new Place(1, "name1", "desc1", reviews, "localization1", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });

            FileHandlerMock.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(returnedJson);
            JsonHandlerMock.Setup(x => x.Deserialize(returnedJson)).Returns(new List<Place> { place });

            PlacesManager Manager = new PlacesManager(JsonHandlerMock.Object, FileHandlerMock.Object);

            Assert.NotNull(Manager.Places);
            Assert.AreEqual(1, Manager.Places.Count);
            Assert.AreSame(place, Manager.Places[0]);
            JsonHandlerMock.VerifyAll();
            FileHandlerMock.VerifyAll();
        }

        [Test]
        public void GetPlaceShouldReturnCorrectPlace()
        {
            var returnedJson = "abc";
            var interestingPlace1 = new InterestingPlace("interestingName1", "interestingLocalization1", "interestingDescription1");
            var interestingPlace2 = new InterestingPlace("interestingName2", "interestingLocalization2", "interestingDescription2");
            var reviews = new List<double> { 1.5, 2.5 };
            var place1 = new Place(0, "name1", "desc1", reviews, "localization1", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });
            var place2 = new Place(1, "name2", "desc2", reviews, "localization2", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });

            FileHandlerMock.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(returnedJson);
            JsonHandlerMock.Setup(x => x.Deserialize(returnedJson)).Returns(new List<Place> { place1, place2 });

            PlacesManager Manager = new PlacesManager(JsonHandlerMock.Object, FileHandlerMock.Object);

            Assert.AreSame(place1, Manager.GetPlace(0));
            Assert.AreSame(place2, Manager.GetPlace(1));
            JsonHandlerMock.VerifyAll();
            FileHandlerMock.VerifyAll();
        }

        [Test]
        public void AddPlaceShouldWritePlacesToFile()
        {
            var returnedJson = "abc";
            var interestingPlace1 = new InterestingPlace("interestingName1", "interestingLocalization1", "interestingDescription1");
            var interestingPlace2 = new InterestingPlace("interestingName2", "interestingLocalization2", "interestingDescription2");
            var reviews = new List<double> { 1.5, 2.5 };
            var place = new Place(0, "name1", "desc1", reviews, "localization1", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });
            var expectedAddedPlace = new Place(1, "name2", "desc2", reviews, "localization2", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });

            FileHandlerMock.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(returnedJson);
            JsonHandlerMock.Setup(x => x.Deserialize(returnedJson)).Returns(new List<Place> { place });

            JsonHandlerMock.Setup(x => x.Serialize(new List<Place> { place, expectedAddedPlace })).Returns(returnedJson);
            FileHandlerMock.Setup(x => x.WriteToFile(It.IsAny<string>(), returnedJson));

            PlacesManager Manager = new PlacesManager(JsonHandlerMock.Object, FileHandlerMock.Object);
            Manager.AddPlace("name2", "desc2", reviews, "localization2", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });

            JsonHandlerMock.VerifyAll();
            FileHandlerMock.VerifyAll();
        }
    }
}
