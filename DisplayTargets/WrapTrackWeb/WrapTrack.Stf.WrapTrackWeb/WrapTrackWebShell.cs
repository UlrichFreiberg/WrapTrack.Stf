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
    using OpenQA.Selenium;
    using WrapTrack.Stf.Adapters.WebAdapter;
    using WrapTrack.Stf.Core;
    using WrapTrack.Stf.WrapTrackWeb.Configuration;
    using WrapTrack.Stf.WrapTrackWeb.Explore;
    using WrapTrack.Stf.WrapTrackWeb.FaqContact;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.FaqContact;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;
    using WrapTrack.Stf.WrapTrackWeb.Me;
    using WrapTrack.Stf.WrapTrackWeb.Me.Collection;

    /// <summary>
    /// The demo corp web shell.
    /// </summary>
    public class WrapTrackWebShell : TargetBase, IWrapTrackWebShell
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
        /// Gets or sets the wt configuration.
        /// </summary>
        public WtConfiguration WtConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the web adapter.
        /// </summary>
        public IWebAdapter WebAdapter { get; set; }

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
            // Handle defaults for username password
            userName = HandleDefault(userName, WtConfiguration.UserName);
            password = HandleDefault(password, WtConfiguration.Password);

            // Click tab page Login
            WebAdapter.ButtonClickById("nav_login");

            // fill in creds
            WebAdapter.TextboxSetTextById("input_username", userName);
            WebAdapter.TextboxSetTextById("input_pw", password);

            // Click tab page Login
            WebAdapter.ButtonClickById("nav_");

            return true;
        }

        /// <summary>
        /// The sign up functionallity for new users
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SignUp()
        {
            // Create (semi) random username
            var uniquePart = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(1, 15);
            var newUsername = $"TEST-{uniquePart}";
            const string Password = "123456";

            WebAdapter.ButtonClickById("nav_login");
            WebAdapter.TextboxSetTextById("input_newuser", newUsername);
            WebAdapter.TextboxSetTextById("input_newPW", Password);
            WebAdapter.TextboxSetTextById("input_email", newUsername + "@mitsite.org");
            WebAdapter.ButtonClickById("check_cond");
            WebAdapter.ButtonClickById("OpretProfilKnap");

            // when debugging, we probably want to get to the signed up user 
            StfLogger.LogKeyValue("SignUpUserName", newUsername, "SignUpUserName");
            StfLogger.LogKeyValue("SignUpPassword", Password, "SignUpPassword");

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
        /// The <see cref="IMeProfile"/>.
        /// </returns>
        public IMeProfile Me()
        {
            var buttonClicked = WebAdapter.ButtonClickById("nav_profile");
            var retVal = buttonClicked 
                ? StfContainer.Get<IMeProfile>() 
                : null;

            return retVal;
        }

        /// <summary>
        /// The explorer.
        /// </summary>
        /// <returns>
        /// The <see cref="IExploreWraps"/>.
        /// </returns>
        public IExploreWraps Explorer()
        {
            WebAdapter.Click(By.Id("nav_expl"));

            var retVal = StfContainer.Get<IExploreWraps>();

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
        /// <param name="doCareAboutErrors">
        /// Mostly used in close down scenarios - there we just want to close down - not really caring about success or not
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Logout(bool doCareAboutErrors = true)
        {
            if (WebAdapter.Click(By.Id("nav_logout")))
            {
                return true;
            }

            if (doCareAboutErrors)
            {
                StfLogger.LogError("Got error while logging out");
            }

            // if we cant click the logout button, then the return value is down to if we care or not:-)
            return doCareAboutErrors;
        }

        /// <summary>
        /// The text-feedback to user 
        /// </summary>
        /// <param name="infoType">
        /// The info Type.
        /// </param>
        /// <returns>
        /// True if text-feedback found
        /// </returns>
        public bool InfoText(string infoType)
        {
            try
            {
                var svar = WebAdapter.FindElement(By.Id(infoType));
                var retVal = svar != null;

                return retVal;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Logout and Close down the web adapter
        /// </summary>
        public void CloseDown()
        {
            Logout(false);
            WebAdapter.CloseDown();
        }

        /// <summary>
        /// The init.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Init()
        {
            WtConfiguration = SetConfig<WtConfiguration>();
            RegisterMyNeededTypes();

            // get what I need - a WebAdapter:-)
            WebAdapter = StfContainer.Get<IWebAdapter>();

            WebAdapter.OpenUrl(WtConfiguration.Url);

            var currentDomainBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            StfLogger.LogKeyValue("Current Directory", currentDomainBaseDirectory, "Current Directory");
            return true;
        }

        /// <summary>
        /// The register my needed types.
        /// </summary>
        private void RegisterMyNeededTypes()
        {
            // Me classes
            StfContainer.RegisterType<IMeInbox, MeInbox>();
            StfContainer.RegisterType<IMeReviews, MeReviews>();
            StfContainer.RegisterType<IMeSettings, MeSettings>();
            StfContainer.RegisterType<ICollection, Collection>();
            StfContainer.RegisterType<IMeProfile, MeProfile>();
            StfContainer.RegisterType<IWrap, Wrap>();

            // Explorer
            StfContainer.RegisterType<IExploreBirthWraps, ExploreBirthWraps>();
            StfContainer.RegisterType<IExploreBrands, ExploreBrands>();
            StfContainer.RegisterType<IExploreModels, ExploreModels>();
            StfContainer.RegisterType<IExplorePatterns, ExplorePatterns>();
            StfContainer.RegisterType<IExploreUsers, ExploreUsers>();
            StfContainer.RegisterType<IExploreWraps, ExploreWraps>();

            // FAQ and contact classes
            StfContainer.RegisterType<IFaq, Faq>();
        }

        /// <summary>
        /// The handle default.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="defaultIfNull">
        /// The default if null.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string HandleDefault(string value, string defaultIfNull)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultIfNull;
            }

            return value;
        }
    }
}
