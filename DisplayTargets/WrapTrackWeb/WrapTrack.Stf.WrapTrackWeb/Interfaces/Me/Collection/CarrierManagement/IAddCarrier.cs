// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAddCarrier.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the IAddCarrier type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement
{
    using WrapTrack.Stf.WrapTrackWeb.Me.Collection.CarrierManagement;

    /// <summary>
    /// The AddCarrier interface.
    /// </summary>
    public interface IAddCarrier
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        IWowenWrap AddWowenWrap();

        /// <summary>
        /// The add stretchy wrap.
        /// </summary>
        /// <returns>
        /// The <see cref="StretchyWrap"/>.
        /// </returns>
        IStretchyWrap AddStretchyWrap();

        /// <summary>
        /// The add ring sling.
        /// </summary>
        /// <returns>
        /// The <see cref="RingSling"/>.
        /// </returns>
        IRingSling AddRingSling();
    }
}