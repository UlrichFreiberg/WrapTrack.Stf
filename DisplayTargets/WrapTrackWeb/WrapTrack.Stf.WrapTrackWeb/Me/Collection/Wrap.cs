// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Wrap.cs" company="Mir Software">
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

    /// <summary>
    /// The learn more.
    /// </summary>
    public class Wrap : WrapTrackWebShellModelBase, IWrap
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Wrap"/> class. 
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public Wrap(IWrapTrackWebShell wrapTrackWebShell)
           : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Gets or sets the patterns.
        /// </summary>
        public int Patterns { get; set; }

        /// <summary>
        /// Gets or sets the models.
        /// </summary>
        public int Models { get; set; }

        /// <summary>
        /// Gets or sets the wraps.
        /// </summary>
        public int Wraps { get; set; }

        /// <summary>
        /// Gets the wt id.
        /// </summary>
        public string WtId
        {
            get
            {
                const string Xpath = "//p[starts-with(normalize-space(),'Wraptrack-ID')]/span";
                var retVal = WebAdapter.GetText(By.XPath(Xpath));

                retVal = retVal.Trim();

                return retVal;
            }
        }

        /// <summary>
        /// Pass on the wrap to user 'username'
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool PassOn(string username)
        {
            // click the Pass On Button in the menu
            if (!WebAdapter.ButtonClickByXpath("//knap_videregivvikle/div[1]/knap_basis/button/p/span[2]/span"))
            {
                return false;
            }

            if (!WebAdapter.TextboxSetTextById("inputBrugerSoeg", username))
            {
                return false;
            }

            // click the select user button
            if (!WebAdapter.ButtonClickById("but_selUser"))
            {
                return false;
            }

            // answer the R U sure
            if (!WebAdapter.ButtonClickById("but_goPassOn"))
            {
                return false;
            }
            
            return true; 
        }
    }
}
