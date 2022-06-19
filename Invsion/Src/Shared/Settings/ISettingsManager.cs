using System;
using System.Collections.Generic;
using System.Text;

namespace Invsion.Src.Shared.Settings
{
    public interface ISettingsManager
    {
        public void AddSetting (string key, string value, string defaultValue, string type);

        public void SetSetting (string key, string value);

        public Setting GetSetting (string key);

        public T GetSettingValue<T> (string key);
    }
}
