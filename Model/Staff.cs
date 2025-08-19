using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_LEVEL_01.Model
{
    public class Staff
    {
        public int staff_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string active { get; set; }
        public int store_id{ get; set; }
        public string store_name { get; set; }
        public int  manager_id{ get; set; }
        public string  manager_name{ get; set; }
    }
}
