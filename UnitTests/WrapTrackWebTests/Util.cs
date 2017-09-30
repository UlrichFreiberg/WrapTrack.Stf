using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WrapTrackWebTests
{
    using WrapTrack.Stf.Adapters.WebAdapter;
    class Util
    {
        public static bool PhpErrorFree(IWebAdapter webAdapter)
        {
            var webFile = webAdapter.GetText(By.XPath("//*"));

            if (webFile.Contains("PHP ERROR"))
            {
                return false;
            }

            if (webFile.Contains("ParseError"))
            {
                return false;
            }

            return true;
        }
    }
}
