using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DonaldsonMotorsThree.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult PayIndex()
        {
            return View();
        }
    }
}