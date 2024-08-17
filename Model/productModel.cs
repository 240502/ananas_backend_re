using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class productModel
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set;}
        public int status_id { get; set; }  
        public int collection_id { get; set; }
        public List<product_itemModel> product_items { get; set; }

    }
}
