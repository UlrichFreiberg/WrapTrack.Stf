// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase008.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the MainPageTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests
{
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf;

    using WrapTrack.Stf.Adapters.WebAdapter;
    using WrapTrack.Stf.WrapTrackApi;
    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// Tests if user can delete own pictures
    /// </summary>
    [TestClass]
    public class TestCase009 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The tc 009.
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"TestData\")]
        public void Tc009()
        {
            var wrapTrackShell = Get<IWrapTrackWebShell>();
            var pathToNewImage = GetNewImagePath();

            wrapTrackShell.Login();

            var collection = GetCurrentUserCollection(wrapTrackShell, true);
            var myWrap = collection.GetRandomWrap();

            // Find number of pictures before
            var validationTarget = Get<IWtApi>();
            var wtId = myWrap.WtId; // tracking-id
            var before = GetNumberOfPictures(validationTarget, wtId);

            // Do 3 * upload
            myWrap.UploadWrapImage(pathToNewImage);
            myWrap.UploadWrapImage(pathToNewImage);
            myWrap.UploadWrapImage(pathToNewImage);

            // Find number of pictures after upload 
            var after = GetNumberOfPictures(validationTarget, wtId);
            var newNum = before + 3; 

            StfAssert.AreEqual("3 more picture uploaded", after, newNum);


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
