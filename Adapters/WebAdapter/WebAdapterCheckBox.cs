// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebAdapterCheckBox.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WebAdapter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.Adapters.WebAdapter
{
    using OpenQA.Selenium;

    /// <summary>
    /// The web adapter.
    /// </summary>
    public partial class WebAdapter
    {
        /// <summary>
        /// The check box.
        /// </summary>
        /// <param name="by">
        /// The by.
        /// </param>
        /// <returns>
        /// The <see cref="IWebElement"/>.
        /// </returns>
        public IWebElement CheckBox(By by)
        {
            var elem = FindElement(by);

            if (elem == null)
            {
                StfLogger.LogDebug("Couldn't find CheckBox");

                return null;
            }

            return elem;
        }

        /// <summary>
        /// The check box get value by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CheckBoxGetValueById(string id)
        {
            var by = By.Id(id);
            var retVal = CheckBoxGetValue(by);

            return retVal;
        }

        /// <summary>
        /// The check box get value by xpath.
        /// </summary>
        /// <param name="xpath">
        /// The xpath.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CheckBoxGetValueByXpath(string xpath)
        {
            var by = By.XPath(xpath);
            var retVal = CheckBoxGetValue(by);

            return retVal;
        }

        /// <summary>
        /// The check box get value.
        /// </summary>
        /// <param name="by">
        /// The by.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CheckBoxGetValue(By by)
        {
            var elem = CheckBox(by);
            var retVal = elem?.Selected ?? false;

            return retVal;
        }

        /// <summary>
        /// The check box set value by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="selectValue">
        /// The select value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CheckBoxSetValueById(string id, bool selectValue)
        {
            var by = By.Id(id);
            var retVal = CheckBoxSetValue(by, selectValue);

            return retVal;
        }

        /// <summary>
        /// The check box set value by xpath.
        /// </summary>
        /// <param name="xpath">
        /// The xpath.
        /// </param>
        /// <param name="selectValue">
        /// The select value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CheckBoxSetValueByXpath(string xpath, bool selectValue)
        {
            var by = By.XPath(xpath);
            var retVal = CheckBoxSetValue(by, selectValue);

            return retVal;
        }

        /// <summary>
        /// The check box set value.
        /// </summary>
        /// <param name="by">
        /// The by.
        /// </param>
        /// <param name="selectValue">
        /// The select value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CheckBoxSetValue(By by, bool selectValue)
        {
            var elem = CheckBox(by);

            if (elem == null)
            {
                return false;
            }

            if (elem.Selected == selectValue)
            {
                return true;
            }

            elem.Click();

            var retVal = elem.Selected == selectValue;

            return retVal;
        }
   }
}