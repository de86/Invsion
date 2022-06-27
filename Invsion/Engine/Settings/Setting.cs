using System;
using System.Collections.Generic;
using System.Text;

using Invsion.Engine.Errors;

namespace Invsion.Engine.Settings
{
    public class Setting
    {
        private readonly string _key;
        private string _value;
        private readonly string _defaultValue;
        // convert to enum
        private readonly string _type;



        public Setting (string key, string value, string defaultValue, string type)
        {
            _key = key;
            _value = value;
            _defaultValue = defaultValue;
            _type = type;
        }



        public string GetKey ()
        {
            return _key;
        }



        public string GetRawValue ()
        {
            return _value;
        }



        public T GetParsedValue<T> ()
        {
            return (T)Convert.ChangeType(_value, typeof(T));
        }



        public void SetValue (string value)
        {
            _value = value;
        }



        public void Reset ()
        {
            _value = _defaultValue;
        }
    }
}
