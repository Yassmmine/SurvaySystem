using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace SurvaySystem.ApplicationProject.Common
{
    public static class CultureHelper
    {
        public static string GetResourceMessage(ResourceManager manager, string key)
        {
            return manager.GetString(key, System.Threading.Thread.CurrentThread.CurrentCulture);
        }
        public static string GetResourceMessage(ResourceManager manager, string key, string FieldName)
        {
            return string.Format(manager.GetString(key, System.Threading.Thread.CurrentThread.CurrentCulture), FieldName);
        }
        public static string GetResourceMessage(ResourceManager manager, string key, string FieldName,string value)
        {
            return string.Format(manager.GetString(key, System.Threading.Thread.CurrentThread.CurrentCulture), FieldName,value);
        }
        public static string GetResourceMessage(ResourceManager manager, string key, string FieldName, string value1,string value2)
        {
            return string.Format(manager.GetString(key, System.Threading.Thread.CurrentThread.CurrentCulture), FieldName, value1,value2);
        }
        public static string GetCurrentLanguage()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
        }
    }
}
