// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuManager.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the MenuManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb
{
    using OpenQA.Selenium;

    using WrapTrack.Stf.Adapters.WebAdapter;

    /// <summary>
    /// The top menu.
    /// </summary>
    public enum TopMenu
    {
        /// <summary>
        /// The home.
        /// </summary>
        Home,

        /// <summary>
        /// The news.
        /// </summary>
        News,

        /// <summary>
        /// The explore.
        /// </summary>
        Explore,

        /// <summary>
        /// The market.
        /// </summary>
        Market,

        /// <summary>
        /// The me.
        /// </summary>
        Me,

        /// <summary>
        /// The faq contact.
        /// </summary>
        FaqContact,

        /// <summary>
        /// The logout.
        /// </summary>
        Logout
    }

    /// <summary>
    /// The explore menu.
    /// </summary>
    public enum ExploreMenu
    {
        /// <summary>
        /// The wraps.
        /// </summary>
        Wraps,

        /// <summary>
        /// The users.
        /// </summary>
        Users,

        /// <summary>
        /// The brands.
        /// </summary>
        Brands,

        /// <summary>
        /// The patterns.
        /// </summary>
        Patterns,

        /// <summary>
        /// The models.
        /// </summary>
        Models,

        /// <summary>
        /// The birth wraps.
        /// </summary>
        BirthWraps,
    }

    /// <summary>
    /// The me menu.
    /// </summary>
    public enum MeMenu
    {
        /// <summary>
        /// The profile.
        /// </summary>
        Profile,

        /// <summary>
        /// The collection.
        /// </summary>
        Collection,

        /// <summary>
        /// The inbox.
        /// </summary>
        Inbox,

        /// <summary>
        /// The reviews.
        /// </summary>
        Reviews,

        /// <summary>
        /// The settings.
        /// </summary>
        Settings,

        /// <summary>
        /// The logout.
        /// </summary>
        Logout
    }

    /// <summary>
    /// The menu manager.
    /// </summary>
    public class MenuManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuManager"/> class.
        /// </summary>
        /// <param name="webAdapter">
        /// The web adapter.
        /// </param>
        public MenuManager(IWebAdapter webAdapter)
        {
            WebAdapter = webAdapter;
        }

        /// <summary>
        /// Gets the web adapter.
        /// </summary>
        private IWebAdapter WebAdapter { get; }

        /// <summary>
        /// The go menu.
        /// </summary>
        /// <param name="topMen">
        /// The top men.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool GoMenu(TopMenu topMen)
        {
            bool retVal;

            switch (topMen)
            {
                case TopMenu.Home:
                    retVal = PressMenu("Home");
                    break;
                case TopMenu.News:
                    retVal = PressMenu("News");                
                    break;
                case TopMenu.Explore:
                    retVal = PressMenu("Explore");
                    break;
                case TopMenu.Market:
                    retVal = PressMenu("Market");
                    break;
                case TopMenu.Me:
                    retVal = PressMenu("Me");
                    break;
                case TopMenu.FaqContact:
                    retVal = PressMenu("FAQ");
                    break;
                case TopMenu.Logout:
                    retVal = PressMenu("Logout");
                    break;
                default:
                    retVal = false;
                    break;
            }

            return retVal;
        }

        /// <summary>
        /// The go menu.
        /// </summary>
        /// <param name="exploreMenu">
        /// The explore menu.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool GoMenu(ExploreMenu exploreMenu)
        {
            var retVal = GoMenu(TopMenu.Explore);

            if (!retVal)
            {
                return false;
            }

            switch (exploreMenu)
            {
                case ExploreMenu.Wraps:
                    retVal = PressMenu("wraps");
                    break;
                case ExploreMenu.Users:
                    retVal = PressMenu("users");
                    break;
                case ExploreMenu.Brands:
                    retVal = PressMenu("brands");
                    break;
                case ExploreMenu.Patterns:
                    retVal = PressMenu("patterns");
                    break;
                case ExploreMenu.Models:
                    retVal = PressMenu("models");
                    break;
                case ExploreMenu.BirthWraps:
                    retVal = PressMenu("birth wraps");
                    break;
                default:
                    retVal = false;
                    break;
            }

            return retVal;
        }

        /// <summary>
        /// The go menu.
        /// </summary>
        /// <param name="meMenu">
        /// The me menu.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool GoMenu(MeMenu meMenu)
        {
            var retVal = GoMenu(TopMenu.Explore);

            switch (meMenu)
            {
                case MeMenu.Profile:
                    break;
                case MeMenu.Collection:
                    break;
                case MeMenu.Inbox:
                    break;
                case MeMenu.Reviews:
                    break;
                case MeMenu.Settings:
                    break;
                case MeMenu.Logout:
                    break;
                default:
                    retVal = false;
                    break;
            }

            return retVal;
        }

        /// <summary>
        /// The press top menu.
        /// </summary>
        /// <param name="menuName">
        /// The menu name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool PressMenu(string menuName)
        {
            var xpath = $"//li/a[normalize-space()='{menuName}']";
            var element = WebAdapter.FindElement(By.XPath(xpath));

            if (element == null)
            {
                return false;
            }

            element.Click();

            return true;
        }
    }
}
