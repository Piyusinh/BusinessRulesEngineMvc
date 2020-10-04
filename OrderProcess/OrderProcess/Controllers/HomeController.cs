using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderProcess.ProcessingModule;

namespace OrderProcess.Controllers
{
    public class HomeController : BaseController
    {
        private IPostPaymentService _service;
        public HomeController(IPostPaymentService service)
        {
            _service = service;
            _service.Register(this);
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StartPostPaymentAction(string id )
        {
            return Content(_service.StartPostPaymentAction(id));
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}