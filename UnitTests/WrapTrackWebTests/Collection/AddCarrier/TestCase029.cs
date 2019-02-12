// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase029.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The Add Carrier - Woven tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection.AddCarrier
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf.Utilities;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement;

    using WrapTrackWebTests.Collection.AddCarrier.TestData;

    /// <summary>
    /// The Add Carrier - Woven tests.
    /// </summary>
    [TestClass]
    public class TestCase029 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The add wrap. Houses woven wrap, stretch wrap and hyvrid wrap
        /// </summary>
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"D:\Projects\WrapTrack.Stf\UnitTests\WrapTrackWebTests\Collection\AddCarrier\TestData\TestdataAddWrap.csv",
            "TestdataAddWrap#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Tc029()
        {
            var testdata = InitTestData<TestDataAddWrap>();

            WrapTrackShell = Get<IWrapTrackWebShell>();

            // Use default user
            WrapTrackShell.Login();

            var testCaseUtil = new TestCaseUtils(StfAssert);
            var addCarrier = testCaseUtil.GetAddCarrier<ICarrierBase>(WrapTrackShell, testdata.CarrierType);

            StfAssert.IsTrue("HandleHomeMade", testCaseUtil.HandleHomeMade(addCarrier, testdata.HomeMade));

            testCaseUtil.HandleBrandPatternModel(
                addCarrier,
                testdata.Brand,
                testdata.Pattern,
                testdata.Model);

            testCaseUtil.HandleMadeOfWrap(
                addCarrier,
                testdata.MadeOfWrap);

            testCaseUtil.HandleConvertedConvertTypeConvertName(
                addCarrier,
                testdata.Converted,
                testdata.ConvertType,
                testdata.ConvertName);

            testCaseUtil.HandleSizeGradeAcquired(
                addCarrier,
                testdata.Size,
                testdata.Grade,
                testdata.Acquired);

            StfAssert.IsTrue("Save", addCarrier.Save());

            // Log where we got redirected to - Page Safe is fine - Control is better:-)
            StfLogger.LogScreenshot(StfLogLevel.SubHeader, "After Pressed Save");
        }
    }
}
