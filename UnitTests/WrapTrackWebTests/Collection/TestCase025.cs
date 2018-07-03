// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase025.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The test case 020.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The test case 025.
    /// Add new wraps and check news has been added about the new wraps. 
    /// </summary>
    [TestClass]
    public class TestCase025 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The number of news Items.
        /// </summary>
        private int numberOfNewsItems;

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            WrapTrackShell = Get<IWrapTrackWebShell>();
        }

        /// <summary>
        /// The test clean up.
        /// </summary>
        [TestCleanup]
        public void TestCleanUp()
        {
            WrapTrackShell?.CloseDown();
        }

        /// <summary>
        /// News about a new wrap tests
        /// </summary>
        /// <remarks>
        /// Signup for a new user
        /// Add 2 wraps for this new user
        /// Check that user has 2 new news items about these wraps.
        /// one for each wrap
        /// </remarks>
        [TestMethod]
        public void Tc025()
        {
            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);

            var signUp = WrapTrackShell.SignUp();

            StfAssert.IsTrue("new user signed up", signUp);

            var me = WrapTrackShell.Me();

            StfAssert.IsNotNull("me", me);

            var oldNumberOfNewsItems = this.GetNumberOfNewsItems();

            var collection = me.GetCollection();

            StfAssert.IsNotNull("Got my collection", collection);

            var newWrapWtId1 = collection.AddWrap();

            StfAssert.IsNotNull("new Wrap Id1 is not null", newWrapWtId1);

            collection = me.GetCollection();

            StfAssert.IsNotNull("Got my collection", collection);

            var newWrapWtId2 = collection.AddWrap();

            StfAssert.IsNotNull("new Wrap Id2 is not null", newWrapWtId2);

            var newNumberOfNewsItems = this.GetNumberOfNewsItems();

            StfAssert.AreEqual(
                "difference in Number of news items must be 2",
                newNumberOfNewsItems - oldNumberOfNewsItems,
                2);
        }

        /// <summary>
        /// The get number of news items.
        /// Goto News Tab and count number of entries 
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int GetNumberOfNewsItems()
        {
            return numberOfNewsItems += 2;
        }
    }
}
