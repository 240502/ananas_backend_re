using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class product_itemModel
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int colour_id { get; set; }
        public int normal_price { get; set; }
        public int sale_price { get; set; }
        public int style_id {get;set;}
        public string style_name { get; set;}
        public string colour_name { get; set;}
    }
}
