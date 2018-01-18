// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase012.cs" company="Mir Software">
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

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// Test of letting a wrap pass on from one user to another. 
    /// Another user initiatives this action.
    /// Default date.
    /// </summary>
    [TestClass]
    public class TestCase012 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // Find a random wrap
            WrapTrackShell = Get<IWrapTrackWebShell>();

            WrapTrackShell.Login(); // Default user
            var collection = GetCurrentUserCollection();

            // Find a random wrap
            var wrapToGo = collection.GetRandomWrap();
            var wtId = wrapToGo.WtId;
            WrapTrackShell.Logout(); 
        }

        /// <summary>
        /// The TC012.
        /// </summary>
        [TestMethod]
        public void Tc012()
        {
            var anotherUser = GetAnotherUser(WrapTrackShell);

            WrapTrackShell.Login(anotherUser);

            // StfAssert.IsNotNull("Got a random wrap", wrapToGo);
            // var x = wrapToGo.PassOn(anotherUser);

           // StfAssert.IsTrue("PassedOn", x);
           // StfAssert.IsTrue("PassedOn Validated", ValidatePassOn(wtId, anotherUser));
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
            var wrapInfo = validationTarget.WrapInfoByTrackId(wrapToGo);
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
    }
}
