using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplesOrdering.Models
{
    public class DeliOrder_UserModel
    {
        public List<DeliOrderModel> DeliOrders { get; set; }
        public UserInfoModel User { get; set; }
    }
}