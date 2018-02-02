// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase008.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the MainPageTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Upload_Pictures
{
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// Tests of diff kinds of upload pictures.
    /// </summary>
    [TestClass]
    public class TestCase008 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The tc 008.
        /// </summary>
        [TestMethod]
        public void Tc008()
        {
            var wrapTrackShell = Get<IWrapTrackWebShell>();
            var pathToNewImage = GetNewImagePath();

            wrapTrackShell.Login();

            var collection = GetCurrentUserCollection(wrapTrackShell);
            var myWrap = collection.GetRandomWrap();

            // Find number of pictures before (to wrap and to ownership)
            var validationTarget = Get<IWtApi>();
            var wtId = myWrap.WtId; // tracking-id
            var beforeWrapPic = GetNumberOfPictures(validationTarget, wtId);
            var beforeOwnershipPic = GetNumberOfOwnershipPic(validationTarget, wtId);

            // Do upload
            myWrap.UploadWrapImage(pathToNewImage);

            // Find number of pictures after upload 
            var afterWrapPic = GetNumberOfPictures(validationTarget, wtId);
            var newNumWrapPic = beforeWrapPic + 1;

            StfAssert.AreEqual("One more picture related to wrap", afterWrapPic, newNumWrapPic);

            var afterOwnershipPic = GetNumberOfOwnershipPic(validationTarget, wtId);
            var newNumOwnershipPic = beforeOwnershipPic + 1;

            StfAssert.AreEqual("One more picture related to ownership", afterOwnershipPic, newNumOwnershipPic);
        }

        /// <summary>
        /// The get new image path.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetNewImagePath()
        {
            var retVal = Path.Combine(TestContext.TestDeploymentDir, @"Pictures\wraptrack-user-6-10.jpg");
            return retVal;
        }
    }
}
