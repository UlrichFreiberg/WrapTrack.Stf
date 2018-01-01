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
        /// <returns>
        /// The <see cref="IWrap"/>.
        /// </returns>
        public IWrap GetRandomWrap()
        {
            var element = WebAdapter.FindElement(By.Id("lin_wrap"));

            element.Click();

            var retVal = StfContainer.Get<IWrap>();

            return retVal;
        }

        /// <summary>
        /// Add a wrap to users own collection
        /// </summary>
        /// <param name="brand">
        /// The brand.
        /// </param>
        /// <param name="pattern">
        /// The pattern.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// false if not possible
        /// </returns>
        public bool AddWrap(string brand = null, string pattern = null, string model = null)
        {
            ClickById("but_addwrap");
            ClickById("lin_newwrap");

            SelectDropdownByIdAndText("sel_brand", brand);
            SelectDropdownByIdAndText("sel_pattern", pattern);
            SelectDropdownByIdAndText("sel_model", model);
            SelectDropdownByIdAndText("vaelg_str", "2");

            // add And Exit
            ClickById("opretvikle1knap");

            return true;
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
