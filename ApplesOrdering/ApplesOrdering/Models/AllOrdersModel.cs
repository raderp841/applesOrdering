using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplesOrdering.Models
{
    public class AllOrdersModel
    {
        public List<DeliOrderModel> DeliOrders { get; set; }
        public List<BakeryOrderModel> BakeryOrders { get; set; }
        public UserInfoModel User { get; set; }
    }
}