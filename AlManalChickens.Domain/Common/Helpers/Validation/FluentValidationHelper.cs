﻿using AlManalChickens.Domain.Common.Helpers.Localization;
using AlManalChickens.Domain.Enums;
using System.ComponentModel;

namespace AlManalChickens.Domain.Common.Helpers.Validation
{
    public static class FluentValidationHelper
    {
        public static string Message<T>(string lang, string localizationPath, string propName, ValidationTypesEnum type, params object[] inputs)
        {
            var propDescription = GetDisplayName<T>(propName, lang);
            var messageInputs = AppendToParams(propDescription, inputs);
            var x = LocalizerHelper.LocalizeValidation(type.ToString(), lang, localizationPath, messageInputs);
            return x;
        }

        public static string GetDisplayName<T>(string propName, string lang)
        {
            if (lang == "en")
                return propName;

            var propertyAttribute = typeof(T).GetMember(propName)[0].GetCustomAttributes(typeof(DisplayNameAttribute), inherit: false);

            if (!propertyAttribute.Any())
                return propName;

            var descriptionAttribute = propertyAttribute[0] as DisplayNameAttribute;

            return descriptionAttribute.DisplayName;
        }

        public static T[] AppendToParams<T>(T first, params T[] items)
        {
            T[] result = new T[items.Length + 1];

            result[0] = first;

            items.CopyTo(result, 1);

            return result;
        }
    }
}
