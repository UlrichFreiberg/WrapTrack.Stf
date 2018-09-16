// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddCarrier.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the AddCarrier type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me.Collection.CarrierManagement
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement;

    /// <summary>
    /// The add carrier.
    /// </summary>
    public class AddCarrier : WrapTrackWebShellModelBase, IAddCarrier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddCarrier"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public AddCarrier(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public IWowenWrap AddWowenWrap()
        {
            var retVal = Get<IWowenWrap>();

            return retVal;
        }

        /// <summary>
        /// The add stretchy wrap.
        /// </summary>
        /// <returns>
        /// The <see cref="StretchyWrap"/>.
        /// </returns>
        public IStretchyWrap AddStretchyWrap()
        {
            var retVal = Get<IStretchyWrap>();

            return retVal;
        }

        /// <summary>
        /// The add ring sling.
        /// </summary>
        /// <returns>
        /// The <see cref="RingSling"/>.
        /// </returns>
        public IRingSling AddRingSling()
        {
            var retVal = Get<IRingSling>();

            return retVal;
        }
    }
}
