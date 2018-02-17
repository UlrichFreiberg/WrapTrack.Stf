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
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// When letting a wrap pass on from one user to another 
    /// - is it possible to choose your own date?
    /// </summary>
    [TestClass]
    public class TestCase011 : WrapTrackTestScriptBase
    {    
        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            WrapTrackShell = Get<IWrapTrackWebShell>();
            WrapTrackShell.Login();
        }

        /// <summary>
        /// The TC007.
        /// </summary>
        [TestMethod]
        public void Tc011()
        {
            var collection = GetCurrentUserCollection();

            // Find a random wrap
            var wrapToGo = collection.GetRandomWrap();
            var wtId = wrapToGo.WtId;

            StfAssert.IsNotNull("Got a random wrap", wrapToGo);

            var anotherUser = GetAnotherUser(WrapTrackShell);
            var ownershipStart = WtTestscriptUtils.TodayPlusDays(2, "yyyy-MM-dd"); 
            var passOn = wrapToGo.PassOn(anotherUser, ownershipStart);

            StfAssert.IsTrue("PassedOn", passOn);
            StfAssert.IsTrue("PassedOn Validated", ValidatePassOn(wtId, anotherUser));
            StfAssert.IsTrue("Dummy (waiting for bug #24)", true);
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
    }
}
