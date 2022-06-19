using System;
using System.Collections.Generic;
using System.Text;

using Invsion.Src.Shared.Errors;

namespace Invsion.Src.Shared.Settings
{
    internal class SettingsManager : ISettingsManager
    {
        private Dictionary<string, Setting> _settings;



        public SettingsManager ()
        {
            _settings = new Dictionary<string, Setting>();

            _initialize();
        }



        private void _initialize ()
        {
            // Move to JSON/TXT file and read
            AddSetting("RESOLUTION_WIDTH", "1920", "1920", "int");
            AddSetting("RESOLUTION_HEIGHT", "1080", "1080", "int");
            AddSetting("WINDOW_WIDTH", "1280", "1280", "int");
            AddSetting("WINDOW_HEIGHT", "720", "720", "int");
        }



        public void AddSetting (string key, string value, string defaultValue, string type)
        {
            Setting setting = new Setting(key, value, defaultValue, type);
            _settings.Add(key, setting);
        }



        public Setting GetSetting (string key)
        {
            Setting setting;
            _settings.TryGetValue(key, out setting);

            if (setting == null)
            {
                throw new SettingNotFoundException(key);
            }

            return setting;
        }



        public T GetSettingValue<T> (string key)
        {
            Setting setting = GetSetting(key);

            return setting.GetParsedValue<T>();
        }



        public void SetSetting (string key, string value)
        {
            Setting setting = GetSetting(key);

            setting.SetValue(value);
        }
    }
}
