// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Wrap.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the LearnMore type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.WrapTrackWeb
{
    using System;
    using System.Linq;

    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackApi.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Me.Collection;

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
                const string Xpath = "//span[@class='font_wraptrack']/following-sibling::span";
                var retVal = WebAdapter.GetText(By.XPath(Xpath));

                retVal = retVal.Trim();

                return retVal;
            }
        }

        /// <summary>
        /// Gets the internal id of wrap
        /// </summary>
        public string InternalId
        {
            get
            {
                var validationTarget = Get<IWtApi>();
                var wrapInfo = validationTarget.WrapInfoByInternalId(WtId);
                var retVal = wrapInfo.InternalId;

                return retVal;
            }
        }

        /// <summary>
        /// Gets or sets number of private pictures uploaded and still valid
        /// </summary>
        public int NumPictures { get; set; }

        /// <summary>
        /// Pass on the wrap to user 'username' (only possible for owner of wrap)
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
            if (!WebAdapter.ButtonClickByXpath("//button[@id='but_passon']"))
            {
                StfLogger.LogDebug("Couldn't press PassOn button");
                return false;
            }

            if (!WebAdapter.TextboxSetTextById("inputBrugerSoeg", username))
            {
                StfLogger.LogDebug("Couldn't set brugerSoeg text");
                return false;
            }


            // click the select user button
            if (!WebAdapter.ButtonClickById("but_selUser"))
            {
                StfLogger.LogDebug("Couldn't press SelectUser button");
                return false;
            }

            // Choose a date for ownership-start
            if (ownershipStart != null)
            {
                WebAdapter.WaitForComplete(TimeSpan.FromSeconds(1));

                if (!WebAdapter.TextboxSetTextById("inp_datePassOn", ownershipStart))
                {
                    StfLogger.LogInfo("Date for ownership not changed");
                    return false;
                }
            }

            // answer the R U sure
            if (!WebAdapter.ButtonClickById("but_goPassOn"))
            {
                StfLogger.LogDebug("Couldn't press R-U-Sure button");
                return false;
            }

            return true;
        }

        /// <summary>
        /// The send away temporarily.
        /// </summary>
        /// <param name="sendAwayReason">
        /// The send away reason.
        /// </param>
        /// <param name="recipient">
        /// The recipient.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SendAwayTemporarily(SendAwayReason sendAwayReason, string recipient)
        {
            string inputValue;
            
            // click the SendAwayTemp button
            WebAdapter.ButtonClickById("but_sendonholiday");

            switch (sendAwayReason)
            {
                case SendAwayReason.Holiday:
                    inputValue = "ferie";
                    break;
                case SendAwayReason.Tester:
                    inputValue = "test";
                    break;
                case SendAwayReason.Rent:
                    inputValue = "udlejning";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sendAwayReason), sendAwayReason, null);
            }

            var xPath = $"//input[@value='{inputValue}']";

            WebAdapter.ButtonClickByXpath(xPath);

            // now chose the recipient
            WebAdapter.TextboxSetTextById("inputBrugerSoeg_ferievikle", recipient);
            WebAdapter.ButtonClickById("but_chooseUser");

            // press ok
            var retVal = WebAdapter.ButtonClickById("but_ok1_vaelg");

            return retVal;
        }

        /// <summary>
        /// Ask for the wrap (only possible for not-owner of wrap)
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AskFor()
        {
            if (!WebAdapter.ButtonClickById("but_please"))
            {
                StfLogger.LogDebug("Couldn't press 'Request wrap'");
                return false;
            }

            if (!WebAdapter.ButtonClickById("but-ReqWrapOK"))
            {
                StfLogger.LogDebug("Couldn't press 'Request wrap sec time'");
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
                WebAdapter.NativeDialogFileUpload(By.Id("userfile"), clientSideFilePath);

                WebAdapter.WaitForComplete(3);

                // Press upload the image
                WebAdapter.ButtonClickById("but_doupload");
            }

            WebAdapter.WaitForComplete(3);

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
            var buttons = WebAdapter.FindElements(By.Id("but_delete"));

            if (buttons == null || buttons.Count == 0)
            {
                return false;
            }

            var buttonToClick = buttons.First();

            buttonToClick.Click();

            // We have to wait a bit to get WT in sync
            WebAdapter.WaitForComplete(3);

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

            if (!WebAdapter.ButtonClickById("but_remove"))
            {
                return false; 
            }

            switch (deleteOption)
            {
                case DeleteWrapOption.SoldToAnotherUser:
                    optIdentId = "opt1";
                    nextButtonId = "but_cancel";
                    break;
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
            WebAdapter.WaitForComplete(1); 

            var next = WebAdapter.ButtonClickById(nextButtonId);
            
            // if we managed to press Next, then we are good:-)
            return next;
        }
    }
}
