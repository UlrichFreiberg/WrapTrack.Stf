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
    using System;
    using System.Linq;

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
        /// Gets or sets number of private pictures uploaded and still valid
        /// </summary>
        public int NumPictures { get; set; }

        /// <summary>
        /// Pass on the wrap to user 'username'
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="ownershipStart">
        /// The ownership Start.
        /// If not set, default date is used
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool PassOn(string username, string ownershipStart = null)
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

            // Choose a date for ownership-start
            if (ownershipStart != null)
            {
                Wait(TimeSpan.FromSeconds(1));

                if (!WebAdapter.TextboxSetTextById("inp_datePassOn", ownershipStart))
                {
                    StfLogger.LogInfo("Date for ownership not changed");
                    return false;
                }
            }

            // answer the R U sure
            if (!WebAdapter.ButtonClickById("but_goPassOn"))
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc />
        /// <summary>
        /// The upload pic.
        /// </summary>
        /// <param name="clientSideFilePath">
        /// The client Side File Path.
        /// </param>
        /// <param name="numUploads">
        /// The number of uploads of picture in clientSideFilePath is going to be performed.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Boolean" />.
        /// </returns>
        public bool UploadWrapImage(string clientSideFilePath, int numUploads = 1)
        {
            // click the button 'Administrate pictures' 
            WebAdapter.ButtonClickById("but_adm_pic");

            for (var i = 1; i <= numUploads; i++)
            {
                WebAdapter.WaitForComplete(3);

                // handle the File Upload Dialog
                WebAdapter.NativeDialogFileUpload(By.Id("but_file"), clientSideFilePath);

                WebAdapter.WaitForComplete(3);

                // Press upload the image
                WebAdapter.ButtonClickById("but_doupload");
            }

            return true;
        }

        /// <summary>
        /// The remove ONE wrap image. 
        /// </summary>
        /// <param name="imageIndex">
        /// The index of the image to delete - if 1 then the image listed in the top
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool RemoveWrapImage(int imageIndex = 1)
        {
            var buttons = WebAdapter.FindElements(By.Id("but_deleteprivateimg"));

            if (buttons == null || buttons.Count == 0)
            {
                return false;
            }

            var buttonToClick = buttons.First();

            buttonToClick.Click();

            return true;
        }

        /// <summary>
        /// Remove a wrap from collection
        /// </summary>
        /// <param name="deleteOption">
        /// There is more than one reason why the wrap should 
        /// not be part of the user collecting more
        /// </param>
        /// <returns>
        /// True if sucsess else False
        /// </returns>
        public bool Remove(DeleteWrapOption deleteOption)
        {
            string optIdentId;
            string nextButtonId;

            ClickById("but_remove");

            switch (deleteOption)
            {
                case DeleteWrapOption.SoldToAnotherUser:
                    return true; 

                case DeleteWrapOption.SoldToStranger:
                    optIdentId = "opt2";
                    nextButtonId = "but_fortsaet2";
                    break;
                case DeleteWrapOption.LostWrap:
                    optIdentId = "opt3";
                    nextButtonId = "but_ok3";
                    break;
                case DeleteWrapOption.BrokenWrap:
                    optIdentId = "opt4";
                    nextButtonId = "but_ok4";
                    break;
                case DeleteWrapOption.WasAnError:
                    optIdentId = "opt5";
                    nextButtonId = "but_ok5";
                    break;
                case DeleteWrapOption.Converted:
                    optIdentId = "opt4";
                    nextButtonId = "but_ok4";
                    break;
                case DeleteWrapOption.ConvertedNonWrap:
                    optIdentId = "opt7";
                    nextButtonId = "but_ok7";
                    break;
                default:
                    return false; 
            }

            // var myChoise = WebAdapter.FindElement(By.Name(optIdentId));
            WebAdapter.ButtonClickById(optIdentId);

            // wait for button to appear
            Wait(TimeSpan.FromSeconds(1)); 

            var next = WebAdapter.ButtonClickById(nextButtonId);
            
            // if we manage to press Next, then we are good:-)
            return next;
        }

        /// <summary>
        /// The wait.
        /// </summary>
        /// <param name="duration">
        /// The duration.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected bool Wait(TimeSpan duration)
        {
            System.Threading.Thread.Sleep(duration);

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
    }
}
