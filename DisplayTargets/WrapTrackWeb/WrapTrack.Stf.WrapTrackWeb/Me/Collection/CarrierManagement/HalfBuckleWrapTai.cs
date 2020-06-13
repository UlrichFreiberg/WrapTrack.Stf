// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HalfBuckleWrapTai.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the HalfBuckleMeiTai type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me.Collection.CarrierManagement
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement;

    /// <summary>
    /// The HalfBuckleMeiTai wrap.
    /// </summary>
    public class HalfBuckleWrapTai : CarrierBaseClass, IHalfBuckleWrapTai
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HalfBuckleWrapTai"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public HalfBuckleWrapTai(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}
