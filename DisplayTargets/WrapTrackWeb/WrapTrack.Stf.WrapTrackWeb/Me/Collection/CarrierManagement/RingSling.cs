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
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement;

    /// <summary>
    /// The ring sling.
    /// </summary>
    public class RingSling : CarrierBaseClass, IRingSling
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RingSling"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public RingSling(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

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

        /// <summary>
        /// Gets or sets the produced by.
        /// TODO: // Needs some JS implementation....
        /// </summary>
        public CarrierProducedBy ProducedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether shoulder right left.
        /// </summary>
        public bool ShoulderRightLeft { get; set; }

        /// <summary>
        /// Gets or sets the ring sling shoulder type.
        /// </summary>
        public RingSlingShoulderType RingSlingShoulderType { get; set; }
    }
}
