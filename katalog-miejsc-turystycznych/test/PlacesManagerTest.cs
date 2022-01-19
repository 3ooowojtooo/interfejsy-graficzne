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
            var place1 = new Place(0, "name1", "desc1", reviews, "localization1", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });
            var place2 = new Place(1, "name2", "desc2", reviews, "localization2", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });

            FileHandlerMock.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(returnedJson);
            JsonHandlerMock.Setup(x => x.Deserialize(returnedJson)).Returns(new List<Place> { place1, place2 });

            PlacesManager Manager = new PlacesManager(JsonHandlerMock.Object, FileHandlerMock.Object);

            var places = Manager.GetPlaces();
            Assert.NotNull(places);
            Assert.AreEqual(2, places.Count);
            Assert.AreSame(place1, places[0]);
            Assert.AreSame(place2, places[1]);
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

        [Test]
        public void DeleteExistingPlaceShouldWritePlacesToFile()
        {
            var returnedJson = "abc";
            var interestingPlace1 = new InterestingPlace("interestingName1", "interestingLocalization1", "interestingDescription1");
            var interestingPlace2 = new InterestingPlace("interestingName2", "interestingLocalization2", "interestingDescription2");
            var reviews = new List<double> { 1.5, 2.5 };
            var place1 = new Place(0, "name1", "desc1", reviews, "localization1", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });
            var place2 = new Place(1, "name2", "desc2", reviews, "localization2", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });

            FileHandlerMock.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(returnedJson);
            JsonHandlerMock.Setup(x => x.Deserialize(returnedJson)).Returns(new List<Place> { place1, place2 });

            JsonHandlerMock.Setup(x => x.Serialize(new List<Place> { place2 })).Returns(returnedJson);
            FileHandlerMock.Setup(x => x.WriteToFile(It.IsAny<string>(), returnedJson));

            PlacesManager Manager = new PlacesManager(JsonHandlerMock.Object, FileHandlerMock.Object);
            Manager.DeletePlace(0);

            JsonHandlerMock.VerifyAll();
            FileHandlerMock.VerifyAll();
        }

        [Test]
        public void DeleteNonExistingPlaceShouldNotWritePlacesToFile()
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
            Manager.DeletePlace(100);

            var placesAfterDelete = Manager.GetPlaces();
            Assert.AreEqual(2, placesAfterDelete.Count);
            Assert.AreSame(place1, placesAfterDelete[0]);
            Assert.AreSame(place2, placesAfterDelete[1]);

            JsonHandlerMock.VerifyAll();
            FileHandlerMock.VerifyAll();
        }

        [Test]
        public void UpdateExistingPlaceShouldWritePlacesToFile()
        {
            var returnedJson = "abc";
            var interestingPlace1 = new InterestingPlace("interestingName1", "interestingLocalization1", "interestingDescription1");
            var interestingPlace2 = new InterestingPlace("interestingName2", "interestingLocalization2", "interestingDescription2");
            var reviews = new List<double> { 1.5, 2.5 };
            var place1 = new Place(0, "name1", "desc1", reviews, "localization1", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });
            var place2 = new Place(1, "name2", "desc2", reviews, "localization2", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });
            var updatedPlace = new Place(1, "name2updated", "desc2updated", reviews, "localization2updated", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });

            FileHandlerMock.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(returnedJson);
            JsonHandlerMock.Setup(x => x.Deserialize(returnedJson)).Returns(new List<Place> { place1, place2 });

            JsonHandlerMock.Setup(x => x.Serialize(new List<Place> { place1, updatedPlace })).Returns(returnedJson);
            FileHandlerMock.Setup(x => x.WriteToFile(It.IsAny<string>(), returnedJson));

            PlacesManager Manager = new PlacesManager(JsonHandlerMock.Object, FileHandlerMock.Object);
            Manager.Update(updatedPlace);

            Assert.AreEqual(updatedPlace, Manager.GetPlace(1));

            JsonHandlerMock.VerifyAll();
            FileHandlerMock.VerifyAll();
        }

        [Test]
        public void UpdateNotExistingPlaceShouldNotWritePlacesToFire()
        {
            var returnedJson = "abc";
            var interestingPlace1 = new InterestingPlace("interestingName1", "interestingLocalization1", "interestingDescription1");
            var interestingPlace2 = new InterestingPlace("interestingName2", "interestingLocalization2", "interestingDescription2");
            var reviews = new List<double> { 1.5, 2.5 };
            var place1 = new Place(0, "name1", "desc1", reviews, "localization1", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });
            var place2 = new Place(1, "name2", "desc2", reviews, "localization2", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });
            var updatedPlace = new Place(100, "name2updated", "desc2updated", reviews, "localization2updated", new List<InterestingPlace> { interestingPlace1, interestingPlace2 });

            FileHandlerMock.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(returnedJson);
            JsonHandlerMock.Setup(x => x.Deserialize(returnedJson)).Returns(new List<Place> { place1, place2 });

            PlacesManager Manager = new PlacesManager(JsonHandlerMock.Object, FileHandlerMock.Object);
            Manager.Update(updatedPlace);

            JsonHandlerMock.VerifyAll();
            FileHandlerMock.VerifyAll();
        }
    }
}
