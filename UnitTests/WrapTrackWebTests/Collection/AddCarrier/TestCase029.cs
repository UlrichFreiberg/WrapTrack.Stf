// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase029.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The menu tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection.AddCarrier
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf.Utilities;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement;

    using WrapTrackWebTests.ZDeveloperTests.Ulrich;

    /// <summary>
    /// The menu tests.
    /// </summary>
    [TestClass]
    public class TestCase029 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// The add woven.
        /// </summary>
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"D:\Projects\WrapTrack.Stf\UnitTests\WrapTrackWebTests\Collection\AddCarrier\Testdata_add_woven_wrap.csv",
            "Testdata_add_woven_wrap#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void Tc029()
        {
            var testdata = InitTestData<WovenTestData>();
            var wrapTrackWebShell = Get<IWrapTrackWebShell>();

            // Use default user
            wrapTrackWebShell.Login();

            var me = wrapTrackWebShell.Me();
            var collection = me.GetCollection();
            var addCarrier = collection.AddCarrier<IWowenWrap>();

            StfAssert.IsTrue("HandleHomeMade", HandleHomeMade(addCarrier, testdata));
            StfAssert.IsTrue("HandleBrandPatternModel", HandleBrandPatternModel(addCarrier, testdata));
            StfAssert.IsTrue("HandleMadeOfWrap", HandleMadeOfWrap(addCarrier, testdata));
            StfAssert.IsTrue("HandleConvertedConvertTypeConvertName", HandleConvertedConvertTypeConvertName(addCarrier, testdata));
            StfAssert.IsTrue("HandleSizeGradeAcquired", HandleSizeGradeAcquired(addCarrier, testdata));
            StfAssert.IsTrue("Save", addCarrier.Save(testdata.Brand));

            // Log where we got redirected to - Page Safe is fine - Control is better:-)
            StfLogger.LogScreenshot(StfLogLevel.SubHeader, "After Pressed Save");
            wrapTrackWebShell.CloseDown();
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
        private bool HandleMadeOfWrap(IWowenWrap addCarrier, WovenTestData testdata)
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
        private bool HandleConvertedConvertTypeConvertName(IWowenWrap addCarrier, WovenTestData testdata)
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
        private bool HandleHomeMade(IWowenWrap addCarrier, WovenTestData testdata)
        {
            if (string.IsNullOrEmpty(testdata.HomeMade))
            {
                addCarrier.HomeMade = false;

                return true;
            }

            addCarrier.HomeMade = true;
            addCarrier.Name = $"MyOwn_{Guid.NewGuid()}";

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
        private bool HandleBrandPatternModel(IWowenWrap addCarrier, WovenTestData testdata)
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
        private bool HandleSizeGradeAcquired(IWowenWrap addCarrier, WovenTestData testdata)
        {
            addCarrier.Size = testdata.Size;
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
