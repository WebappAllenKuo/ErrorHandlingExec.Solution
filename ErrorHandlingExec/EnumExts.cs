using System;
using System.ComponentModel;
using System.Reflection;

namespace ErrorHandlingExec
{
    public static class EnumExts
    {
        public static string GetDescription(this Enum value)
        {
            // reference : https://stackoverflow.com/questions/15388072/how-to-add-extension-methods-to-enums
            string defaultValue = value.ToString();
            
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null) return defaultValue;
            
            var attribute = fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null
                ? defaultValue
                : attribute.Description;
        }

        public static int GetValue(this Enum value)
        {
            var type = value.GetType();
            if (!Enum.IsDefined(type, value))
            {
                throw new Exception($"{type} 找不到此定義值({value.ToString()})");
            }

            return Convert.ToInt32(value);
        }
    }
}