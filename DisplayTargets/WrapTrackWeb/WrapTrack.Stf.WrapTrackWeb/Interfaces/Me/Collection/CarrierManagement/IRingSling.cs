// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRingSling.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IRingSling type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement
{
    using WrapTrack.Stf.WrapTrackWeb.Me.Collection.CarrierManagement;

    /// <summary>
    /// The RingSling interface.
    /// </summary>
    public interface IRingSling : ICarrierBase
    {
        /// <summary>
        /// Gets or sets the produced by.
        /// </summary>
        CarrierProducedBy ProducedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether brand produced.
        /// </summary>
        bool BrandProduced { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether woven wrap fabric is used.
        /// </summary>
        bool WovenWrapFabric { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether shoulder right left.
        /// </summary>
        bool ShoulderRightLeft { get; set; }

        /// <summary>
        /// Gets or sets the ring sling shoulder type.
        /// </summary>
        RingSlingShoulderType RingSlingShoulderType { get; set; }
    }
}