using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentMangement.Models
{
    class Subscription
    {
        public int SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public string DurationOfSubscripition { get; set; }
        public int Price { get; set; }
    }
}
