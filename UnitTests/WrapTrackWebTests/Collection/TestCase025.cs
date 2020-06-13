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

    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The test case 025.
    /// Add new wraps and check news has been added about the new wraps. 
    /// </summary>
    [TestClass]
    public class TestCase025 : WrapTrackTestScriptBase
    {
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
            // Set up user context for actual test
            // Use default user
            WrapTrackShell.Login();

            // Add a new wrap and check for a news item
            AddWrapAndCheckForNewsAboutNewWrap();

            // Add another new wrap and check for a news item
            AddWrapAndCheckForNewsAboutNewWrap();
        }

        /// <summary>
        /// The add wrap and check for news about new wrap.
        /// </summary>
        private void AddWrapAndCheckForNewsAboutNewWrap()
        {
            var me = this.WrapTrackShell.Me();

            this.StfAssert.IsNotNull("WrapTrackShell", this.WrapTrackShell);
            this.StfAssert.IsInstanceOfType("me", me, typeof(IMeProfile));

            var collection = me.GetCollection();

            this.StfAssert.IsNotNull("Got my collection", collection);

            var newWrapWtId = collection.AddWrap();

            this.StfAssert.IsNotNull("new Wrap Id1 is not null", newWrapWtId);

            var isNewsAboutNewWrap = this.IsNewsAboutNewWrap(newWrapWtId, this.WrapTrackShell.CurrentLoggedInUser);

            this.StfAssert.IsTrue("Is there news that the wrap has been registered", isNewsAboutNewWrap);
        }

        /// <summary>
        /// The is news about new wrap being registered
        /// </summary>
        /// <param name="wrapWtId">
        /// The new wrap wt id.
        /// </param>
        /// <param name="registrar">
        /// The registrar of the wrap
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsNewsAboutNewWrap(string wrapWtId, string registrar)
        {
            // set the profile context so we can navigate to the news page afterwards 
            // Not sure why, but if we dont have this call in here the buttonclickbyid below doesn't find the navigation item
            WrapTrackShell.Me();

            // navigate to the news page 
            // Click tab page News
            WrapTrackShell.WebAdapter.ButtonClickById("nav_home");

            var newsElements = WrapTrackShell.WebAdapter.FindElements(By.Id("baereredskab_oprettet"));

            foreach (var newsElement in newsElements)
            {
                var newsAboutNewWrapText = newsElement.Text;
                if (newsAboutNewWrapText.Contains(registrar)
                    &&
                    newsAboutNewWrapText.Contains(wrapWtId))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
