using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class payment_methodModel
    {
        public int? id { get; set; }
        public int? payment_type_id {  get; set; }
        public string? provider {  get; set; }
        public string? account_number { get; set; }
        public DateTime? expiry_date { get; set; }
    }
}
