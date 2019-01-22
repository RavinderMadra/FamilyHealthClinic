using DemoModel.ViewModel;
using DemoService.HomeNamespace;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace Carisbrook.Controllers
{

    public class HomeController : Controller
    {
        HomeService homeService = new HomeService();
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public JsonResult SaveAppointment(AppointmentViewModel objAppointment)
        {
            string filepath = Server.MapPath(ConfigurationManager.AppSettings["EmailTemplatePath"].ToString() 
                + "AppointmentTemplate.html");
            // homeService.SaveAppointment(objAppointment);
            if (homeService.SaveAppointment(objAppointment))
            {
         
                Mailer.SendEmail("Appointment Mail", filepath,objAppointment);
                return Json("Your Appointment date is booked .You will get confirmation mail shortly ", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Mailer.SendEmail("Appointment Mail", filepath, objAppointment);
                return Json("Unable to book  your appointment .Please try again later", JsonRequestBehavior.DenyGet);
            }

        }
        public JsonResult GetAppointmentTimes(string date)
        {
          var res = homeService.GetAvailableAppointmentTime(date);
            //if (homeService.SaveAppointment(objAppointment))
           return Json(res, JsonRequestBehavior.AllowGet);
            //else
            //    return Json("Unable to book  your appointment .Please try again later", JsonRequestBehavior.DenyGet);

        }
        public JsonResult GetUnAVailableDates()
        {
            var res = homeService.GetUnAvailableDates();
            //if (homeService.SaveAppointment(objAppointment))
            return Json(res, JsonRequestBehavior.AllowGet);
           
        }
    }
}