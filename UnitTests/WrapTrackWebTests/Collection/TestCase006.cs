// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase006.cs" company="Mir Software">
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

    using Mir.Stf;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The collection tests.
    /// </summary>
    [TestClass]
    public class TestCase006 : StfTestScriptBase
    {
        /// <summary>
        /// The t c 006.
        /// </summary>
        [TestMethod]
        public void Tc006()
        {
            var wrapTrackShell = Get<IWrapTrackWebShell>();

            wrapTrackShell.Login();

            var me = wrapTrackShell.Me();
            var collection = me.GetCollection();

            StfAssert.IsNotNull("Got a MeProfile", me);
            StfAssert.IsNotNull("Got my collection", collection);

            var numBefore = collection.NumOfWraps();

            collection.AddWrap("Ali Dover", "Hygge", "blue");

            var numAfter = collection.NumOfWraps();

            StfAssert.AreEqual("One more wrap in collection", numBefore + 1, numAfter);
        }
    }
}
