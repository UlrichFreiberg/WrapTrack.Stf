// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Brands.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the Brands type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Explore
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore.Brands;

    /// <summary>
    /// The brands.
    /// </summary>
    public class Brands : WrapTrackWebShellModelBase, IBrands
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Brands"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public Brands(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Gets or sets the all.
        /// </summary>
        public IAllBrands All()
        {
            var clicked = WebAdapter.ButtonClickByXpath("//a[normalize-space()='all']");
            var retVal = clicked? Get<IAllBrands>() : null;

            return retVal;
        }

        /// <summary>
        /// Gets or sets the add brand.
        /// </summary>
        /// <returns>
        /// The <see cref="IAddBrand"/>.
        /// </returns>
        public IAddBrand AddBrand()
        {
            var clicked = WebAdapter.ButtonClickByXpath("//a[normalize-space()='add brand']");
            var retVal = clicked ? Get<IAddBrand>() : null;
            
            return retVal;
        }
    }
}