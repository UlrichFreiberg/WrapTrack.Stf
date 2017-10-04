// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionTests.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the CollectionTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mir.Stf;
using WrapTrack.Stf.WrapTrackWeb.Interfaces;

namespace WrapTrackWebTests
{
    /// <summary>
    /// The collection tests.
    /// </summary>
    [TestClass]
    public class CollectionTests : StfTestScriptBase
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
            var collection = me.Get_Collection(); 

            StfAssert.IsNotNull("Got a Me", me);
            StfAssert.IsNotNull("Got my collection", collection);

            collection.AddToCollection("Ali Dover", "Hygge", "blue"); 
        }
    }
}
