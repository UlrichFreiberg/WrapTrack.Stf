﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Collection.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the LearnMore type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using WrapTrack.Stf.WrapTrackApi.Interfaces;

namespace WrapTrack.Stf.WrapTrackWeb.Me.Collection
{
    using System;

    using OpenQA.Selenium;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;

    /// <summary>
    /// The learn more.
    /// </summary>
    public class Collection : WrapTrackWebShellModelBase, ICollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Collection"/> class.
        /// </summary>
        /// <param name="wrapTrackWebShell">
        /// The wrap track web shell.
        /// </param>
        public Collection(IWrapTrackWebShell wrapTrackWebShell)
           : base(wrapTrackWebShell)
        {
        }

        /// <summary>
        /// Counts number of wraps in collection
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int NumOfWraps()
        {
            var elements = WebAdapter.FindElements(By.Id("lin_wrap"));
            var retval = elements.Count;

            return retval;
        }

        /// <summary>
        /// Returns random wrap in collection.        
        /// </summary>
        /// <param name="wtIdContraint">
        /// Constrain the randomness to NOT return this wrap
        /// </param>
        /// <returns>
        /// The <see cref="IWrap"/>.
        /// </returns>
        public IWrap GetRandomWrap(string wtIdContraint = null)
        {
            var wrapElements = WebAdapter.FindElements(By.Id("lin_wrap"));
            var numberOfWraps = wrapElements.Count;
            var random = new Random();
            var wrapToChoose = random.Next(1, numberOfWraps + 1);
            var xpath = $"(//a[@id='lin_wrap'])[{wrapToChoose}]";
            var element = WebAdapter.FindElement(By.XPath(xpath));
            var linWrapText = element.Text;

            if (!string.IsNullOrEmpty(wtIdContraint)
                && numberOfWraps > 1
                && linWrapText.Equals(wtIdContraint, StringComparison.CurrentCultureIgnoreCase))
            {
                wrapToChoose = wrapToChoose == numberOfWraps ? 1 : wrapToChoose + 1;
                xpath = $"(//a[@id='lin_wrap'])[{wrapToChoose}]";
                element = WebAdapter.FindElement(By.XPath(xpath));
            }

            StfLogger.LogInfo($"We choose wrap number {wrapToChoose} (of {numberOfWraps}) - {linWrapText}");
            element.Click();

            var retVal = StfContainer.Get<IWrap>();

            return retVal;
        }

        /// <summary>
        /// The get list of wt ids.
        /// </summary>
        /// <returns>
        /// List of WtId as strings
        /// </returns>
        public List<string> GetListOfWtIds()
        {
            var retVal = new List<string>();
            var wrapElements = WebAdapter.FindElements(By.Id("lin_wrap"));

            // Nothing for us - lets leave...
            if (wrapElements == null || !wrapElements.Any())
            {
                return retVal;
            }

            foreach (var wrapElement in wrapElements)
            {
                var wtId = wrapElement.Text;

                if (!string.IsNullOrEmpty(wtId) && !retVal.Contains(wtId))
                {
                    retVal.Add(wtId);
                }
            }

            return retVal;
        }

        /// <summary>
        /// Add a wrap to users own collection
        /// </summary>
        /// <param name="brand">
        /// The brand fx 'Artipoppe'
        /// </param>
        /// <param name="pattern">
        /// The pattern - fx 'Argus'
        /// </param>
        /// <param name="model">
        /// The model - fx 'The Queen'
        /// </param>
        /// <param name="size">
        /// The size of the wrap - fx 6
        /// </param>
        /// <returns>
        /// false if not possible
        /// </returns>
        public string AddWrap(string brand = null, string pattern = null, string model = null, int size = 6)
        {
            var existingListOfWtIds = GetListOfWtIds();

            // TODO: Is now related to English language
            var typeCarrier = "woven wrap";

            WebAdapter.ButtonClickById("but_add_carrier");

            if (brand == null)
            {
                brand = "Didymos";
                pattern = "Nino";
                model = "Blau";
            }

            SelectDropdownByIdAndText("selTypeCarrier", typeCarrier);
            SelectDropdownByIdAndText("sel_brand", brand);
            SelectDropdownByIdAndText("sel_pattern", pattern);
            SelectDropdownByIdAndText("sel_model", model);
            SelectDropdownByIdAndText("selWrapSize", size.ToString());

            // Button says save - we wanna add And Exit
            if (!WebAdapter.ButtonClickById("but_add_wrap"))
            {
                return null;
            }

            // TODO: the insert of the wrap might take some time...
            // TODO: Implement using Selenium Waiter
            WebAdapter.WaitForComplete(3);

            // gotta fix that after adding a wrap the wrap itself is shown
            // not the collection as it used to
            var me = WrapTrackWebShell.Me();

            me.GetCollection();

            var newListOfWtIds = GetListOfWtIds();
            var diffList = newListOfWtIds.Except(existingListOfWtIds);
            var enumerable = diffList as string[] ?? diffList.ToArray();

            // Return the wrap just added or null
            return enumerable.Length == 1 ? enumerable.First() : null;
        }

        /// <summary>
        /// The add carrier.
        /// </summary>
        /// <typeparam name="T">
        /// The interface for a carrier add
        /// </typeparam>
        /// <returns>
        /// An instance of t
        /// </returns>
        public T AddCarrier<T>()
        {
            WebAdapter.ButtonClickById("but_add_carrier");

            // Give WT time to load the page
            WebAdapter.WaitForComplete(2);

            var selectCarrierType = GetAddCarrierSelectTypeByInterface<T>();

            WebAdapter.SelectElementSetText(By.Id("selTypeCarrier"), selectCarrierType);

            // Selecting the Carrier Type makes the page reload
            WebAdapter.WaitForComplete(2);

            var retVal = Get<T>();

            return retVal;
        }

        /// <summary>
        /// Find a wrap by criteria. 
        /// Not Yet Implemented
        /// </summary>
        /// <param name="finderCriteria">
        /// The status criteria for the finder
        /// </param>
        /// <returns>a wrap that meets the criteria or null if no match</returns>
        /// <exception cref="NotImplementedException">
        /// Thrown as not yet implemented
        /// </exception>
        public IWrap FindBy(FinderCriteria finderCriteria)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Find by a wrap status with a specific value.
        /// Only implemented for OnHoliday true or false
        /// </summary>
        /// <param name="finderCriteria">
        /// The status field to Find By
        /// </param>
        /// <param name="argument">
        /// The value of the content of the status field
        /// </param>
        /// <returns>
        /// The Wrap matching the search criteria
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown in case of unknown value for argument
        /// </exception>
        public IWrap FindBy(FinderCriteria finderCriteria, bool argument)
        {
            var retVal = default(IWrap);

            switch (finderCriteria)
            {
                case FinderCriteria.Unknown:
                    break;
                case FinderCriteria.Random:
                    retVal = GetRandomWrap();
                    break;
                case FinderCriteria.OnHoliday:
                    retVal = FindWrapByOnHoliday(argument);
                    break;
                case FinderCriteria.Pictures:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(finderCriteria), finderCriteria, null);
            }

            return retVal;
        }

        /// <summary>
        /// Find a wrap in this collection that 
        /// is either on holiday or not depending on argument 
        /// </summary>
        /// <param name="argument">
        /// true is on holiday, false is not on holiday
        /// </param>
        /// <returns>a wrap that meets the criteria or null if no match</returns>
        private IWrap FindWrapByOnHoliday(bool argument)
        {
            var retVal = default(IWrap);

            var wrapElements = WebAdapter.FindElements(By.Id("lin_wrap"));

            if (wrapElements == null)
            {
                return null;
            }

            // Loop through all the items in the collection until 
            // find one whose OnHoliday status matches the argument
            var numberOfWraps = wrapElements.Count;

            for (var i = 1; i <= numberOfWraps; i++)
            {
                var xpath = $"(//a[@id='lin_wrap'])[{i}]";
                var element = WebAdapter.FindElement(By.XPath(xpath));
                var linWrapText = element.Text;
                var wtApi = Get<IWtApi>();
                var wrapInfo = wtApi.WrapInfoByTrackId(linWrapText);

                if (wrapInfo.OnHoliday == argument)
                {
                    element.Click();
                    retVal = StfContainer.Get<IWrap>();
                    break;
                }
            }

            return retVal;
        }

        /// <summary>
        /// The get add carrier select type by interface.
        /// </summary>
        /// <typeparam name="T">
        /// Expected carrier type to select in the dropdown for the Add Carrier
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetAddCarrierSelectTypeByInterface<T>()
        {
            var typeName = typeof(T).Name;

            switch (typeName)
            {
                case "IRingSling": return "ring sling";
                case "IWowenWrap": return "woven wrap";
                case "IStretchyWrap": return "stretchy wrap";
                case "IHybridWrap": return "hybrid wrap";
                case "IHalfBuckleMeiTai": return "half buckle mei tai";
                case "IMeiTai": return "mei tai";
                case "IWrapTai": return "wrap tai";

                case "I5": return "mei tai";
                case "I6": return "half buckle mei tai";
                case "I7": return "wrap tai";
                case "I8": return "half buckle wrap tai";
                case "I9": return "onbuhimo";
                case "I10": return "reverse onbuhimo";
                case "I11": return "buckle onbuhimo";
                case "I12": return "podeagi";
                case "I13": return "nyia";
                case "I14": return "doll sling";
                case "I15": return "other carrier";
                default: return "AddCarrier:Unsupported value";
            }
        }

        /// <summary>
        /// The set text by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="brand">
        /// The brand.
        /// </param>
        private void SelectDropdownByIdAndText(string id, string brand)
        {
            // mostly for demo purposes - you can follow what happens
            WebAdapter.WaitForComplete(1);

            var elem = WebAdapter.FindElement(By.Id(id));

            elem.SendKeys(brand);
        }
    }
}
