using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExplicitInterfaceImplementationSample
{
    public class MyCollection : IDataErrorInfo
    {
        private Dictionary<string, string> _data = new Dictionary<string, string>();

        public string this[string key]
        {
            get => _data[key];
            set
            {
                if (_data.ContainsKey(key))
                {
                    _data[key] = value;
                }
                else
                {
                    _data.Add(key, value);
                }
            }
        }

        public int Data1 { get; set; }
        public int Data2 { get; set; }

        string? IDataErrorInfo.this[string columnName] =>
            columnName switch
            {
                nameof(Data1) => Data1 > 5 ? "error with Data1" : null,
                nameof(Data2) => Data2 > 3 ? "error with Data2" : null,
                _ => null
            };

        string IDataErrorInfo.Error => throw new NotImplementedException();
    }
}
