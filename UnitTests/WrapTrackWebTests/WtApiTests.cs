// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WtApiTests.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WtApiTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WrapTrackWebTests
{
    using Mir.Stf;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.WtRestApi;

    /// <summary>
    /// The wt api tests.
    /// </summary>
    [TestClass]
    public class WtApiTests : StfTestScriptBase
    {
        /// <summary>
        /// The test basic wrap info.
        /// </summary>
        [TestMethod]
        public void TestBasicWrapInfo()
        {
            // right now the registration of the interface is hosted in the webShell
            Get<IWrapTrackWebShell>();

            var wtApi = Get<IWtApi>();
            var wrapInfo = wtApi.WrapInfo("13639");

            StfAssert.AreEqual("13639 owner", "Beinta.klein", wrapInfo.OwnerName);
            StfAssert.AreEqual("13639 id", "1603", wrapInfo.OwnerId);
        }
    }
}
