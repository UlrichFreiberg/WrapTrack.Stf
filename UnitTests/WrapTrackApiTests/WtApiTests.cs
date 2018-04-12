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
        /// The wt api.
        /// </summary>
        private IWtApi wtApi;

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            wtApi = Get<IWtApi>();
        }
    }
}
