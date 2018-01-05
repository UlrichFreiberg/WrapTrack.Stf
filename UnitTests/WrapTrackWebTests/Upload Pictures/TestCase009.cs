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
        /// Gets or sets the wrap track shell.
        /// </summary>
        private IWrapTrackWebShell WrapTrackShell { get; set; }

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            //TODO: Move initialization here. 
            //I tried but lost connection to the objects in the main test
        }

        /// <summary>
        /// The tc 009.
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"TestData\")]
        public void Tc009()
        {
            WrapTrackShell = Get<IWrapTrackWebShell>();
            WrapTrackShell.SignUp(); // new user - empty collection
            var me = WrapTrackShell.Me();
            StfAssert.IsNotNull("We got a me - a brand new user", me);

            var collection = me.GetCollection();
            collection.AddWrap(); // precise 1 wrap in collection

            var theOneAndOnlyWrap = collection.GetRandomWrap();

            var pathToNewImage = GetNewImagePath();

            // Find number of pictures before
            var validationTarget = Get<IWtApi>();
            var wtId = theOneAndOnlyWrap.WtId; // tracking-id
            var before = GetNumberOfPictures(validationTarget, wtId);
            StfAssert.AreEqual("0 pictures before upload", before, 0);

            // Do 3 * upload
            theOneAndOnlyWrap.UploadWrapImage(pathToNewImage, 3);

            // Find number of pictures after upload 
            var after = GetNumberOfPictures(validationTarget, wtId);

            StfAssert.AreEqual("3 pictures after upload", after, 3);

            //TODO: Remove two pictures and assert there is 1 picture left

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
