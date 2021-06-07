using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buglog.Model.Infrastructure
{
    public static class ObjectComparer<T>
    {
        public static Dictionary<string, string> ComparePropertyValues(T originalObj, T newObj)
        {
            var diff = new Dictionary<string, string>();
            var properties = typeof(T).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                var originalValue = properties[i].GetValue(originalObj, null);
                var newValue = properties[i].GetValue(newObj, null);
                if (originalValue is null && newValue is null)
                {
                    continue;
                }
                if (originalValue.Equals(newValue))
                {
                    continue;
                }
                if (originalObj?.GetHashCode() != newValue?.GetHashCode())
                {
                    diff[$"OriginalValue({properties[i].Name})"] = originalValue?.ToString();
                    diff[$" NewValue({properties[i].Name})"] = newValue?.ToString();
                }
            }
            return diff;
        }
    }
}
