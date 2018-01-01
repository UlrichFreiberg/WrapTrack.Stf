// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WtApiTests.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WtApiTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackApiTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf;
    using WrapTrack.Stf.WrapTrackApi.Interfaces;

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
            var wtApi = Get<IWtApi>();
            var wrapInfo = wtApi.WrapInfo("13639");

            StfAssert.AreEqual("13639 owner", "Beinta.klein", wrapInfo.OwnerName);
            StfAssert.AreEqual("13639 id", "1603", wrapInfo.OwnerId);
        }
    }
}
