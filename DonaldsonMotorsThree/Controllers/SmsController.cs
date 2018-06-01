using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonaldsonMotorsThree.Migrations;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.Types;

namespace DonaldsonMotorsThree.Controllers
{
    public class SmsController : TwilioController
    {

        // GET: Sms
        public ActionResult SendStockAlertSms(string number)

        {
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];

            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(number);
            var from = new PhoneNumber(ConfigurationManager.AppSettings[""]);

          //  var message 
            return View();
        }
    }
}