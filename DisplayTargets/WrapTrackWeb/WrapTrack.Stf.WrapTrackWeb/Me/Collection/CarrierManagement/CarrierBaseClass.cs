// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarrierBaseClass.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the CarrierBaseClass type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me.Collection.CarrierManagement
{
    /// <summary>
    /// The carrier base class.
    /// </summary>
    public class CarrierBaseClass
    {
        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the pattern.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the converted wrap.
        /// </summary>
        public string MadeOfWrap { get; set; }

        /// <summary>
        /// Gets or sets information: Is the carrier result of a convertion?
        /// </summary>
        public bool Converted { get; set; }

        /// <summary>
        /// Gets or sets type of converter.
        /// </summary>
        public string ConvertType { get; set; }

        /// <summary>
        /// Gets or sets type of name of converter.
        /// </summary>
        public string ConvertName { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// Gets or sets the acquired.
        /// </summary>
        public string Acquired { get; set; }
    }
}
