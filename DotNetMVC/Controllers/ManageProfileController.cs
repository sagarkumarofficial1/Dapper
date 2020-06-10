using DotNetMVC.Data.BAL;
using DotNetMVC.Data.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMVC.Controllers
{
    public class ManageProfileController : Controller
    {
        // GET: ManageProfile/Create
        public ActionResult Create()
        {
            var model = UserProfileMasterBAL.GetStudentProfileData(User.Identity.Name);
            model.CollageList = CollageMasterBAL.GetCollageList();
            model.GenderList = UserProfileMasterBAL.BindGender();
            return View(model);
        }

        // POST: ManageProfile/Create
        [HttpPost]
        public ActionResult Create(UserProfileMasterModel model)
        {
            model.StudentId = UserProfileMasterBAL.GetStudentProfileData(User.Identity.Name).StudentId;
            model.CollageList = CollageMasterBAL.GetCollageList();
            model.GenderList = UserProfileMasterBAL.BindGender();

            if (ModelState.IsValid)
            {
                UserProfileMasterBAL.CreateProfile(model);
                return RedirectToAction("Create");
            }
            else
            {
                return View(model);
            }
        }
    }
}
