// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase010.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the CollectionTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;
    using WrapTrack.Stf.WrapTrackWeb.Me.Collection;

    /// <summary>
    /// Deleting wraps. Tests the possibility of deleting a wrap from users collection.
    /// There is more than one reason why the wrap should not be part of 
    /// the users collection any more.
    /// </summary>
    [TestClass]
    public class TestCase010 : WrapTrackTestScriptBase
    {
        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        private ICollection Collection { get; set; }

        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            WrapTrackShell = Get<IWrapTrackWebShell>();
            WrapTrackShell.Login();

            // Be sure we have enough wraps for all test instances
            Collection = GetCurrentUserCollection(WrapTrackShell);

            var numOfWraps = Collection.NumOfWraps(); 

            if (numOfWraps == 0)
            {
                Collection.AddWrap(); 
            }
        }

        /*
         * [DataSource(
        //    "System.Data.OleDb",
        //    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ZDeveloperTests\DataDrivenBob.xlsx;Persist Security Info=False;Extended Properties=""Excel 12.0 Xml;HDR=YES""", 
        //    "Ark1$", 
        //    DataAccessMethod.Sequential)]
        // TODO: Hardcoded path must be relative
        */

        /// <summary>
        /// The tc 010.
        /// </summary>
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "D:\\Projects\\WrapTrack.Stf\\UnitTests\\WrapTrackWebTests\\Collection\\Data010.csv",
             "Data010#csv",
             dataAccessMethod: DataAccessMethod.Sequential), TestMethod]
        public void Tc010()
        {
            var testdata = InitTestData<Params>();

            // Find a random wrap
            var ranWrap = Collection.GetRandomWrap();
            var wtId = ranWrap.WtId;

            StfAssert.IsNotNull("Got a random wrap", ranWrap);

            // Status of wrap before
            var validationTarget = Get<IWtApi>();
            var wrapInfo = validationTarget.WrapInfo(wtId);
            var statusBefore = wrapInfo.Status;

            StfAssert.AreEqual("Status before deleting is 0", statusBefore, "0");

            // Delete wrap
            StfLogger.LogInfo($"Option = {testdata.Option}");

            var deleted = ranWrap.Remove(testdata.Option);
            if (!deleted)
            {
                StfLogger.LogInfo("The Wrap was not deleted - this test iteration stops");
            }
            else
            {
                Wait(TimeSpan.FromSeconds(2));

                // Status of wrap after
                StfLogger.LogInfo($"StatusAfter = {testdata.StatusAfter}");
                wrapInfo = validationTarget.WrapInfo(wtId);
                StfAssert.AreEqual("Correct status after deleting", wrapInfo.Status, testdata.StatusAfter);
            }

            WrapTrackShell.Logout(); 
        }

        /// <summary>
        /// Gets data for datadriven test.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
        public class Params : StfTestDataBase
        {
            /// <summary>
            /// Gets or sets the first.
            /// </summary>
            public string StatusAfter { get; set; }

            /// <summary>
            /// Gets or sets the delete wrap option.
            /// </summary>
            public DeleteWrapOption Option { get; set; }
        }
    }
}
