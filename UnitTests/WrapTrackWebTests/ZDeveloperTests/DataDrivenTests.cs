// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataDrivenTests.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the UnitTest1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.ZDeveloperTests
{
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Mir.Stf;

    /// <summary>
    /// The menu tests.
    /// </summary>
    [TestClass]
    public class DataDrivenTests : StfTestScriptBase
    {
        /// <summary>
        /// The test initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
        }

        /// <summary>
        /// The test cleanup.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
        }

        /// <summary>
        /// The test top menu.
        /// </summary>
        // [DataSource(
        //    "System.Data.OleDb",
        //    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ZDeveloperTests\DataDrivenBob.xlsx;Persist Security Info=False;Extended Properties=""Excel 12.0 Xml;HDR=YES""", 
        //    "Ark1$", 
        //    DataAccessMethod.Sequential)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"ZDeveloperTests\DataDrivenBob.csv", "DataDrivenBob#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void DataDrivenOne()
        {
            var testdata = InitTestData<Bob>();

            StfLogger.LogInfo($"First = {testdata.First}");
            StfLogger.LogInfo($"Second = {testdata.Second}");
            StfLogger.LogInfo($"Third = {testdata.Third}");
        }
    }

    /// <summary>
    /// The bob.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    public class Bob : StfTestDataBase
    {
        /// <summary>
        /// Gets or sets the first.
        /// </summary>
        public string First { get; set; }

        /// <summary>
        /// Gets or sets the second.
        /// </summary>
        public string Second { get; set; }

        /// <summary>
        /// Gets or sets the third.
        /// </summary>
        public string Third { get; set; }
    }
}
