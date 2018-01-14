// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase005.cs" company="Mir Software">
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

    using Mir.Stf;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// Tests of upload pictures.
    /// </summary>
    [TestClass]
    public class TestCase005 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// Test of uploade users profile picture
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"TestData\")]
        public void Tc005()
        {
            var wrapTrackShell = Get<IWrapTrackWebShell>();
            var pathToNewImage = GetNewImagePath();

            wrapTrackShell.Login();

            var me = wrapTrackShell.Me();

            StfAssert.IsNotNull("Got a MeProfile", me);

            var oldImage = me.ActualImage();

            StfLogger.LogInfo($"Found image [{oldImage}] as actual Image");
            me.UploadProfileImage(pathToNewImage);

            var newImage = me.ActualImage();

            StfLogger.LogInfo($"After upload found image [{newImage}] as actual Image");
            StfAssert.StringNotEquals("Got a new actual image", oldImage, newImage);
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
