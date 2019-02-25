﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCaseUtils.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   The Add Carrier - Woven tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WrapTrackWebTests.Collection.AddCarrier
{
    using System;

    using Mir.Stf.Utilities;

    using WrapTrack.Stf.WrapTrackWeb.Interfaces;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me;
    using WrapTrack.Stf.WrapTrackWeb.Interfaces.Me.Collection.CarrierManagement;

    /// <summary>
    /// The Add Carrier - Woven tests.
    /// </summary>
    public class TestCaseUtils
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseUtils"/> class.
        /// </summary>
        /// <param name="stfAssert">
        /// The stf assert.
        /// </param>
        public TestCaseUtils(StfAssert stfAssert)
        {
            StfAssert = stfAssert;
        }

        /// <summary>
        /// Gets the stf assert.
        /// </summary>
        private StfAssert StfAssert { get; }

        /// <summary>
        /// The handle made of wrap.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="madeOfWrap">
        /// The made Of Wrap.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool HandleMadeOfWrap(ICarrierBase addCarrier, string madeOfWrap)
        {
            var retVal = InternalHandleMadeOfWrap(addCarrier, madeOfWrap);

            StfAssert.IsTrue("HandleMadeOfWrap", retVal);

            return retVal;
        }

        /// <summary>
        /// The handle converted convert type convert name.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="converted">
        /// The converted.
        /// </param>
        /// <param name="convertType">
        /// The convert type.
        /// </param>
        /// <param name="convertName">
        /// The convert name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool HandleConvertedConvertTypeConvertName(
            ICarrierBase addCarrier,
            string converted,
            string convertType,
            string convertName)
        {
            var retVal = InternalHandleConvertedConvertTypeConvertName(
                addCarrier,
                converted,
                convertType,
                convertName);

            StfAssert.IsTrue("HandleConvertedConvertTypeConvertName", retVal);

            return retVal;
        }

        /// <summary>
        /// The handle home made.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="homeMade">
        /// The home Made.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool HandleHomeMade(ICarrierBase addCarrier, string homeMade)
        {
            var retVal = InternalHandleHomeMade(addCarrier, homeMade);

            StfAssert.IsTrue("HandleSizeGradeAcquired", retVal);

            return retVal;
        }

        /// <summary>
        /// The brand pattern model.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="brand">
        /// The brand.
        /// </param>
        /// <param name="pattern">
        /// The pattern.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool HandleBrandPatternModel(
            ICarrierBase addCarrier,
            string brand,
            string pattern,
            string model)
        {
            if (string.IsNullOrEmpty(brand))
            {
                // Mom I'm done!! - If no brand then pattern and model will never be shown
                return true;
            }

            addCarrier.Brand = brand;
            addCarrier.Pattern = string.IsNullOrEmpty(pattern)
                               ? "--- without pattern ---"
                               : pattern;

            if (!string.IsNullOrEmpty(model))
            {
                addCarrier.Model = model;
            }

            const bool RetVal = true;

            StfAssert.IsTrue("HandleBrandPatternModel", RetVal);

            return RetVal;
        }

        /// <summary>
        /// The handle size grade acquired.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <param name="grade">
        /// The grade.
        /// </param>
        /// <param name="acquired">
        /// The acquired.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool HandleSizeGradeAcquired(
            ICarrierBase addCarrier,
            string size,
            string grade,
            string acquired)
        {
            if (size != null)
            {
                addCarrier.Size = size;
            }

            if (size != null)
            {
                addCarrier.Grade = grade;
            }

            int daysOffSet;

            if (!int.TryParse(acquired, out daysOffSet))
            {
                daysOffSet = 0;
            }

            var addCarrierAcquired = DateTime.Now.AddDays(daysOffSet);

            addCarrier.Acquired = addCarrierAcquired;

            return true;
        }

        /// <summary>
        /// The get add carrier.
        /// </summary>
        /// <param name="wrapTrackShell">
        /// The wrap track shell.
        /// </param>
        /// <param name="carrierType">
        /// The carrier type.
        /// </param>
        /// <returns>
        /// The <see cref="ICarrierBase"/>.
        /// </returns>
        public ICarrierBase GetAddCarrier(IWrapTrackWebShell wrapTrackShell, string carrierType)
        {
            var me = wrapTrackShell.Me();
            var collection = me.GetCollection();
            var addCarrier = GetCarrierBySelectType(collection, carrierType);

            return addCarrier;
        }

        /// <summary>
        /// The handle brand carriertypenickname carriermodel.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="testdataBrand">
        /// The testdata brand.
        /// </param>
        /// <param name="testdataCarrierTypeNickName">
        /// The testdata carrier type nick name.
        /// </param>
        /// <param name="testdataCarrierModel">
        /// The testdata carrier model.
        /// </param>
        public void HandleBrandCarriertypenicknameCarriermodel(
            ICarrierBase addCarrier,
            string testdataBrand,
            string testdataCarrierTypeNickName,
            string testdataCarrierModel)
        {
            addCarrier.Brand = testdataBrand;
            addCarrier.CarrierType = testdataCarrierTypeNickName;
            addCarrier.CarrierModel = testdataCarrierModel;
        }

        /// <summary>
        /// The handle made of wrap.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="madeOfWrap">
        /// The made Of Wrap.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool InternalHandleMadeOfWrap(ICarrierBase addCarrier, string madeOfWrap)
        {
            if (string.IsNullOrEmpty(madeOfWrap))
            {
                // Mom I'm done!! - If not Converted...
                return true;
            }

            var retVal = addCarrier.SelectMadeOfWrap();

            return retVal;
        }

        /// <summary>
        /// The handle converted convert type convert name.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="converted">
        /// The converted.
        /// </param>
        /// <param name="convertType">
        /// The convert Type.
        /// </param>
        /// <param name="convertName">
        /// The convert Name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool InternalHandleConvertedConvertTypeConvertName(
            ICarrierBase addCarrier,
            string converted,
            string convertType,
            string convertName)
        {
            if (string.IsNullOrEmpty(converted))
            {
                // Mom I'm done!! - If not Converted...
                return true;
            }

            addCarrier.Converted = true;
            addCarrier.ConvertType = convertType;
            addCarrier.ConvertName = convertName;

            return true;
        }

        /// <summary>
        /// The handle home made.
        /// </summary>
        /// <param name="addCarrier">
        /// The add carrier.
        /// </param>
        /// <param name="homeMade">
        /// The home Made.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool InternalHandleHomeMade(ICarrierBase addCarrier, string homeMade)
        {
            if (string.IsNullOrEmpty(homeMade))
            {
                addCarrier.HomeMade = false;

                return true;
            }

            addCarrier.HomeMade = true;
            addCarrier.Name = $"MyOwn_{Guid.NewGuid()}";

            return true;
        }

        /// <summary>
        /// The get carrier by select type.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="selectType">
        /// The select type.
        /// </param>
        /// <returns>
        /// The <see cref="ICarrierBase"/>.
        /// </returns>
        private ICarrierBase GetCarrierBySelectType(ICollection collection, string selectType)
        {
            switch (selectType.ToLower().Trim())
            {
                case "ring sling": return collection.AddCarrier<IRingSling>();
                case "woven wrap": return collection.AddCarrier<IWowenWrap>();
                case "stretchy wrap": return collection.AddCarrier<IStretchyWrap>();
                case "hybrid wrap": return collection.AddCarrier<IHybridWrap>();
                case "mei tai": return collection.AddCarrier<IMeiTai>();
                case "half buckle mei tai": return collection.AddCarrier<IHalfBuckleMeiTai>();
                case "wrap tai": return collection.AddCarrier<IWrapTai>();
                case "half buckle wrap tai": return collection.AddCarrier<IHalfBuckleWrapTai>();
                case "onbuhimo": return collection.AddCarrier<IOnbuhimo>();
                case "reverse onbuhimo": return collection.AddCarrier<IReverseOnbuhimo>();
                case "buckle onbuhimo": return collection.AddCarrier<IBuckleOnbuhimo>();
                case "podeagi": return collection.AddCarrier<IPodeagi>();
                case "nyia": return collection.AddCarrier<INyia>();
                case "doll sling": return collection.AddCarrier<IDollSling>();
            }

            return null;
        }
    }
}
