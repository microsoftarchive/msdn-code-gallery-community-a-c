#region

using System.Collections.Generic;

#endregion

namespace BTL.Infrastructure.Configuration
{
    public interface ISectionConfiguration
    {
        void Add(string sectionName, string sectionValue, List<KeyValuePair<string, string>> valuePairs);
    }
}