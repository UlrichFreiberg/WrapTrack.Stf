// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarrierBaseClass.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the CarrierBaseClass type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me.Collection.CarrierManagement
{
    using System;

    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The carrier base class.
    /// </summary>
    public class CarrierBaseClass : WrapTrackWebShellModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CarrierBaseClass"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public CarrierBaseClass(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        public string Brand
        {
            get
            {
                var retVal = WebAdapter.SelectElementGetText(By.Id("sel_brand"));

                return retVal;
            }

            set
            {
                WebAdapter.SelectElementSetText(By.Id("sel_brand"), value);
            }
        }

        /// <summary>
        /// Gets or sets the pattern.
        /// </summary>
        public string Pattern
        {
            get
            {
                var retVal = WebAdapter.SelectElementGetText(By.Id("sel_pattern"));

                return retVal;
            }

            set
            {
                WebAdapter.SelectElementSetText(By.Id("sel_pattern"), value);
            }
        }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        public string Model
        {
            get
            {
                var retVal = WebAdapter.SelectElementGetText(By.Id("sel_model"));

                return retVal;
            }

            set
            {
                WebAdapter.SelectElementSetText(By.Id("sel_model"), value);
            }
        }

        /// <summary>
        /// Gets or sets the converted wrap.
        /// </summary>
        public string MadeOfWrap
        {
            get
            {
                var retVal = WebAdapter.SelectElementGetText(By.Id("selConvertSuggestions"));

                return retVal;
            }

            set
            {
                WebAdapter.SelectElementSetText(By.Id("selConvertSuggestions"), value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether converted. Is the carrier result of a convertion?
        /// </summary>
        public bool Converted
        {
            get
            {
                var retVal = WebAdapter.CheckBoxGetValueByXpath("//span[text()='Converted by a private person or sling converter']/../input");

                return retVal;
            }

            set
            {
                WebAdapter.CheckBoxSetValueByXpath("//span[text()='Converted by a private person or sling converter']/../input", value);
            }
        }

        /// <summary>
        /// Gets or sets type of converter.
        /// </summary>
        public string ConvertType
        {
            get
            {
                var retVal = WebAdapter.SelectElementGetText(By.Id("selConvertType"));

                return retVal;
            }

            set
            {
                WebAdapter.SelectElementSetText(By.Id("selConvertType"), value);
            }
        }

        /// <summary>
        /// Gets or sets type of name of converter.
        /// </summary>
        public string ConvertName
        {
            get
            {
                var retVal = WebAdapter.GetText(By.Id("soegBruger"));

                return retVal;
            }

            set
            {
                WebAdapter.TextboxSetTextById("soegBruger", value);
                WebAdapter.ButtonClickById("butThisConverter");
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public string Size
        {
            get
            {
                var retVal = WebAdapter.SelectElementGetText(By.Id("selWrapSize"));

                return retVal;
            }

            set
            {
                WebAdapter.SelectElementSetText(By.Id("selWrapSize"), value);
            }
        }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        public string Grade
        {
            get
            {
                var retVal = WebAdapter.SelectElementGetText(By.Id("selGrade"));

                return retVal;
            }

            set
            {
                WebAdapter.SelectElementSetText(By.Id("selGrade"), value);
            }
        }

        /// <summary>
        /// Gets or sets the acquired.
        /// </summary>
        public DateTime Acquired
        {
            get
            {
                return DateTime.Now; // TODO: make real implementation
            }

            set
            {
                var dayOfMonth = value.Day.ToString();
                var month = value.Month;
                var year = value.Year;

                WebAdapter.SelectElementSetText(By.Id("selPurchasedDay"), dayOfMonth);
                // TODO: make missing implementation - year and month
            }
        }

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="brandName">
        /// The brand Name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Save(string brandName = null)
        {
            WebAdapter.WaitForComplete(10);

            var retVal = WebAdapter.ButtonClickById("but_add_wrap");

            AfterSavePageCheck(brandName);

            return retVal;
        }

        /// <summary>
        /// The page check. Are we on the AddCarrier page or not
        /// </summary>
        /// <param name="brandName">
        /// The brand Name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AfterSavePageCheck(string brandName = null)
        {
            bool retVal;

            WebAdapter.WaitForComplete(3);

            if (string.IsNullOrEmpty(brandName))
            {
                var elem = WebAdapter.FindElement(By.XPath("//h1[text()='Add carrier']"), 1);

                retVal = elem != null;

                return retVal;
            }

            var labelElem = WebAdapter.FindElement(By.Id("lin_brand"));
            var brandLabelText = labelElem?.Text ?? string.Empty;

            retVal = string.Equals(brandName, brandLabelText, StringComparison.InvariantCultureIgnoreCase);

            return retVal;
        }
    }
}
