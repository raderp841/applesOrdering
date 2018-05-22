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
    public class UpdateOrderController : ApiController
    {
        [HttpPost]
        [Route("api/updateOrder/{id}")]
        public IHttpActionResult UpdateItem(int id)
        {
            OrdersDAL dal = new OrdersDAL();
            dal.ChangeActivity(id);
            return Ok();
        }
    }
}
