// --------------------------------------------------------------------------------------------------------------------
// <copyright file="enumExtensions.cs" company="Mir Software">
//   Copyright governed by Artistic license as described here:
//          http://www.perlfoundation.org/artistic_license_2_0
// </copyright>
// <summary>
//   Defines the EnumExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace WrapTrack.Stf.Core
{
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    /// <summary>
    /// The enum extensions.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// The get display name.
        /// </summary>
        /// <param name="enu">
        /// The enu.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetDisplayName(this Enum enu)
        {
            var attr = GetDisplayAttribute(enu);
            var retVal = attr != null ? attr.Name : enu.ToString();

            return retVal;
        }

        /// <summary>
        /// The get description.
        /// </summary>
        /// <param name="enu">
        /// The enu.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetDescription(this Enum enu)
        {
            var attr = GetDisplayAttribute(enu);
            var retVal = attr != null ? attr.Description : enu.ToString();

            return retVal;
        }

        /// <summary>
        /// Given an Enum, then return a random value - take into account the "Unknown" value as unparsable 
        /// </summary>
        /// <typeparam name="T">
        /// A enum - for now we cant restrict the type for T when T is a eum
        /// </typeparam>
        /// <returns>The chosen random Enum value</returns>
        public static T GetRandomEnum<T>()
        {
            var random = new Random();
            var enumValues = Enum.GetValues(typeof(T));
            var minimum = GetEnumStartIndexCorrectForDefaultValue<T>(enumValues);
            var maximum = enumValues.Length;
            var randomIndex = random.Next(minimum, maximum);
            var retVal = (T)enumValues.GetValue(randomIndex);

            return retVal;
        }

        /// <summary>
        /// The get enum start index correct for default value. 
        /// Used by GetEnumStartIndexCorrectForDefaultValue
        /// </summary>
        /// <typeparam name="T">
        /// The enum as type
        /// </typeparam>
        /// <param name="enumValues">
        /// The enum values.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private static int GetEnumStartIndexCorrectForDefaultValue<T>(Array enumValues)
        {
            var enumFirstValue = (T)enumValues.GetValue(0);
            var firstValue = enumFirstValue.ToString();

            if (string.IsNullOrEmpty(firstValue))
            {
                return 0;
            }

            var retVal = firstValue.Equals("Unknown", StringComparison.CurrentCultureIgnoreCase) ? 1 : 0;

            return retVal;
        }

        /// <summary>
        /// The get display attribute.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="DisplayAttribute"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws if object is not a enum type
        /// </exception>
        private static DisplayAttribute GetDisplayAttribute(object value)
        {
            var type = value.GetType();

            if (!type.IsEnum)
            {
                throw new ArgumentException($"Type {type} is not an enum");
            }

            // Get the enum field.
            var field = type.GetField(value.ToString());

            return field == null ? null : field.GetCustomAttribute<DisplayAttribute>();
        }
    }
}
