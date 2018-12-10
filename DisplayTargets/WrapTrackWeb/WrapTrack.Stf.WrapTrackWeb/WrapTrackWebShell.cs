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
using System.Collections.Generic;

namespace WrapTrack.Stf.WrapTrackWeb
{
    using OpenQA.Selenium;
    using WrapTrack.Stf.Adapters.WebAdapter;
    using WrapTrack.Stf.Core;
    using WrapTrack.Stf.WrapTrackWeb.Configuration;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Explore;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.FaqContact;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

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
        /// Gets or sets the current logged in user.
        /// </summary>
        public string CurrentLoggedInUser { get; set; }

        /// <summary>
        /// The login as admin. 
        /// Using the same Login routine as a normal login, but with different username password
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool LoginAsAdmin(string userName = null, string password = null)
        {
            // Handle defaults for username password
            userName = HandleDefault(userName, WtConfiguration.AdminUserName);
            password = HandleDefault(password, WtConfiguration.AdminPassword);

            var retVal = Login(userName, password);

            return retVal;
        }

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

            // Remember the last logged in user
            CurrentLoggedInUser = userName;

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
            const string Password = "123456";
            var newUsername = WtUtils.GetRandomUsername();

            return SignUp(newUsername, Password);
        }

        /// <summary>
        /// The sign up.
        /// </summary>
        /// <param name="newUserName">
        /// The new user name.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SignUp(string newUserName, string password)
        {
            WebAdapter.ButtonClickById("nav_login");
            WebAdapter.TextboxSetTextById("input_newuser", newUserName);
            WebAdapter.TextboxSetTextById("input_newPW", password);
            WebAdapter.TextboxSetTextById("input_email", newUserName + "@mitsite.org");
            WebAdapter.CheckBoxSetValueById("check_cond", true);
            WebAdapter.ButtonClickById("OpretProfilKnap");

            // when debugging, we probably want to get to the signed up user 
            StfLogger.LogKeyValue("SignUpUserName", newUserName, "SignUpUserName");
            StfLogger.LogKeyValue("SignUpPassword", password, "SignUpPassword");

            return CheckSignUpValidationMessages();
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
            // press the top menu tab
            var buttonClicked = WebAdapter.ButtonClickById("nav_me");

            if (!buttonClicked)
            {
                return null;
            }

            // when number of wraps is high, the rendering might take some time...
            // TODO: Implement using Selenium Waiter
            WebAdapter.WaitForComplete(5);

            // press the second level top menu tab - called "profile"
            buttonClicked = WebAdapter.ButtonClickById("nav_profile");

            var retVal = buttonClicked
                ? StfContainer.Get<IMeProfile>()
                : null;

            return retVal;
        }

        /// <summary>
        /// The explorer.
        /// </summary>
        /// <returns>
        /// The <see cref="IExplore"/>.
        /// </returns>
        public IExplore Explore()
        {
            var clicked = WebAdapter.ButtonClickById("nav_explore");
            var retVal = clicked
                       ? StfContainer.Get<IExplore>()
                       : null;

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
        /// The get to wrap.
        /// </summary>
        /// <param name="wrapId">
        /// The wrap id.
        /// </param>
        /// <returns>
        /// The <see cref="IWrap"/>.
        /// </returns>
        public IWrap GetToWrap(string wrapId)
        {
            var baseUrl = WtConfiguration.Url;
            var wrapIdUrl = $"{baseUrl}Collection/wrap/{wrapId}";

            WebAdapter.OpenUrl(wrapIdUrl);

            var retVal = StfContainer.Get<IWrap>();

            return retVal;
        }

        /// <summary>
        /// The get to model.
        /// </summary>
        /// <param name="modelId">
        /// The model id.
        /// </param>
        /// <returns>
        /// The <see cref="IModel"/>.
        /// </returns>
        public IModel GetToModel(string modelId)
        {
            var baseUrl = WtConfiguration.Url;
            var modelIdUrl = $"{baseUrl}Catalog/model/{modelId}";

            WebAdapter.OpenUrl(modelIdUrl);

            var retVal = StfContainer.Get<IModel>();

            return retVal;
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
            var registerMyNeededTypes = new RegisterMyNeededTypes(this);

            registerMyNeededTypes.Register();
            WtConfiguration = SetConfig<WtConfiguration>();

            // get what I need - a WebAdapter:-)
            WebAdapter = StfContainer.Get<IWebAdapter>();

            WebAdapter.OpenUrl(WtConfiguration.Url);

            var currentDomainBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            StfLogger.LogKeyValue("Current Directory", currentDomainBaseDirectory, "Current Directory");
            return true;
        }
        
        /// <summary>
        /// The sign up and login.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SignUpAndLogin()
        {
            try
            {
                const string Password = "123456";
                var newUsername = WtUtils.GetRandomUsername();

                var signUpNewUser = SignUp(newUsername, Password);

                if (!signUpNewUser)
                {
                    return false;
                }

                var loginAsNewUser = Login(newUsername, Password);

                return loginAsNewUser;
            }
            catch (Exception ex)
            {
                StfLogger.LogError($"Something went wrong when sign up and login. Message : [{ex.Message}]");
                throw;
            }
        }

        /// <summary>
        /// The check sign up validation messages.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CheckSignUpValidationMessages()
        {
            var validationMessagesDoNotExist = true;

            var signUpValidationMessages = new List<string>
            {
                "Please read and approve the terms and conditions",
                "The username must be between four and 25 characters long. Only numbers, letters, and hyphen are accepted.",
                "The password must be at least five characters long.",
                "Please specify a valid e-mail address"
            };

            foreach (var signUpValidationMessage in signUpValidationMessages)
            {
                var xpath = $@"(//p[text()='{signUpValidationMessage}'])[1]";

                var validationMessageElement = WebAdapter.FindElement(By.XPath(xpath));

                if (validationMessageElement != null)
                {
                    validationMessagesDoNotExist = false;
                    StfLogger.LogError($"SignUp. There is validation error. Message : [{signUpValidationMessage}]");
                }
            }

            return validationMessagesDoNotExist;
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
