// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WrapTrackTestScriptBase.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WrapTrackTestScriptBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Brand;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The wrap track test script base.
    /// </summary>
    public abstract class WrapTrackTestScriptBase : StfTestScriptBase
    {
        /// <summary>
        /// Gets or sets the wrap track shell.
        /// </summary>
        protected IWrapTrackWebShell WrapTrackShell { get; set; }

        /// <summary>
        /// The test cleanup.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            // ensure to logout and to close down the web adapter
            WrapTrackShell?.CloseDown();
        }

        /// <summary>
        /// The get current user collection.
        /// </summary>
        /// <param name="wrapTrackShell">
        /// The wrap track shell.
        /// </param>
        /// <param name="addIfNone">
        /// The add If None.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected ICollection GetCurrentUserCollection(
            IWrapTrackWebShell wrapTrackShell,
            bool addIfNone = true)
        {
            var me = wrapTrackShell.Me();

            StfAssert.IsNotNull("Got a MeProfile", me);

            var collection = me.GetCollection();

            StfAssert.IsNotNull("Got my collection", collection);

            // Be sure there is a wrap in collection. If requested
            if (addIfNone && collection.NumOfWraps() == 0)
            {
                collection.AddWrap("Ali Dover", "Hygge", "Blue");

                // ensure we always are at Collection when done - as we would if not adding a wrap
                me = wrapTrackShell.Me();
                collection = me.GetCollection();
            }

            return collection;
        }

        /// <summary>
        /// The get number of pictures related to this wrap.
        /// </summary>
        /// <param name="validationTarget">
        /// The validation target.
        /// </param>
        /// <param name="wtId">
        /// The wt id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        protected int GetNumberOfPictures(IWtApi validationTarget, string wtId)
        {
            var wrapInfo = validationTarget.WrapInfoByTrackId(wtId);
            var retVal = wrapInfo.NumOfPictures;

            return retVal;
        }

        /// <summary>
        /// The get number of pictures related to this wrap
        /// in this ownership
        /// </summary>
        /// <param name="validationTarget">
        /// The validation target.
        /// </param>
        /// <param name="wtId">
        /// The wt id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        protected int GetNumberOfOwnershipPic(IWtApi validationTarget, string wtId)
        {
            var wrapInfo = validationTarget.WrapInfoByTrackId(wtId);
            var retVal = wrapInfo.NumOfOwnershipPic;

            return retVal;
        }

        /// <summary>
        /// The get another user.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap Track Web Shell.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected string GetAnotherUser(IWrapTrackWebShell wrapTrackWebShell = null)
        {
            var currentShell = wrapTrackWebShell ?? WrapTrackShell;
            var currentUser = currentShell.CurrentLoggedInUser;
            var retVal = "mie88";

            if (currentUser.Equals("mie88", StringComparison.InvariantCultureIgnoreCase))
            {
                retVal = "ida88";
            }

            return retVal;
        }

        /// <summary>
        /// Function used to wait a period of time.
        /// </summary>
        /// <param name="duration">
        /// The duration.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected bool Wait(TimeSpan duration)
        {
            System.Threading.Thread.Sleep(duration);

            return true;
        }

        /// <summary>
        /// The get current user collection. If none, then one is added
        /// </summary>
        /// <returns>
        /// The <see cref="ICollection"/>.
        /// </returns>
        protected ICollection GetCurrentUserCollection()
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
        protected bool ValidatePassOn(string wrapToGo, string anotherUsername)
        {
            Wait(TimeSpan.FromSeconds(10));
            var validationTarget = Get<IWtApi>();
            var wrapInfo = validationTarget.WrapInfoByTrackId(wrapToGo);
            var retVal = string.Compare(wrapInfo.OwnerName, anotherUsername, StringComparison.InvariantCultureIgnoreCase) == 0;

            StfLogger.LogInfo($"ValidatePassOn: OwnerNow=[{wrapInfo.OwnerName}], anotherUser=[{anotherUsername}]");

            return retVal;
        }

        /// <summary>
        /// The get random brand.
        /// </summary>
        /// <returns>
        /// The <see cref="IBrand"/>.
        /// </returns>
        protected IBrand GetRandomBrand()
        {
            var explorer = WrapTrackShell.Explore();

            StfAssert.IsInstanceOfType("explorer", explorer, typeof(IExplore));

            var brands = explorer.Brands();
            var selectedBrand = brands.SelectAndOpenBrand("Agossie");

            return selectedBrand;
        }
    }
}
