// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Brand.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The Brand interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb.Brand
{
    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Brand;

    /// <summary>
    /// The Brand interface.
    /// </summary>
    public class Brand : WrapTrackWebShellModelBase, IBrand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Brand"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public Brand(IWrapTrackWebShell wrapTrackWebShell)
            : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// The patterns.
        /// </summary>
        /// <returns>
        /// The <see cref="IPatterns"/>.
        /// </returns>
        public IPatterns Patterns()
        {
            var retVal = Get<IPatterns>();

            return retVal;
        }

        /// <summary>
        /// The models.
        /// </summary>
        /// <returns>
        /// The <see cref="IModels"/>.
        /// </returns>
        public IModels Models()
        {
            var retVal = Get<IModels>();

            return retVal;
        }

        /// <summary>
        /// The wraps.
        /// </summary>
        /// <returns>
        /// The <see cref="IWraps"/>.
        /// </returns>
        public IWraps Wraps()
        {
            var retVal = Get<IWraps>();

            return retVal;
        }

        /// <summary>
        /// The forum.
        /// </summary>
        /// <returns>
        /// The <see cref="IForum"/>.
        /// </returns>
        public IForum Forum()
        {
            var retVal = Get<IForum>();

            return retVal;
        }

        /// <summary>
        /// Add pattern to the brand.
        /// </summary>
        /// <param name="patternName">
        /// The pattern name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AddPattern(string patternName)
        {
            var retVal = WebAdapter.ButtonClickById("addPattern");

            if (!retVal)
            {
                return false;
            }

            retVal = WebAdapter.TextboxSetTextById("inNameNewElement", patternName);

            if (!retVal)
            {
                return false;
            }

            retVal = WebAdapter.ButtonClickById("create");

            if (!retVal)
            {
                return false;
            }

            retVal = WebAdapter.ButtonClickById("create");

            // gotta wait for the WT to process the add...
            WebAdapter.WaitForComplete(1);

            return retVal;
        }

        /// <summary>
        /// The delete pattern.
        /// </summary>
        /// <param name="patternNameToDelete">
        /// The pattern name to delete.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool DeletePattern(string patternNameToDelete)
        {
            // Press administration
            var retVal = WebAdapter.ButtonClickById("admin");

            if (!retVal)
            {
                return false;
            }

            // open the right pattern
            var xPath = $"//a[text()='{patternNameToDelete}']";

            retVal = WebAdapter.Click(By.XPath(xPath));

            if (!retVal)
            {
                return false;
            }

            // Press delete
            retVal = WebAdapter.ButtonClickById("delete");

            if (!retVal)
            {
                return false;
            }

            // Yeap I'm sure
            retVal = WebAdapter.ButtonClickById("yes");

            if (!retVal)
            {
                return false;
            }

            // Exit Admin mode
            retVal = WebAdapter.ButtonClickByXpath("//button[normalize-space()='Show']");

            if (!retVal)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The add model.
        /// </summary>
        /// <param name="modelName">
        /// The model name.
        /// </param>
        /// <param name="pattern">
        /// The pattern.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AddModel(string modelName, string pattern = null)
        {
            const string AddModelXpath = "//span/span[text()='Add model']";
            var retVal = WebAdapter.ButtonClickByXpath(AddModelXpath);

            if (!retVal)
            {
                return false;
            }

            // if pattern is null, then create model without pattern
            if (string.IsNullOrEmpty(pattern))
            {
                pattern = "--- without pattern ---";
            }

            const string PatternNameXpath = "//p[normalize-space()='Pattern']/../..//select";

            retVal = WebAdapter.SelectElementSetText(By.XPath(PatternNameXpath), pattern);

            if (!retVal)
            {
                return false;
            }

            const string ModelNameXpath = "//p[normalize-space()='Model']/../..//input";

            retVal = WebAdapter.TextboxSetTextByXpath(ModelNameXpath, modelName);

            if (!retVal)
            {
                return false;
            }

            retVal = WebAdapter.ButtonClickById("create");

            if (!retVal)
            {
                return false;
            }

            // Yeap done
            retVal = WebAdapter.ButtonClickById("modelDone");

            return retVal;
        }

        /// <summary>
        /// The delete model.
        /// </summary>
        /// <param name="modelNameToDelete">
        /// The model name to delete.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool DeleteModel(string modelNameToDelete)
        {
            // Press administration
            var retVal = WebAdapter.ButtonClickById("admin");

            if (!retVal)
            {
                return false;
            }

            // open the right pattern
            var xPath = $"//a[text()='{modelNameToDelete}']";

            retVal = WebAdapter.Click(By.XPath(xPath));

            if (!retVal)
            {
                return false;
            }

            // Press delete
            retVal = WebAdapter.ButtonClickById("deleteModel");

            if (!retVal)
            {
                return false;
            }

            // Yeap I'm sure
            retVal = WebAdapter.ButtonClickById("okDeleteModel");

            if (!retVal)
            {
                return false;
            }

            // Exit Admin mode
            retVal = WebAdapter.ButtonClickByXpath("//button[normalize-space()='Show']");

            if (!retVal)
            {
                return false;
            }

            return true;
        }
    }
}