using DotNetMVC.Data.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMVC.Controllers
{
    public class ValidationController : Controller
    {
        [HttpGet]
        public JsonResult IsEmailExist(string Email)
        {
            try
            {
                Boolean result = UserMasterBAL.IsEmailExist(Email);
                if (result)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}