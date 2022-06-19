﻿using System;

namespace Invsion.Src.Shared.Errors
{
    class SettingNotFoundException : Exception
    {
        public SettingNotFoundException (string settingName)
            : base(String.Format("Setting not found for key: {0}", settingName))
        {}
    }
}
