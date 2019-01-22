
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using DemoService.AdminNamespace;
using DemoModel.ViewModel;

namespace Carisbrook.Controllers
{
    public class AdminController : Controller
    {
        AdminService adminService = new AdminService();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManageAppointment(int? pageSize, int? page)
        {

            int pageDataSize = (pageSize ?? 10);
            int pageNumber = (page ?? 1);

            ViewBag.PageSize = pageDataSize;

            var list = adminService.GetAppointmentList().ToPagedList(pageNumber, pageDataSize);
            return Request.IsAjaxRequest() ? (ActionResult)PartialView("_AppointmentContent", list) : View(list);

        }
        public ActionResult ManagePaitent(int? pageSize, int? page)
        {

            int pageDataSize = (pageSize ?? 10);
            int pageNumber = (page ?? 1);

            ViewBag.PageSize = pageDataSize;

            var list = adminService.GetPaitentList().ToPagedList(pageNumber, pageDataSize);
            return Request.IsAjaxRequest() ? (ActionResult)PartialView("_PaitentContent", list) : View(list);

        }
        public ActionResult PatientDetail(int data)
        {
            var patientdetail = adminService.GetPatientdetailById(data);
            ViewBag.list = patientdetail;
            return View();

                
        }
        public ActionResult AddUnAvailableDate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUnAvailableDate(UnAvailableViewModel data)
        {
            if (adminService.SaveUnAvailableDate(data))
            {
                return RedirectToAction("ManageUnAvailableDate");
            }
            else {
                 return View(); }
            
        }
        public ActionResult ManageUnAvailableDate()
        {
            return View();
        }
    }
}