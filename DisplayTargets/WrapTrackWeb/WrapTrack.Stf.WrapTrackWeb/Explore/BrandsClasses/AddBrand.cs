// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddBrand.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the AddBrand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Explore.BrandsClasses
{
    using OpenQA.Selenium;
    using System;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Brand;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore.Brands;

    /// <summary>
    /// The add brand.
    /// </summary>
    public class AddBrand : WrapTrackWebShellModelBase, IAddBrand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddBrand"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public AddBrand(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Open a registered brand.
        /// </summary>
        /// <param name="brandName">
        /// The brand name.
        /// </param>
        /// <returns>
        /// The <see cref="IBrand"/>.
        /// </returns>
        public IBrand OpenRegisteredBrand(string brandName)
        {
            var xPath = $"//a[text()='{brandName}']";
            var clicked = WebAdapter.Click(By.XPath(xPath));
            var retVal = clicked ? Get<IBrand>() : default(IBrand);

            return retVal;
        }

        /// <summary>
        /// Gets or sets the new brand name.
        /// </summary>
        public string NewBrandName
        {
            get
            {
                var retVal = WebAdapter.GetText(By.XPath("//input[@name='maerke']"));

                return retVal;
            }

            set
            {
                var results = WebAdapter.TextboxSetTextByXpath("//input[@name='maerke']", value);

                if(!results)
                {
                    throw new Exception("New brand Name textbox is not  found");
                }

            }
        }

        /// <summary>
        /// The save.
        /// </summary>
        /// <returns>
        /// The <see cref="IBrand"/>.
        /// </returns>
        public IBrand Save()
        {
            // TODO Introduce a SetCheckBoxById("bekraeft", true);
            var checkBoxChecked = WebAdapter.ButtonClickById("bekraeft");

            if (!checkBoxChecked)
            {
                return null;
            }

            var clicked = WebAdapter.ButtonClickById("save");
            var retVal = clicked
                       ? Get<IBrand>()
                       : null;

            return retVal;
        }
    }
}
