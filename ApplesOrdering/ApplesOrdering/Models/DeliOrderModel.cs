using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplesOrdering.Models
{
    public class DeliOrderModel
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime PickUpTime { get; set; }
        public int UserInfoId { get; set; }
        public int NumberOfPieces { get; set; }
        public bool IsActive { get; set; }
        public int StoreId { get; set; }
    }
}