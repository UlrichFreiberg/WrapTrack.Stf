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

    using Mir.Stf;
    using System.Windows;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The wrap track test script base.
    /// </summary>
    public abstract class WrapTrackTestScriptBase : StfTestScriptBase
    {
        /// <summary>
        /// The get current user collection.
        /// </summary>
        /// <param name="wrapTrackShell">
        /// The wrap track shell.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected ICollection GetCurrentUserCollection(IWrapTrackWebShell wrapTrackShell)
        {
            var me = wrapTrackShell.Me();
            var collection = me.GetCollection();

            StfAssert.IsNotNull("Got a MeProfile", me);
            StfAssert.IsNotNull("Got my collection", collection);

            // Be sure there is a wrap in collection. 
            if (collection.NumOfWraps() == 0)
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
        /// Function used to wait a period of time.
        /// </summary>
        /// <param name="duration">
        /// The duration.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Wait(TimeSpan duration)
        {
            System.Threading.Thread.Sleep(duration);

            return true;
        }
    }
}
