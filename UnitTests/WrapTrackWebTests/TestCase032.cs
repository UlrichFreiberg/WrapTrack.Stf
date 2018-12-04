// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase032.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the MainPageTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using WrapTrack.Stf.WrapTrackApi.Interfaces;

namespace WrapTrackWebTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The main page tests.
    /// </summary>
    [TestClass]
    public class TestCase032 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The wt api.
        /// </summary>
        private IWtApi wtApi;

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            WrapTrackShell = Get<IWrapTrackWebShell>();
            wtApi = Get<IWtApi>();
        }

        /// <summary>
        /// The test sign up.
        /// </summary>
        [TestMethod]
        public void Tc032()
        {
            var natiBabyMuluModel = CreateUserAndFindNatiBabyMuluModel();

            var numberOfReviewBeforeAddingNewOne = GetNumberOfReviewsForNatibaby();

            AddNewReview(natiBabyMuluModel);

            var numberOfReviewAfterAddingNewOne = GetNumberOfReviewsForNatibaby();

            StfAssert.AreEqual("Number of review after adding new one increased by 1",
                numberOfReviewBeforeAddingNewOne + 1, numberOfReviewAfterAddingNewOne);
        }

        private void AddNewReview(IModel natiBabyMuluModel)
        {
            var review = natiBabyMuluModel.Review();

            StfAssert.IsNotNull("Review", review);

            review.Description = "Stf review TC032";

            var addReview = review.Add();

            StfAssert.IsTrue("Added review by new user", addReview);
        }

        private IModel CreateUserAndFindNatiBabyMuluModel()
        {
            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);

            var signUpResult = WrapTrackShell.SignUpAndLogin();

            StfAssert.IsTrue("Sign up and login as test user", signUpResult);

            var natiBabyMuluModel = WrapTrackShell.GetToModel("2624");

            StfAssert.IsNotNull("Nati Baby Mulu model", natiBabyMuluModel);
            return natiBabyMuluModel;
        }


        private int GetNumberOfReviewsForNatibaby()
        {
            var brandInfo = wtApi.BrandInfoByBrandId("5");
            var numberOfReviews = brandInfo.NumOfReviews;

            return numberOfReviews;
        }
    }
}
