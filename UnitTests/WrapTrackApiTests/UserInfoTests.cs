// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInfoTests.cs" company="Mir Software">
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
    /// The wrap info tests.
    /// </summary>
    [TestClass]
    public class UserInfoTests : StfTestScriptBase
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

        /// <summary>
        /// The test user id.
        /// </summary>
        [TestMethod]
        public void TestUserId()
        {
            var userId = wtApi.UserId("Ida88");

            StfAssert.StringEqualsCi("Ida/1356", "1356", userId);
        }

        /// <summary>
        /// The test user id.
        /// </summary>
        [TestMethod]
        public void TestUserName()
        {
            var userName = wtApi.UserName("1356");

            StfAssert.StringEqualsCi("Ida/1356", "Ida88", userName);
        }
    }
}