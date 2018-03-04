// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Explore.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the Explore type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Explore
{
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore.Wraps;

    /// <summary>
    /// The explorer tab page - wraps section.
    /// </summary>
    public class Explore : WrapTrackWebShellModelBase, IExplore
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Explore"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public Explore(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Gets the wrap.
        /// </summary>
        /// <returns>
        /// The <see cref="IWraps"/>.
        /// </returns>
        public IWraps Wraps()
        {
            var gone = GoMenu("wraps");
            var retVal = gone
                       ? Get<IWraps>()
                       : default(IWraps);

            return retVal;
        }

        /// <summary>
        /// Gets the brands.
        /// </summary>
        /// <returns>
        /// The <see cref="IBrands"/>.
        /// </returns>
        public IBrands Brands()
        {
            var gone = GoMenu("brands");
            var retVal = gone
                       ? Get<IBrands>()
                       : default(IBrands);

            return retVal;
        }

        /// <summary>
        /// The go menu.
        /// </summary>
        /// <param name="menuName">
        /// The menu name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool GoMenu(string menuName)
        {
            var xpath = $"//div[@class='submenu2']/a[text()='{menuName}']";
            var retVal = WebAdapter.ButtonClickByXpath(xpath);

            return retVal;
        }
    }
}