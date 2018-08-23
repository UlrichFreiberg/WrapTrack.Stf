// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RingSling.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the RingSling type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me.Collection.CarrierManagement
{
    /// <summary>
    /// The ring sling.
    /// </summary>
    public class RingSling : CarrierBaseClass
    {
        /// <summary>
        /// Gets or sets a value indicating whether brand produced.
        /// </summary>
        public bool BrandProduced { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether woven wrap fabric is used.
        /// </summary>
        public bool WovenWrapFabric { get; set; }

        /// <summary>
        /// Gets or sets a name for a ring sling not not made of woven wrap fabric.
        /// </summary>
        public string Name { get; set; }

    }
}
