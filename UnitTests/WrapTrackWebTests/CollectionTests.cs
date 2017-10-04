using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mir.Stf;
using WrapTrack.Stf.WrapTrackWeb.Interfaces;

namespace WrapTrackWebTests
{
    [TestClass]
    public class CollectionTests : StfTestScriptBase
    {
        [TestMethod]
        public void TC006()
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
