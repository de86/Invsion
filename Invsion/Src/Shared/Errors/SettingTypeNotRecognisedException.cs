using System;

namespace Invsion.Src.Shared.Errors
{
    class SettingTypeNotRecognisedException : Exception
    {
        public SettingTypeNotRecognisedException (string settingName, string settingValue, string settingType)
            : base(String.Format("Setting type of {0} not recognised. Unable to parse setting {1} of type {2}", settingName))
        {}
    }
}
