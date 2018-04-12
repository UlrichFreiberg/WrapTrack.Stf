// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AllBrands.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the AllBrands type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Explore.BrandsClasses
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore.Brands;

    /// <summary>
    /// The all brands.
    /// </summary>
    public class AllBrands : WrapTrackWebShellModelBase, IAllBrands
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllBrands"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public AllBrands(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Gets or sets the new brand name.
        /// </summary>
        public string NewBrandName { get; set; }
    }
}
