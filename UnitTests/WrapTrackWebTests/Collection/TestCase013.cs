// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase010.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the CollectionTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf;

    using WrapTrack.Stf.Adapters.WebAdapter;
    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;
    using WrapTrack.Stf.WrapTrackWeb.Me.Collection;

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
        public void Tc013()
        {
           // Create a wrap to convert
            var orgWrap = Collection.AddWrap("A love so rare", "Alta Lake", "Charcoal", 8);
            StfAssert.IsNotNull("Got the original wrap size 8", orgWrap);

            // Status of original wrap before
            //TODO: We need to know the id of the wrap to validate status later on
            //var validationTarget = Get<IWtApi>();
            //var wrapInfo = validationTarget.WrapInfoByTrackId(wtId);
            //var statusBefore = wrapInfo.Status;
            //StfAssert.AreEqual("Status before deleting is 0", statusBefore, "0");

            // Create two small wraps
            var smallWrap1 = Collection.AddWrap("A love so rare", "Alta Lake", "Charcoal", 2);
            StfAssert.IsNotNull("Got one small wrap size 2", smallWrap1);

            var smallWrap2 = Collection.AddWrap("A love so rare", "Alta Lake", "Charcoal", 2);
            StfAssert.IsNotNull("Got one more small wrap size 2", smallWrap2);

            //TODO: Again we need orgWrap to be a IWrap
            //orgWrap.Convert(smallWrap1); // Not implemented

            //orgWrap.extraConvention(smallWrap2); // Not implemented
        }
    }
}
