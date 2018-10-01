// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WovenTestData.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WovenTestData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection.AddCarrier.TestData
{
    using Mir.Stf;

    /// <summary>
    /// The woven test data.
    /// </summary>
    public class WovenTestData : StfTestDataBase
    {
        public string CarrierType { get; set; }
        public string Brand { get; set; }
        public string Pattern { get; set; }
        public string Model { get; set; }
        public string MadeOfWrap { get; set; }
        public string Converted { get; set; }
        public string ConvertType { get; set; }
        public string ConvertName { get; set; }
        public string Size { get; set; }
        public string Grade { get; set; }
        public string Acquired { get; set; }
        public string HomeMade { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
    }
}
