// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebAdapterNativeDialogHandler.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the WebAdapter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
//
// Read about native dialogs here: http://nadimsaker.blogspot.dk/2015/07/selenium-how-to-upload-file-in-selenium.html
//
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrack.Stf.Adapters.WebAdapter
{
    using System.Windows.Forms;

    using OpenQA.Selenium;

    /// <summary>
    /// The web adapter.
    /// </summary>
    public partial class WebAdapter
    {
        /// <summary>
        /// The native dialog file upload.
        /// </summary>
        /// <param name="by">
        /// The by.
        /// </param>
        /// <param name="clientSideFilePath">
        /// The client side file path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool NativeDialogFileUpload(By by, string clientSideFilePath)
        {
            // Click the button that opens the file dialog
            Click(by);

            // wait and see:-)
            WaitForComplete(1);

            // Use WinForms SendKeys to fill in the path
            SendKeys.SendWait(clientSideFilePath);
            SendKeys.SendWait("{Enter}");

            // wait and see:-)
            WaitForComplete(1);

            return true;
        }
    }
}