using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventRegistrationAPP.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        public static string CapacityId
        {
            get
            {
                return AppSettings.GetValueOrDefault("CapacityId", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("CapacityId", value);
            }
        }
    }
}
