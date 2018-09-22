// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WowenWrap.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the StretchyWrap type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me.Collection.CarrierManagement
{
    using System;

    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement;

    /// <summary>
    /// The stretchy wrap.
    /// </summary>
    public class WowenWrap : CarrierBaseClass, IWowenWrap
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WowenWrap"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public WowenWrap(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
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
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                var retVal = WebAdapter.GetText(By.Id("inpNameHomemade"));

                return retVal;
            }

            set
            {
                WebAdapter.TextboxSetTextById("inpNameHomemade", value);
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
    }
}
