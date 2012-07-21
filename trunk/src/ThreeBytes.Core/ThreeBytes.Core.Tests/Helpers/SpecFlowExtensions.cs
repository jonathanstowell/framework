using System;
using TechTalk.SpecFlow;

namespace ThreeBytes.Core.Tests.Helpers
{
    public static class SpecFlowExtensions
    {
        public static bool HasKey(this TableRow row, string key)
        {
            return row.ContainsKey(key);
        }

        public static T ProcessRow<T>(this TableRow row, string key) 
        {
            bool parseResult = false;
            T item = default(T);

            if (row.HasKey(key))
            {
                if (typeof(T) == typeof(int))
                {
                    int parseItem;
                    parseResult = int.TryParse(row[key], out parseItem);
                    item = (T)(object)parseItem;
                }
                if (typeof(T) == typeof(bool))
                {
                    bool parseItem;
                    parseResult = bool.TryParse(row[key], out parseItem);
                    item = (T)(object)parseItem;
                }
                if (typeof(T) == typeof(DateTime))
                {
                    DateTime parseItem;
                    parseResult = DateTime.TryParse(row[key], out parseItem);
                    item = (T)(object)parseItem;
                }
                if (typeof(T) == typeof(double))
                {
                    double parseItem;
                    parseResult = double.TryParse(row[key], out parseItem);
                    item = (T)(object)parseItem;
                }
                if (typeof(T) == typeof(string))
                {
                    item = (T)(object)row[key];
                }
            }

            return item;
        }
    }
}
