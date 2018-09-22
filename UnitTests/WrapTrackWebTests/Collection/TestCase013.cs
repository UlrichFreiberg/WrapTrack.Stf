// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase013.cs" company="Mir Software">
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
    /// Converting a wrap to two other wraps.
    /// </summary>
    [TestClass]
    public class TestCase013 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        private ICollection Collection { get; set; }

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            WrapTrackShell = Get<IWrapTrackWebShell>();
            WrapTrackShell.Login();

            // Be sure we have enough wraps for all test instances
            Collection = GetCurrentUserCollection(WrapTrackShell);
        }

        /// <summary>
        /// The tc 013.
        /// </summary>
        [TestMethod]
        public void Tc013()
        {
           // Create a wrap to convert
            var wtId = Collection.AddWrap("Baie", "Duet", "En Bleu", 8);

            StfAssert.IsNotNull("Got the original wrap size 8", wtId);

            // Status of original wrap before
            var validationTarget = Get<IWtApi>();
            var wrapInfo = validationTarget.WrapInfoByTrackId(wtId);
            var statusBefore = wrapInfo.Status;

            StfAssert.AreEqual("Status before deleting is 0", statusBefore, "0");

            // Create two small wraps
            var smallWrap1 = Collection.AddWrap("Baie", "Duet", "En Bleu", 2);
            var smallWrap2 = Collection.AddWrap("Baie", "Duet", "En Bleu", 2);

            StfAssert.IsNotNull("Got one small wrap size 2", smallWrap1);
            StfAssert.IsNotNull("Got one more small wrap size 2", smallWrap2);

            // Mark the test script as InProgress
            StfAssert.IsNotNull("TestCase NOT finished", null);

            // TODO: Again we need orgWrap to be a IWrap
            // orgWrap.Convert(smallWrap1); // Not implemented
            // orgWrap.extraConvention(smallWrap2); // Not implemented
        }
    }
}
