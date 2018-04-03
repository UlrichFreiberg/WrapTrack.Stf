// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase012.cs" company="Mir Software">
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

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// Test of letting a wrap pass on from one user to another. 
    /// Another user initiatives this action.
    /// Default date.
    /// </summary>
    [TestClass]
    public class TestCase012 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The TC012.
        /// </summary>
        [TestMethod]
        public void Tc012()
        {

            // User #1: Add a wrap
            WrapTrackShell = Get<IWrapTrackWebShell>();

            WrapTrackShell.Login(); // Default user
            var collection = GetCurrentUserCollection();

            // Find a random wrap
            var wrapToGo = collection.GetRandomWrap(); 
            var wtId = wrapToGo.WtId;

            WrapTrackShell.Logout();

            // user #2 want the wrap
            var anotherUser = GetAnotherUser(WrapTrackShell);

            WrapTrackShell.Login(anotherUser);

            var DesiredWrap = WrapTrackShell.GetToWrap(wtId);
            DesiredWrap.AskFor();

            WrapTrackShell.Logout();

            // User #1: Lets wrap go
            WrapTrackShell = Get<IWrapTrackWebShell>();
            WrapTrackShell.Login(); // Default user

            // Assert: Der er en anmodning på nyhedssiden, hvor man lander efter login 
            // Vises ved link med teksten 'You have 1 pending request' (evt X pending requests)

            // Bruger klikker og kommer til request side, hvor hun godkender reqest fra bruger #2

        }
    }
}
