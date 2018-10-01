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
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf.Utilities;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement;

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
            @"D:\Projects\WrapTrack.Stf\UnitTests\WrapTrackWebTests\Collection\AddCarrier\TestData\Testdata_add_ring_sling.csv",
            "Testdata_add_ring_sling#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Tc031()
        {
            var testdata = InitTestData<RingSlingTestData>();

            WrapTrackShell = Get<IWrapTrackWebShell>();

            // Use default user
            WrapTrackShell.Login();

            var me = WrapTrackShell.Me();
            var collection = me.GetCollection();
            var addCarrier = collection.AddCarrier<IWowenWrap>();

            StfAssert.IsTrue("HandleBrandProducedWrapFabric", HandleBrandProducedWrapFabric(addCarrier, testdata));
            StfAssert.IsTrue("HandleMadeOfWrap", HandleMadeOfWrap(addCarrier, testdata));
            StfAssert.IsTrue("HandleConvertedConvertTypeConvertName", HandleConvertedConvertTypeConvertName(addCarrier, testdata));
            StfAssert.IsTrue("HandleSizeGradeAcquired", HandleSizeGradeAcquired(addCarrier, testdata));
            StfAssert.IsTrue("Save", addCarrier.Save(testdata.Brand));

            // Log where we got redirected to - Page Safe is fine - Control is better:-)
            StfLogger.LogScreenshot(StfLogLevel.SubHeader, "After Pressed Save");
        }

        /// <summary>
        /// The handle made of wrap.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="testdata">
        /// The testdata.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool HandleMadeOfWrap(IWowenWrap addCarrier, RingSlingTestData testdata)
        {
            if (string.IsNullOrEmpty(testdata.MadeOfWrap))
            {
                // Mom I'm done!! - If not Converted...
                return true;
            }

            var retVal = addCarrier.SelectMadeOfWrap();

            return retVal;
        }

        /// <summary>
        /// The handle converted convert type convert name.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="testdata">
        /// The testdata.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool HandleConvertedConvertTypeConvertName(IWowenWrap addCarrier, RingSlingTestData testdata)
        {
            if (string.IsNullOrEmpty(testdata.Converted))
            {
                // Mom I'm done!! - If not Converted...
                return true;
            }

            addCarrier.Converted = true;
            addCarrier.ConvertType = testdata.ConvertType;
            addCarrier.ConvertName = testdata.ConvertName;

            return true;
        }

        /// <summary>
        /// The handle home made.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="testdata">
        /// The testdata.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool HandleBrandProducedWrapFabric(IWowenWrap addCarrier, RingSlingTestData testdata)
        {
            if (string.IsNullOrEmpty(testdata.BrandProduced))
            {
                BOB Select addCarrier.BOB = false;
            }
            else
            {
                BOB Select addCarrier.BOB = true;
            }

            if (string.IsNullOrEmpty(testdata.WrapFabric))
            {
                addCarrier.WrapFabric = false;
                addCarrier.Name = testdata.Name;
            }
            else
            {
                addCarrier.WrapFabric = true;
                HandleBrandPatternModel(addCarrier, testdata);
            }

            return true;
        }

        /// <summary>
        /// The brand pattern model.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="testdata">
        /// The testdata.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool HandleBrandPatternModel(IWowenWrap addCarrier, RingSlingTestData testdata)
        {
            if (string.IsNullOrEmpty(testdata.Brand))
            {
                // Mom I'm done!! - If no brand then pattern and model will never be shown
                return true;
            }

            addCarrier.Brand = testdata.Brand;
            addCarrier.Pattern = string.IsNullOrEmpty(testdata.Pattern)
                               ? "--- without pattern ---"
                               : testdata.Pattern;

            if (!string.IsNullOrEmpty(testdata.Model))
            {
                addCarrier.Model = testdata.Model;
            }

            return true;
        }

        /// <summary>
        /// The handle size grade acquired.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="testdata">
        /// The testdata.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool HandleSizeGradeAcquired(IWowenWrap addCarrier, RingSlingTestData testdata)
        {
            addCarrier.Grade = testdata.Grade;

            int daysOffSet;

            if (!int.TryParse(testdata.Acquired, out daysOffSet))
            {
                daysOffSet = 0;
            }

            var acquired = DateTime.Now.AddDays(daysOffSet);

            addCarrier.Acquired = acquired;

            return true;
        }
    }
}
