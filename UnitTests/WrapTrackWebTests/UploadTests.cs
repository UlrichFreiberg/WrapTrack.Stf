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
    /// The main page tests.
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

            StfAssert.IsNotNull("Didn't got a Me", me);

            var oldImage = me.ActualImage();

            StfLogger.LogInfo("Found image [{1}] as actual Image", oldImage);
            StfLogger.LogInfo($"Found image [{oldImage}] as actual Image");

            //  Console.Write(oldImage);
            //IUploadProfileImage uploadProfileImage = me.UploadProfileImage();
            //    string oldId = oldImage.TagName;
            //    string newId = oldImage.TagName;

            // TODO: should be part of solution
            //uploadProfileImage.FileName = @"C:\temp\TestData\Kurt.png";
            //uploadProfileImage.Upload();

            //var newId = uploadProfileImage.Identification;

            //StfAssert.AreNotEqual("New Picture Id", oldId, newId);
            //StfAssert.AreEqual("New Picture Id", 1,1);
        }
    }
}
