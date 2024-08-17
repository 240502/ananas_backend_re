using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class import_billModel
    {
        public int id { get; set; }
        public DateTime import_date { get; set; }
        public int provider_id { get; set; }
        public int user_id { get; set; }
    }
}
