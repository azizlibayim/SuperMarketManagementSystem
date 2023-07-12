using Super_Market_Management_System.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Management_System.Common.Models
{
    public class SalesItem : BaseEntity
    {
        private static int _count = 0;
        public SalesItem()
        {
            Id = _count;
            _count++;
        }

        public string Product { get; set; }
        public string Count { get; set; }
    }
}
    



