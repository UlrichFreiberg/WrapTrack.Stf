// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WrapTrackWebShell.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WrapTrackWebShell type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;


namespace WrapTrack.Stf.WrapTrackWeb
{
    using Mir.Stf.Utilities;
    using Mir.Stf.Utilities.Interfaces;

    using OpenQA.Selenium;
    using WrapTrack.Stf.Adapters.WebAdapter;
    using WrapTrack.Stf.WrapTrackWeb.Explore;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Me;

    using IMe = WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.IMe;

    /// <summary>
    /// The demo corp web shell.
    /// </summary>
    public class WrapTrackWebShell : IWrapTrackWebShell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrapTrackWebShell"/> class. 
        /// </summary>
        public WrapTrackWebShell()
        {
            Name = "WrapTrackWebShell";
            VersionInfo = new Version(1, 0, 0, 0);
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the version info.
        /// </summary>
        public Version VersionInfo { get; private set; }

        /// <summary>
        /// Gets or sets the stf container.
        /// </summary>
        public IStfContainer StfContainer { get; set; }

        /// <summary>
        /// Gets or sets the stf logger.
        /// </summary>
        public IStfLogger StfLogger { get; set; }

        /// <summary>
        /// Gets or sets the web adapter.
        /// </summary>
        public IWebAdapter WebAdapter { get; private set; }

        /// <summary>
        /// The learn more.
        /// </summary>
        /// <returns>
        /// Indication of success
        /// </returns>
        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        public bool Login(string userName = null, string password = null)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "ida88";
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                password = "wraptrack4ever";
            }

            var loginTabElem = WebAdapter.FindElement(By.Id("nav_login"));

            loginTabElem.Click();

            var userNameElem = WebAdapter.FindElement(By.Id("input_username"));

            userNameElem.Clear();
            userNameElem.SendKeys(userName);

            var passwordElem = WebAdapter.FindElement(By.Id("input_pw"));

            passwordElem.Clear();
            passwordElem.SendKeys(password);

            var loginButtonElem = WebAdapter.FindElement(By.Id("nav_"));

            loginButtonElem.Click();

            return true;
        }

        /// <summary>
        /// The sign up functionallity for new users
        /// </summary>
        public bool SignUp()
        {
            var loginTabElem = WebAdapter.FindElement(By.Id("nav_login"));

            loginTabElem.Click();

            var uniquePart = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(1,15);

            // Create (semi) random username
            var newUsername = $"TEST-{uniquePart}";
            var userNameElem = WebAdapter.FindElement(By.Id("input_newuser"));

            userNameElem.Clear();
            userNameElem.SendKeys(newUsername);

            var passwordElem = WebAdapter.FindElement(By.Id("input_newPW"));

            passwordElem.Clear();
            passwordElem.SendKeys("123456");

            var mailElem = WebAdapter.FindElement(By.Id("input_email"));

            mailElem.Clear();
            mailElem.SendKeys(newUsername + "@mitsite.org");

            var cond = WebAdapter.FindElement(By.Id("check_cond"));

            cond.Click();

            var SignUpButtonElem = WebAdapter.FindElement(By.Id("OpretProfilKnap"));

            SignUpButtonElem.Click();

            return true;
        }

        /// <summary>
        /// The init.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Init()
        {
            // register my needed types
            StfContainer.RegisterType<ICollection, Collection>();
            StfContainer.RegisterType<IMe, Me.Me>();
            StfContainer.RegisterType<IExplorer, Explorer>();
            StfContainer.RegisterType<IFaq, Faq.Faq>();

            // get what I need - a WebAdapter:-)
            WebAdapter = StfContainer.Get<IWebAdapter>();

            // LIVE:
            WebAdapter.OpenUrl("https://WrapTrack.org/");
            // TEST:
            //WebAdapter.OpenUrl("http://wt.troldvaerk.org/");


            var currentDomainBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            StfLogger.LogKeyValue("Current Directory", currentDomainBaseDirectory, "Current Directory");
            return true;
        }

        /// <summary>
        /// The collection.
        /// </summary>
        /// <returns>
        /// The <see cref="ICollection"/>.
        /// </returns>
        public ICollection Collection()
        {
            var but = WebAdapter.FindElement(By.Id("## MISSING ##"));
            but.Click();

            var retVal = StfContainer.Get<ICollection>();

            return retVal;
        }

        /// <summary>
        /// The me.
        /// </summary>
        /// <returns>
        /// The <see cref="IMe"/>.
        /// </returns>
        public IMe Me()
        {
            try
            {
                var but = WebAdapter.FindElement(By.Id("nav_profile"));

                but.Click();
            }
            catch (Exception)
            {
                return null;
            }

            var retVal = StfContainer.Get<IMe>();

            return retVal;

        }

        /// <summary>
        /// The explorer.
        /// </summary>
        /// <returns>
        /// The <see cref="IExplorer"/>.
        /// </returns>
        public IExplorer Explorer()
        {
            //throw new NotImplementedException();
            var link = WebAdapter.FindElement(By.Id("nav_expl"));
            link.Click();

            IExplorer retVal = StfContainer.Get<IExplorer>();

            return retVal;

        }

        /// <summary>
        /// The market.
        /// </summary>
        /// <returns>
        /// The <see cref="IMarket"/>.
        /// </returns>
        public IMarket Market()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The faq.
        /// </summary>
        /// <returns>
        /// The <see cref="IFaq"/>.
        /// </returns>
        public IFaq Faq()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The logout.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Logout()
        {
            var logoutButtonElem = WebAdapter.FindElement(By.Id("nav_logout"));

            logoutButtonElem?.Click();

            return true;
        }
    }
}
