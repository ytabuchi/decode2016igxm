using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF_SalesDashboard.Models
{
    public class SalesModel
    {
        public string Area { get; set; }
        public string StoreName { get; set; }
        public string Category { get; set; }
        public string Segment { get; set; }
        public double Sales { get; set; }
    }
}
