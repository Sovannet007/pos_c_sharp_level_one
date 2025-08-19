using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_LEVEL_01.Model
{
    public class Order
    {
        public int order_id { get; set; }
        public int customer_id { get; set; }
        public DateTime required_date { get; set; }
        public DateTime shipped_date { get; set; }
        public int store_id {  get; set; }
        public int staff_id { get; set; }
    }
}
