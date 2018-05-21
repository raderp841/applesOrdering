using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApplesOrdering.Models;
using ApplesOrdering.DAL;

namespace ApplesOrdering.Controllers
{
    public class OrdersController : ApiController
    {
        public IEnumerable<DeliOrderModel> GetDeliOrderModels(int id)
        {
            var output =new DeliOrderModel();
            OrdersDAL dal = new OrdersDAL();
            List<DeliOrderModel> orders = dal.GetAllDeliOrders();
            for(int i = 0; i < orders.Count; i++) 
            {
                if(orders[i].Id == id)
                {
                    output = orders[i];
                }
            }
            List<DeliOrderModel> outputt = new List<DeliOrderModel>();
            outputt.Add(output);
            return outputt;
        }
    }
}
