// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase007.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the CollectionTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The collection tests.
    /// </summary>
    [TestClass]
    public class TestCase007 : StfTestScriptBase
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
            CurrentUser = "Ida88";
            WrapTrackShell = Get<IWrapTrackWebShell>();
            WrapTrackShell.Login(CurrentUser); // default user
        }

        /// <summary>
        /// The TC007.
        /// </summary>
        [TestMethod]
        public void Tc007()
        {
            var collection = GetCurrentUserCollection();

            // Find a random wrap
            var wrapToGo = collection.GetRandomWrap();
            var wtId = wrapToGo.WtId;

            StfAssert.IsNotNull("Got a random wrap", wrapToGo);

            var anotherUser = GetAnotherUser();
            var x = wrapToGo.PassOn(anotherUser);

            StfAssert.IsTrue("PassedOn", x);
            StfAssert.IsTrue("PassedOn Validated", ValidatePassOn(wtId, anotherUser));
        }

        /// <summary>
        /// The validate pass on.
        /// </summary>
        /// <param name="wrapToGo">
        /// The wrap to go.
        /// </param>
        /// <param name="anotherUsername">
        /// The another username.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool ValidatePassOn(string wrapToGo, string anotherUsername)
        {

            var validationTarget = Get<IWtApi>();
            var wrapInfo = validationTarget.WrapInfo(wrapToGo);
            var retVal = wrapInfo.OwnerName == anotherUsername;

            return retVal;
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

        /// <summary>
        /// The get another user.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetAnotherUser()
        {            
            var retVal = CurrentUser == "Ida88" ? "Mie88" : "Ida88";

            return retVal;
        }
    }
}
