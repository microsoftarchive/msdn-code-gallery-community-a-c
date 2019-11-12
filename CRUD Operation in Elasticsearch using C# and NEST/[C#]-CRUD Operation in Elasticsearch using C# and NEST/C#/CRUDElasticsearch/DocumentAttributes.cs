using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDElasticsearch
{
    class DocumentAttributes
    {
        public string id { get; set; }
        public string name { get; set; }
        public string original_voice_actor { get; set; }
        public string animated_debut { get; set; }
    }
}
