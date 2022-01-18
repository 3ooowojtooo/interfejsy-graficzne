using NUnit.Framework;
using core;
using System.Collections.Generic;

namespace test
{
    [TestFixture]
    public class PlaceTest
    {

        [Test]
        public void ShouldComputeReviewsMeanCorrectlyForNotEmptyReviewsList()
        {
            var reviews = new List<double> { 1.5, 3.5, 3, 4 };
            var place = new Place(1, "name", "description", reviews, "localization", new List<InterestingPlace>());
            var expectedReviewsMean = 3;

            var reviewsMean = place.ReviewsMean;

            Assert.AreEqual(expectedReviewsMean, reviewsMean);
        }

        [Test]
        public void ShouldComputeReviewsMeanCorrectlyForEmptyReviewsList()
        {
            var reviews = new List<double>();
            var place = new Place(1, "name", "description", reviews, "localization", new List<InterestingPlace>());
            var expectedReviewsMean = 0;

            var reviewsMean = place.ReviewsMean;

            Assert.AreEqual(expectedReviewsMean, reviewsMean);
        }

        [Test]
        public void ShouldAddReviewAndComputeNewMeanCorrectly()
        {
            var reviews = new List<double> { 1.5, 3.5, 3, 4 };
            var place = new Place(1, "name", "description", reviews, "localization", new List<InterestingPlace>());
            var expectedRviewsMeanBeforeAddingReview = 3;

            Assert.AreEqual(expectedRviewsMeanBeforeAddingReview, place.ReviewsMean);

            place.AddReview(15.5);
            var expectedReviewsMeanAfterAddingReview = 5.5;

            Assert.AreEqual(expectedReviewsMeanAfterAddingReview, place.ReviewsMean);
        }
    }
}
