using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class product_variationModel
    {
        public int? id { get; set; }
        public int? product_item_id { get; set; }
        public int? size_id {  get; set; }
        public int? qty_in_storage {  get; set; }
    }
}
