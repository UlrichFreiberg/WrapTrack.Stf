// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestDataAddWrapConversion.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the TestDataAddWrapConversion type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection.AddCarrier.TestData
{
    using Mir.Stf;

    /// <summary>
    /// The Add Wrap Conversion test data.
    /// </summary>
    public class TestDataAddWrapConversion : TestDataBase
    {
        /// <summary>
        /// Gets or sets the shoulder type.
        /// </summary>
        public string ShoulderType { get; set; }

        public string CarrierTypeNickName { get; set; }

        public string CarrierModel { get; set; }
    }
}
