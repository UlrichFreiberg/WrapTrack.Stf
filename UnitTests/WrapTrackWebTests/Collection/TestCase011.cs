// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase011.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the CollectionTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;
    using WrapTrack.Stf.WrapTrackWeb.Me.Collection;

    /// <summary>
    /// Deleting wraps...
    /// </summary>
    [TestClass]
    public class TestCase011 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// Gets or sets the wrap track shell.
        /// </summary>
        private IWrapTrackWebShell WrapTrackShell { get; set; }

        /// <summary>
        /// Gets or sets the current user. 
        /// TODO: Make CurrentUser as a property to WtShell
        /// </summary>
        private string CurrentUser { get; set; }

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            WrapTrackShell = Get<IWrapTrackWebShell>();
            WrapTrackShell.Login(CurrentUser);
        }

        /// <summary>
        /// Test the possibility of deleting a wrap from users collection.
        /// There is more than one reason why the wrap should not be part of 
        /// the user collection any more.
        /// This is test of lost wrap
        /// </summary>
        [TestMethod]
        public void Tc011()
        {
            // Test initialize - be sure we have a least 1 wraps
            var collection = GetCurrentUserCollection();
  
            // Find a random wrap
            var ranWrap = collection.GetRandomWrap();
            var wtId = ranWrap.WtId;

            StfAssert.IsNotNull("Got a random wrap", ranWrap);

            // Status of wrap before
            var validationTarget = Get<IWtApi>();
            var wrapInfo = validationTarget.WrapInfo(wtId);
            var statusBefore = wrapInfo.Status;

            StfAssert.AreEqual("Status before deleting is 0", statusBefore, "0");

            // Delete wrap
            ranWrap.Remove(DeleteWrapOption.LostWrap);
            Wait(TimeSpan.FromSeconds(2));

            // Status of wrap after
            var validationTarget2 = Get<IWtApi>();
            var wrapInfo2 = validationTarget2.WrapInfo(wtId);
            var statusAfter = wrapInfo2.Status;

            StfAssert.AreEqual("Status after deleting is 1", statusAfter, "1");
        }

        /// <summary>
        /// The get current user collection. If none, then one is added
        /// </summary>
        /// <returns>
        /// The <see cref="ICollection"/>.
        /// </returns>
        private ICollection GetCurrentUserCollection()
        {
            var me = WrapTrackShell.Me();
            var collection = me.GetCollection();

            StfAssert.IsNotNull("Got a MeProfile", me);
            StfAssert.IsNotNull("Got my collection", collection);

            // Be sure there is a wrap in collection. 
            if (collection.NumOfWraps() == 0)
            {
                collection.AddWrap("Ali Dover", "Hygge", "White");
            }

            return collection;
        }
    }
}
