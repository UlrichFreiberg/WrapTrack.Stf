// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase031.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The Add Carrier - Ring Slings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection.AddCarrier
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf.Utilities;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    using WrapTrackWebTests.Collection.AddCarrier.TestData;

    /// <summary>
    /// The Add Carrier - Ring Sling.
    /// </summary>
    [TestClass]
    public class TestCase031 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The Ring Sling
        /// </summary>
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"D:\Projects\WrapTrack.Stf\UnitTests\WrapTrackWebTests\Collection\AddCarrier\TestData\TestdataAddWrapCOnversion.csv",
            "TestdataAddWrapConversion#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Tc031()
        {
            var testdata = InitTestData<TestDataAddWrapConversion>();

            WrapTrackShell = Get<IWrapTrackWebShell>();

            // Use default user
            WrapTrackShell.Login();

            var testCaseUtil = new TestCaseUtils(StfAssert);
            var addCarrier = testCaseUtil.GetAddCarrier(WrapTrackShell, testdata.CarrierType);

            StfAssert.IsTrue("HandleHomeMade", testCaseUtil.HandleHomeMade(addCarrier, testdata.HomeMade));

            testCaseUtil.HandleBrandCarriertypenicknameCarriermodel(
                addCarrier, 
                testdata.Brand, 
                testdata.CarrierTypeNickName, 
                testdata.CarrierModel);

            StfAssert.IsTrue("Save", addCarrier.Save());

            // Log where we got redirected to - Page Safe is fine - Control is better:-)
            StfLogger.LogScreenshot(StfLogLevel.SubHeader, "After Pressed Save");
        }
    }
}
