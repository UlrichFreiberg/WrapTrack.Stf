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
        /// Gets or sets the carrier model.
        /// </summary>
        public string CarrierModel
        {
            get
            {
                var retVal = WebAdapter.SelectElementGetText(By.Id("sel_carrier_model"));

                return retVal;
            }

            set
            {
                WebAdapter.SelectElementSetText(By.Id("sel_carrier_model"), value);
            }
        }

        /// <summary>
        /// Gets or sets the carrier type.
        /// </summary>
        public string CarrierType
        {
            get
            {
                var retVal = WebAdapter.SelectElementGetText(By.Id("sel_carrier_type"));

                return retVal;
            }

            set
            {
                WebAdapter.SelectElementSetText(By.Id("sel_carrier_type"), value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether home made.
        /// </summary>
        public bool HomeMade
        {
            get
            {
                var retVal = WebAdapter.CheckBoxGetValueById("checkHomemade");

                return retVal;
            }

            set
            {
                WebAdapter.CheckBoxSetValueById("checkHomemade", value);
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
                var retVal = WebAdapter.CheckBoxGetValueByXpath("//span[text()='The wrap has been converted from another wrap']/../input");

                return retVal;
            }

            set
            {
                WebAdapter.CheckBoxSetValueByXpath("//span[text()='The wrap has been converted from another wrap']/../input", value);
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
                // in some circumstances the name makes no sense - like when converter type is "unknown"
                // Leaving it up to the test script to decide!
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

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
        /// The select made of wrap.
        /// </summary>
        /// <param name="wrapName">
        /// The wrap name. If null, then pick a random one in the list
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SelectMadeOfWrap(string wrapName = null)
        {
            var wrapToChose = wrapName;
            var selectElem = WebAdapter.FindElement(By.Id("selConvertSuggestions"));

            if (selectElem == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(wrapToChose))
            {
                // Okay no name given - we will pick a random one...
                var options = selectElem.FindElements(By.XPath("./option"));
                var numberOfOptions = options.Count;

                if (numberOfOptions < 1)
                {
                    return false;
                }

                var numberToChoose = new Random().Next(2, numberOfOptions);

                wrapToChose = options[numberToChoose].Text.Trim();
            }

            var retVal = WebAdapter.SelectElementSetText(By.Id("selConvertSuggestions"), wrapToChose);

            return retVal;
        }

        /// <summary>
        /// The save.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Save()
        {
            WebAdapter.WaitForComplete(10);

            var retVal = WebAdapter.ButtonClickById("but_add_wrap");

            if (!retVal)
            {
                return false;
            }

            retVal = AfterSavePageCheck();

            return retVal;
        }

        /// <summary>
        /// The page check. Are we on the AddCarrier page or not
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AfterSavePageCheck()
        {
            // TODO: Retrier: Wait 3 seconds for this to GO away.. Not check if it is there
            System.Threading.Thread.Sleep(2000);

            var elem = WebAdapter.FindElement(By.XPath("//h1[text()='Add carrier']"), 3);
            var retVal = elem == null;

            return retVal;
        }
    }
}
