// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase038.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the CollectionTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.News
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.Core;
    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Review;

    /// <summary>
    /// News is generated when a user rates a wrap  
    /// </summary>
    [TestClass]
    public class TestCase038 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The brand name.
        /// </summary>
        private const string BrandName = "Agossie";

        /// <summary>
        /// The pattern name.
        /// </summary>
        private const string PatternName = "Orchid";

        /// <summary>
        /// The model name.
        /// </summary>
        private const string ModelName = "Glores";

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            WrapTrackShell = Get<IWrapTrackWebShell>();
        }

        /// <summary>
        /// The test clean up.
        /// </summary>
        [TestCleanup]
        public void TestCleanUp()
        {
            WrapTrackShell?.CloseDown();
        }

        /// <summary>
        /// The tc 038.
        /// News is generated when a user rates a wrap.
        /// The user adds some of the review parameters and these are checked 
        /// for entries in the news ite.
        /// </summary>
        [TestMethod]
        public void Tc038()
        {
            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);
            WrapTrackShell.SignUp();

            var criteria = EnumExtensions.GetRandomEnum<ModelReviewProperties>();
            var criteriaText = criteria.GetDisplayName();
            var me = WrapTrackShell.Me();

            StfAssert.IsNotNull("me", me);

            var collection = me.GetCollection();

            StfAssert.IsNotNull("Got my collection", collection);

            var newWrap = collection.AddWrap(BrandName, PatternName, ModelName);
            var wrap = GetToWrap(newWrap);
            var makeEvaluationForWrap = MakeEvaluationForWrap(wrap, criteria);

            StfAssert.IsTrue("evaluation made for wrap", makeEvaluationForWrap);

            var doesNewsOfCarrierEvaluationExist = DoesNewsOfCarrierEvaluationExist(ModelName, criteriaText);

            StfAssert.IsTrue("Does news exist that carrier has an evaluation", doesNewsOfCarrierEvaluationExist);
        }

        /// <summary>
        /// The mark wrap for review.
        /// </summary>
        /// <param name="wrap">
        /// The wrap.
        /// </param>
        /// <param name="criteria">
        /// The criteria.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool MakeEvaluationForWrap(IWrap wrap, ModelReviewProperties criteria)
        {
            StfAssert.IsNotNull("Wrap", wrap);

            var evaulationValue = EnumExtensions.GetRandomEnum<ModelReviewValues>();
            var modelReview = wrap.Review();

            modelReview.ReviewText = "Some Review inserted by STF";

            var retVal = modelReview.SetReviewPropertyValue(criteria, evaulationValue);

            return retVal;
        }

        /// <summary>
        /// The get to wrap.
        /// </summary>
        /// <param name="wrapId">
        /// The wrap id.
        /// </param>
        /// <returns>
        /// The <see cref="IWrap"/>.
        /// </returns>
        private IWrap GetToWrap(string wrapId)
        {
            StfAssert.StringNotEmpty("Got ID of new wrap", wrapId);

            var wtApi = Get<IWtApi>();
            var wrapInfoBefore = wtApi.WrapInfoByTrackId(wrapId);
            var internalId = wrapInfoBefore.InternalId;

            // Move to the new wrap
            var retVal = WrapTrackShell.GetToWrap(internalId);

            return retVal;
        }

        /// <summary>
        /// The does news exist.
        /// </summary>
        /// <param name="modelName">
        /// The model name
        /// </param>
        /// <param name="criteriaText">
        /// The review text
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool DoesNewsOfCarrierEvaluationExist(string modelName, string criteriaText)
        {
            StfAssert.StringNotEmpty("modelId", modelName);
            StfAssert.StringNotEmpty("criteriaText", criteriaText);

            var news = WrapTrackShell.News();
            var newsEntry = news.GetNewsEntryCarrierEvaluation(modelName, criteriaText);

            StfAssert.IsNotNull("NewsEntry", newsEntry);

            return true;
        }
    }
}
