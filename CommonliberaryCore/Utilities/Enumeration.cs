﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonLiberaryCore.Utilities
{
    public static class Enumeration<T>
    where T : struct, Enum
    {
        public static IList<T> GetValues(Enum value)
        {
            var enumValues = new List<T>();

            foreach (FieldInfo fi in value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add((T)Enum.Parse(value.GetType(), fi.Name, false));
            }
            return enumValues;
        }

        public static T Parse(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static IList<string> GetNames(Enum value)
        {
            return value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        }


        public static IList<string?> GetDisplayValues(Enum value)
        {
            return GetNames(value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
        }
        private static string? lookupResource(Type? resourceManagerProvider, string? resourceKey)
        {
            foreach (PropertyInfo? staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    var resourceManager = staticProperty?.GetValue(null, null) as System.Resources.ResourceManager;
                    return resourceManager?.GetString(name: resourceKey ?? "");
                }
            }

            return resourceKey; // Fallback with the key name
        }

        public static string? GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            DisplayAttribute[]? descriptionAttributes = fieldInfo?.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes?[0].ResourceType != null)
            {
                return lookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);
            }

            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }



    }
}
