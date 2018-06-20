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
    public class BakeryUpdateOrderController : ApiController
    {
        [HttpPost]
        [Route("api/bakeryUpdateOrder/{id}")]
        public IHttpActionResult UpdateBakeryItem(int id)
        {
            OrdersDAL dal = new OrdersDAL();
            dal.ChangeActivityBakery(id);
            return Ok();
        }
    }
}
