// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase020.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The test case 020
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The test case 020.
    /// </summary>
    [TestClass]
    public class TestCase020 : WrapTrackTestScriptBase
    {
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
        /// Upload Model Picture
        /// </summary>
        /// <remarks>
        /// Login 
        /// Find a random model 
        /// Upload a picture
        /// one more image is related to the model
        /// one more image is related to the brand  
        /// </remarks>
        [TestMethod]
        public void Tc020()
        {
            // Set up user context for actual test
            // Use default user
            WrapTrackShell.Login();

            var me = WrapTrackShell.Me();

            StfAssert.IsNotNull("WrapTrackShell", WrapTrackShell);
            StfAssert.IsInstanceOfType("me", me, typeof(IMeProfile));

            var modelId = GetRandomModelId();
            var wtApi = Get<IWtApi>();
            var modelInfoBefore = wtApi.ModelInfoByModelId(modelId);
            var oldNumberOfModelImages = modelInfoBefore.NumOfImages;

            // TODO: Check also for Empty String e.g.
            // StfAssert.IsEmptyString("modelId", modelId)
            StfAssert.IsNotNull("modelId", modelId);

            var modelToGet = WrapTrackShell.GetToModel(modelId);

            StfAssert.IsNotNull("modelToGet", modelToGet);

            modelToGet.UploadPicture(@"C:\temp\Stf\Images\WT.jpg");

            var modelInfoAfter = wtApi.ModelInfoByModelId(modelId);
            var newNmberOfModelImages = modelInfoAfter.NumOfImages;

            StfAssert.AreEqual(
                "Check if number of model images has increased",
                oldNumberOfModelImages + 1,
                newNmberOfModelImages);
        }

        /// <summary>
        /// The get random model id.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetRandomModelId()
        {
            return "15890";
        }
    }
}
