// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Collection.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the LearnMore type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Me.Collection
{
    using System;
    using System.Drawing;

    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The learn more.
    /// </summary>
    public class Collection : WrapTrackWebShellModelBase, ICollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Collection"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public Collection(IWrapTrackWebShell wrapTrackWebShell)
           : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Counts number of wraps in collection
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int NumOfWraps()
        {
            var elements = WebAdapter.FindElements(By.Id("elem_wrap"));
            var retval = elements.Count;

            return retval;
        }

        /// <summary>
        /// Returns random wrap in collection.        
        /// </summary>
        /// <param name="wtIdContraint">
        /// Constrain the randomness to NOT return this wrap
        /// </param>
        /// <returns>
        /// The <see cref="IWrap"/>.
        /// </returns>
        public IWrap GetRandomWrap(string wtIdContraint = null)
        {
            var wrapElements = WebAdapter.FindElements(By.Id("lin_wrap"));
            var numberOfWraps = wrapElements.Count;
            var random = new Random();
            var wrapToChoose = random.Next(1, numberOfWraps + 1);
            var xpath = $"(//a[@id='lin_wrap'])[{wrapToChoose}]";
            var element = WebAdapter.FindElement(By.XPath(xpath));
            var linWrapText = element.Text;

            if (!string.IsNullOrEmpty(wtIdContraint)
                && numberOfWraps > 1
                && linWrapText.Equals(wtIdContraint, StringComparison.CurrentCultureIgnoreCase))
            {
                wrapToChoose = wrapToChoose == numberOfWraps ? 1 : wrapToChoose + 1;
                xpath = $"(//a[@id='lin_wrap'])[{wrapToChoose}]";
                element = WebAdapter.FindElement(By.XPath(xpath));
            }

            StfLogger.LogInfo($"We choose wrap number {wrapToChoose} (of {numberOfWraps}) - {linWrapText}");
            element.Click();

            var retVal = StfContainer.Get<IWrap>();

            return retVal;
        }

        /// <summary>
        /// Add a wrap to users own collection
        /// </summary>
        /// <param name="brand">
        /// The brand fx 'Artipoppe'
        /// </param>
        /// <param name="pattern">
        /// The pattern - fx 'Argus'
        /// </param>
        /// <param name="model">
        /// The model - fx 'The Queen'
        /// </param>
        /// <param name="size">
        /// The size of the wrap - fx 6
        /// </param>
        /// <returns>
        /// false if not possible
        /// </returns>
        public IWrap AddWrap(string brand = null, string pattern = null, string model = null, int size = 6)
        {
            ClickById("but_addwrap");
            ClickById("lin_newwrap");

            if (brand == null)
            {
                brand = "Didymos";
                pattern = "Nino";
                model = "Balu";
            }

            SelectDropdownByIdAndText("sel_brand", brand);
            SelectDropdownByIdAndText("sel_pattern", pattern);
            SelectDropdownByIdAndText("sel_model", model);
            SelectDropdownByIdAndText("vaelg_str", size.ToString());

            // add And Exit
            if (!WebAdapter.ButtonClickById("opretvikle1knap"))
            {
                return null;
            }

            var retVal = StfContainer.Get<IWrap>();

            return retVal;
        }

        /// <summary>
        /// The click by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        private void ClickById(string id)
        {
            var elem = WebAdapter.FindElement(By.Id(id));

            try
            {
                elem.Click();
            }
            catch
            {
                WebAdapter.MoveToElement(elem);
                elem.Click();
            }
        }

        /// <summary>
        /// The set text by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="brand">
        /// The brand.
        /// </param>
        private void SelectDropdownByIdAndText(string id, string brand)
        {
            // mostly for demo purposes - you can follow what happens
            WebAdapter.WaitForComplete(1);

            var elem = WebAdapter.FindElement(By.Id(id));

            elem.SendKeys(brand);
        }
    }
}
