using ClientApp.Models.ODataV4Sample.Models;
using Microsoft.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    /// <summary>
    /// ByKey用のユーテリティ
    /// </summary>
    public static class ODataQueryExtensions
    {
        public static PersonSingle ByKey(this DataServiceQuery<Person> self, int key)
        {
            return self.ByKey(new Dictionary<string, object>
            {
                { "Id", key }
            });
        }
    }
}
