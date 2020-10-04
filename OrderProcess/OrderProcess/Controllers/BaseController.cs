using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderProcess.Controllers
{
    public interface IBaseController
    {
        ModelStateDictionary ModelState { get; }
    }
    public abstract class BaseController : Controller, IBaseController
    {
    }
}