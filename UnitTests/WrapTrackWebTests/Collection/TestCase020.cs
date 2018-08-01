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

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The test case 020.
    /// </summary>
    [TestClass]
    public class TestCase020 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The number of brand images.
        /// </summary>
        private int numberOfBrandImages;

        /// <summary>
        /// The number of model images.
        /// </summary>
        private int numberOfModelImages;

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            WrapTrackShell = Get<IWrapTrackWebShell>();
            numberOfBrandImages = 42;
            numberOfModelImages = 17;
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

            // TODO: Check also for Empty String e.g.
            // StfAssert.IsEmptyString("modelId", modelId)
            StfAssert.IsNotNull("modelId", modelId);

            var modelToGet = WrapTrackShell.GetToModel(modelId);

            StfAssert.IsNotNull("modelToGet", modelToGet);

            var oldNumberOfModelImages = GetNumberOfModelImages(modelId);
            var oldNumberOfBrandImages = GetNumberOfBrandImages(modelId);

            modelToGet.UploadPicture(@"C:\temp\Stf\Images\WT.jpg");

            var newNmberOfModelImages = GetNumberOfModelImages(modelId);
            var newNumberOfBrandImages = GetNumberOfBrandImages(modelId);

            StfAssert.GreaterThan("Check if number of model images has increased", newNmberOfModelImages, oldNumberOfModelImages);
            StfAssert.GreaterThan("Check if number of brand images has increased", newNumberOfBrandImages, oldNumberOfBrandImages);
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

        /// <summary>
        /// The get number of brand images.
        /// </summary>
        /// <param name="modelId">
        /// The model id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int GetNumberOfBrandImages(string modelId)
        {
            return numberOfBrandImages++;
        }

        /// <summary>
        /// The get number of model images.
        /// </summary>
        /// <param name="modelId">
        /// The model id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int GetNumberOfModelImages(string modelId)
        {
            return numberOfModelImages++;
        }
    }
}
