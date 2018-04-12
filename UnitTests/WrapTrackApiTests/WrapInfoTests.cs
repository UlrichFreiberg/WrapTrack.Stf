// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WrapInfoTests.cs" company="Mir Software">
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
    using WrapTrack.Stf.WrapTrackApi.Wrap;

    /// <summary>
    /// The wrap info tests.
    /// </summary>
    [TestClass]
    public class WrapInfoTests : StfTestScriptBase
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
        /// The test basic wrap info.
        /// </summary>
        [TestMethod]
        public void TestBasicWrapInfoByInteralId()
        {
            var wrapInfo = wtApi.WrapInfoByInternalId("13639");

            ValidateWrap13639(wrapInfo);
        }

        /// <summary>
        /// The test basic wrap info by track id.
        /// </summary>
        [TestMethod]
        public void TestBasicWrapInfoByTrackId()
        {
            var wrapInfo = wtApi.WrapInfoByTrackId("ks0etu1");

            ValidateWrap13639(wrapInfo);
        }

        /// <summary>
        /// The validate wrap 13639.
        /// </summary>
        /// <param name="wrapInfo">
        /// The wrap info.
        /// </param>
        private void ValidateWrap13639(WrapInfo wrapInfo)
        {
            StfAssert.AreEqual("OwnerId", "1603", wrapInfo.OwnerId);
            StfAssert.AreEqual("OwnerName", "Beinta.klein", wrapInfo.OwnerName);
            StfAssert.AreEqual("NumOfOwnershipPic", 0, wrapInfo.NumOfOwnershipPic);
            StfAssert.AreEqual("NumOfPictures", 0, wrapInfo.NumOfPictures);
            StfAssert.AreEqual("OwnershipNumber", "1", wrapInfo.OwnershipNumber);
            StfAssert.AreEqual("Size", "13639", wrapInfo.Size);
            StfAssert.AreEqual("Status", "0", wrapInfo.Status);
        }
    }
}