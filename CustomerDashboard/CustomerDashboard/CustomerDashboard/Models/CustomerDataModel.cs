using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDashboard.Models
{
    class CustomerJson
    {
        public class Customer
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public string Tel { get; set; }
            public string Postal { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string Birthday { get; set; }
            public string Age { get; set; }
        }

        public List<Customer> Customers { get; set; }
    }
}
