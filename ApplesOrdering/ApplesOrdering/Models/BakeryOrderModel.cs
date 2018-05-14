using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplesOrdering.Models
{
    public class BakeryOrderModel
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime PickupTime { get; set; }
        public int UserInfoId { get; set; }
        public string Size { get; set; }
        public string Dough { get; set; }
        public string Icing { get; set; }
        public string MessageInfo { get; set; }
        public string BorderTrim { get; set; }
        public int KitNumber { get; set; }
        public string Kitname { get; set; }
        public bool IsActive { get; set; }
        public int StoreId { get; set; }
    }
}