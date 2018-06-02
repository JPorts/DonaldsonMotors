using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DonaldsonMotorsThree.Migrations;
using DonaldsonMotorsThree.Models;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace DonaldsonMotorsThree.Controllers
{
    public class SmsController : TwilioController
    {

        // GET: Sms
        public ActionResult SendStockAlertSms(string number, CarPart part)

        {
            // Get Twilio Account Details from App Settings//
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            // Initiliase Client//
            TwilioClient.Init(accountSid, authToken);

            var sendTo = new PhoneNumber(number);
            var sendFrom = new PhoneNumber(ConfigurationManager.AppSettings["PhoneNumber"]);

            var message = MessageResource.Create(
                to: sendTo,
                from: sendFrom,
                body: " STOCK ALERT: Stock Levels are low.Please submit a resupply order for " + part.Name + 
                      "\n Quantity requested: " + part.ReorderQuantity


               ) ;
            return Content(message.Sid);
        }

        //GET: Sms
        public ActionResult SendVehicleCollectionSms(string number, VehicleDetails vehicle)

        {
            // Get Twilio Account Details from App Settings//
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            // Initiliase Client//
            TwilioClient.Init(accountSid, authToken);

            var sendTo = new PhoneNumber(number);
            var sendFrom = new PhoneNumber(ConfigurationManager.AppSettings["PhoneNumber"]);

            var message = MessageResource.Create(
                to: sendTo,
                from: sendFrom,
                body:"Your vehicle is ready to be collected. \n " + "All requested work on the " + vehicle.Make + " " + vehicle.Model + " has been completed."

            );

            return Content(message.Sid);
        }

        public ActionResult SendInvoiceAlertSms(string number)

        {
            // Get Twilio Account Details from App Settings//
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            // Initiliase Client//
            TwilioClient.Init(accountSid, authToken);

            var sendTo = new PhoneNumber(number);
            var sendFrom = new PhoneNumber(ConfigurationManager.AppSettings["PhoneNumber"]);

            var message = MessageResource.Create(
                to: sendTo,
                from: sendFrom,
                body: "an Invoice from Donaldson Motors has been sent to your email address. "

            );

            return Content(message.Sid);
        }
    }
}