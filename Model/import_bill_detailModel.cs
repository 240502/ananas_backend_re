using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class import_bill_detailModel
    {
        public int? id { get; set; }
        public int? import_bill_id { get; set; }    
        public int? product_item_id { get; set; }
        public int? qty { get; set; }
        public int? price { get; set; }
        public string? product_attr { get; set; }
    }
}
