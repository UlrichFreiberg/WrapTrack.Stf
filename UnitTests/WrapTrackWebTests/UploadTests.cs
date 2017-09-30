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
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf;
    using OpenQA.Selenium;
    using System;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

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
        public void TestUploadProfilePict()
        {
            var wrapTrackShell = Get<IWrapTrackWebShell>();

            wrapTrackShell.Login("pstadel", "cellesaltogsolskin");

            var me = wrapTrackShell.Me();
            StfAssert.IsNotNull("Got a Me", me);

            var oldImage = me.ActualImage();
            StfLogger.LogInfo($"Found image [{oldImage}] as actual Image");

            me.UploadProfileImage();

            var newImage = me.ActualImage();
            StfLogger.LogInfo($"After upload found image [{newImage}] as actual Image");

            StfAssert.StringNotEquals("Got a new actual image", oldImage, newImage);
        }
    }
}
