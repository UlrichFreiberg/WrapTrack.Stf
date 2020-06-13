// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase036.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the CollectionTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.News
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The collection tests.
    /// </summary>
    [TestClass]
    public class TestCase036 : WrapTrackTestScriptBase
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
        /// The t c 036.
        /// Set a wrap for sale and check that news story is created
        /// </summary>
        [TestMethod]
        public void Tc036()
        {
            const string TypeOfSale = "for sale (FSO)";

            StfAssert.IsNotNull("wrapTrackShell", WrapTrackShell);
            WrapTrackShell.SignUp();

            var me = WrapTrackShell.Me();

            StfAssert.IsNotNull("me", me);

            var collection = me.GetCollection();

            StfAssert.IsNotNull("Got my collection", collection);

            var newWrap = collection.AddWrap("Ali Dover", "Hygge", "blue");
            var wrap = GetToWrap(newWrap);
            var markWrapForSale = MarkWrapForSale(wrap, TypeOfSale);

            StfAssert.IsTrue("Marked carrier for sale", markWrapForSale);

            var doesNewsOfCarrierForSaleExist = this.DoesNewsOfCarrierForSaleExist(newWrap, TypeOfSale);

            StfAssert.IsTrue("Does news exist that carrier is for sale", doesNewsOfCarrierForSaleExist);
        }

        /// <summary>
        /// The mark wrap for sale.
        /// </summary>
        /// <param name="wrap">
        /// The wrap.
        /// </param>
        /// <param name="typeOfSale">
        /// The type of the sale 
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool MarkWrapForSale(IWrap wrap, string typeOfSale)
        {
            StfAssert.IsNotNull("Wrap", wrap);
            StfAssert.IsNotNull("typeOfSale", typeOfSale);
            StfAssert.StringNotEmpty("typeOfSale", typeOfSale);

            WrapTrackShell.WebAdapter.Click(By.Id("penStatus"));
            SelectDropdownByIdAndText("selCarrierStatus", typeOfSale);
            return WrapTrackShell.WebAdapter.Click(By.Id("butOkNewStatus"));
        }

        /// <summary>
        /// The get to wrap.
        /// </summary>
        /// <param name="wrapId">
        /// The wrap id.
        /// </param>
        /// <returns>
        /// The <see cref="IWrap"/>.
        /// </returns>
        private IWrap GetToWrap(string wrapId)
        {
            StfAssert.StringNotEmpty("Got ID of new wrap", wrapId);

            var wtApi = Get<IWtApi>();
            var wrapInfoBefore = wtApi.WrapInfoByTrackId(wrapId);
            var internalId = wrapInfoBefore.InternalId;

            // Move to the new wrap
            var retVal = WrapTrackShell.GetToWrap(internalId);

            return retVal;
        }

        /// <summary>
        /// The does news exist.
        /// </summary>
        /// <param name="wrapId">
        /// The wrap id.
        /// </param>
        /// <param name="typeOfSale">
        /// The type of the sale
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool DoesNewsOfCarrierForSaleExist(string wrapId, string typeOfSale)
        {
            StfAssert.StringNotEmpty("WrapId", wrapId);
            StfAssert.StringNotEmpty("typeOfSale", typeOfSale);

            var news = WrapTrackShell.News();
            var newsEntry = news.GetNewsEntryCarrierForSale(wrapId, typeOfSale);

            StfAssert.IsNotNull("NewsEntry", newsEntry);

            return true;
        }

        /// <summary>
        /// The set text by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="salesType">
        /// The type of sale.
        /// </param>
        private void SelectDropdownByIdAndText(string id, string salesType)
        {
            // mostly for demo purposes - you can follow what happens
            WrapTrackShell.WebAdapter.WaitForComplete(1);

            var elem = WrapTrackShell.WebAdapter.FindElement(By.Id(id));

            elem.SendKeys(salesType);
        }
    }
}
