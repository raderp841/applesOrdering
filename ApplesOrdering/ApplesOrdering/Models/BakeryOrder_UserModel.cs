using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplesOrdering.Models
{
    public class BakeryOrder_UserModel
    {
        public List<BakeryOrderModel> BakeryOrders { get; set; }
        public UserInfoModel User { get; set; }
    }
}