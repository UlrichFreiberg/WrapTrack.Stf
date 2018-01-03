// -----------------------------------------!---------------------------------------------------------------------------
// <copyright file="UploadTests.cs" company="Mir Software">
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

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// Tests of diff kinds of upload pictures.
    /// </summary>
    [TestClass]
    public class UploadTests : StfTestScriptBase
    {
        /// <summary>
        /// Test of uploade profile picture
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
        /// The tc 008.
        /// </summary>
        [TestMethod]
        [DeploymentItem(@"TestData\")]
        public void Tc008()
        {
            var wrapTrackShell = Get<IWrapTrackWebShell>();
            var pathToNewImage = GetNewImagePath();

            wrapTrackShell.Login();
            //TODO: Nedenstående skal generaliseres. Bruges også i Tc007 (function GetCurrentUserCollection)

            var me = wrapTrackShell.Me();
            var collection = me.GetCollection();

            StfAssert.IsNotNull("Got a MeProfile", me);
            StfAssert.IsNotNull("Got my collection", collection);

            // Be sure there is a wrap in collection. 
            if (collection.NumOfWraps() == 0)
            {
                collection.AddWrap("Ali Dover", "Hygge", "Blue");
            }
  
            var myWrap = collection.GetRandomWrap();

            // Find number of pictures before
            var validationTarget = Get<IWtApi>();
            var wtId = myWrap.WtId; // tracking-id
            var wrapInfo = validationTarget.WrapInfo(wtId);
            var before = wrapInfo.NumPictures;
            
            // Do upload
            myWrap.UploadWrapImage(pathToNewImage);

            // Find number of pictures after upload 
            var after = wrapInfo.NumPictures;
            var newNum = before + 1; 

            StfAssert.AreEqual("One more picture uploaded", after, newNum);
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
