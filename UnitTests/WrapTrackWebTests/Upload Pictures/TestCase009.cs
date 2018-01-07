// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase009.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the MainPageTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Upload_Pictures
{
    using System;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var numberOfPictures = GetNumberOfPictures(validationTarget, wtId);

            StfAssert.AreEqual("0 pictures before upload", numberOfPictures, 0);

            // Do 3 * upload
            theOneAndOnlyWrap.UploadWrapImage(pathToNewImage, 3);
            numberOfPictures = GetNumberOfPictures(validationTarget, wtId);
            StfAssert.AreEqual("3 pictures after upload", numberOfPictures, 3);

            // Remove two pictures and assert there is 1 picture left
            theOneAndOnlyWrap.RemoveWrapImage();

            // We have to wait a bit to get WT in sync
            Wait(TimeSpan.FromSeconds(2));
            theOneAndOnlyWrap.RemoveWrapImage();

            // We have to wait a bit to get WT in sync
            Wait(TimeSpan.FromSeconds(2));
            numberOfPictures = GetNumberOfPictures(validationTarget, wtId);

            StfAssert.AreEqual("1 picture left", numberOfPictures, 1);
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
