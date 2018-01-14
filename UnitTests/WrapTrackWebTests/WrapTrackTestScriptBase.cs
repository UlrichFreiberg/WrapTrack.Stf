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
            var collection = me.GetCollection();

            StfAssert.IsNotNull("Got a MeProfile", me);
            StfAssert.IsNotNull("Got my collection", collection);

            // Be sure there is a wrap in collection. If requested
            if (addIfNone && collection.NumOfWraps() == 0)
            {
                collection.AddWrap("Ali Dover", "Hygge", "Blue");
            }

            return collection;
        }

        /// <summary>
        /// The get number of pictures.
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
            var wrapInfo = validationTarget.WrapInfo(wtId);
            var retVal = wrapInfo.NumPictures;

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
        protected string GetAnotherUser(IWrapTrackWebShell wrapTrackWebShell)
        {
            var currentUser = wrapTrackWebShell.CurrentLoggedInUser;
            var retVal = "Ida88";

            if (currentUser.Equals("Ida88", StringComparison.InvariantCultureIgnoreCase))
            {
                retVal = "Mie88";
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
        /// The date plus days.
        /// </summary>
        /// <param name="days">
        /// The days.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <returns>
        /// The <see cref="DateTime"/>.
        /// </returns>
        protected string TodayPlusDays(int days, string format = "yyyyMMdd")
        {
            var date = DateTime.Today + TimeSpan.FromDays(days);
            var retVal = date.ToString(format);

            return retVal;
        }
    }
}
