using DotNetMVC.Data.BAL;
using DotNetMVC.Data.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMVC.Controllers
{
    public class AcademicController : Controller
    {
        // GET: Academic
        public ActionResult Index()
        {
            var model = AcademicMasterBAL.AcadamicList(User.Identity.Name);
            return View(model);
        }

        // GET: Academic/Create
        public ActionResult Create()
        {

            var studentId = UserProfileMasterBAL.GetStudentProfileData(User.Identity.Name).StudentId;
            AcadamicMasterModel model = new AcadamicMasterModel();
            model.CollageName =  CollageMasterBAL.GetCollage(studentId.ToString()).CollageName;
            model.SemesterList = AcademicMasterBAL.BindSamester();
            model.GradeList= AcademicMasterBAL.BindGrade();

            return View(model);
        }

        // POST: Academic/Create
        [HttpPost]
        public ActionResult Create(AcadamicMasterModel model)
        {
            var studentId = UserProfileMasterBAL.GetStudentProfileData(User.Identity.Name).StudentId;
            model.CollageName = CollageMasterBAL.GetCollage(studentId.ToString()).CollageName;
            model.SemesterList = AcademicMasterBAL.BindSamester();
            model.GradeList = AcademicMasterBAL.BindGrade();
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    AcademicMasterBAL.CreateProfile(model, studentId.ToString());
                    return RedirectToAction("Index");
                }
                catch(Exception Ex)
                {
                    return View(Ex);
                }
            }else
            {
                return View(model);
            }
        }

        // GET: Academic/Edit/5
        public ActionResult Edit(int id)
        {
            var studentId = UserProfileMasterBAL.GetStudentProfileData(User.Identity.Name).StudentId;
            var model = AcademicMasterBAL.Acadamic(User.Identity.Name, id);
            model.CollageName = CollageMasterBAL.GetCollage(studentId.ToString()).CollageName;
            model.SemesterList = AcademicMasterBAL.BindSamester();
            model.GradeList = AcademicMasterBAL.BindGrade();
            return View(model);
        }

        // POST: Academic/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AcadamicMasterModel model)
        {
            try
            {
                // TODO: Add update logic here
                var studentId = UserProfileMasterBAL.GetStudentProfileData(User.Identity.Name).StudentId;
                AcademicMasterBAL.UpdateAcademic(model, studentId.ToString(), id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Academic/Delete/5
        public ActionResult Delete(int id)
        {
            var studentId = UserProfileMasterBAL.GetStudentProfileData(User.Identity.Name).StudentId;
            AcademicMasterBAL.DeleteAcademic(studentId.ToString(), id);
            return RedirectToAction("Index");

        }
    }
}
