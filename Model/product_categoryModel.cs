using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class product_categoryModel
    {
        public int id { get; set; }
        public string category_name { get; set; }
        public int product_gender_id { get; set; }
        public int size_category_id { get; set; }
    }
}
