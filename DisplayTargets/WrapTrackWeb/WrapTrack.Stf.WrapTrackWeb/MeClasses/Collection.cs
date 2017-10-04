// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Collection.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the LearnMore type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.MeClasses
{
    using Adapters.WebAdapter;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using System;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;

    /// <summary>
    /// The learn more.
    /// </summary>
    public class Collection : WrapTrackWebShellModelBase, ICollection
     {
        public Collection(IWrapTrackWebShell wrapTrackWebShell) : base(wrapTrackWebShell)
        {
        }

        public IWebDriver WebAdapter { get; private set; }

        /// <summary>
        /// Add a wrap to users own collection
        /// </summary>
        /// <returns>
        /// false if not possible
        /// </returns>
        public bool AddToCollection(string brand = null, string pattern = null, string model = null)
        {
            // var wrapTrackShell = Get<IWrapTrackWebShell>();

            var nav1 = base.WebAdapter.FindElement(By.Id("but_addwrap"));
            nav1.Click();

            var nav2 = base.WebAdapter.FindElement(By.Id("lin_newwrap"));
            nav2.Click();

            var BrandElem = base.WebAdapter.FindElement(By.Id("sel_brand"));
            var PatternElem = base.WebAdapter.FindElement(By.Id("sel_pattern"));
            var ModelElem = base.WebAdapter.FindElement(By.Id("sel_model"));
            var StrElement = base.WebAdapter.FindElement(By.Id("vaelg_str"));

            BrandElem.SendKeys(brand);
            PatternElem.SendKeys(pattern);
            ModelElem.SendKeys(model);
            StrElement.SendKeys("2"); // Random size. Allowed values -1, 1-9

            var AddAndExit = base.WebAdapter.FindElement(By.Id("opretvikle1knap"));
            
            //WebAdapter.WaitForComplete(8);
            //Actions actions = new Actions(WebAdapter); 
            //actions.MoveToElement(AddAndExit);

            AddAndExit.Click(); //TODO: FIX

            return true; 
        }

        private object Get<T>()
        {
            throw new NotImplementedException();
        }
    }
}
