using CrudAppUsingADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudAppUsingADO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            StudenDbcontext db = new StudenDbcontext();
            List<Student> obj = db.GetStudents();
            return View(obj);
        }

        public ActionResult create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult create(Student std)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    StudenDbcontext context = new StudenDbcontext();
                    bool check = context.AddStudent(std);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "Data Inserted Successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }

                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Edit(int id)
        {
            StudenDbcontext context = new StudenDbcontext();
            var row = context.GetStudents().Find(model => model.id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id, Student std)
        {
            if (ModelState.IsValid == true)
            {
                StudenDbcontext context = new StudenDbcontext();
                bool check = context.UpdateStudent(std);
                if (check == true)
                {
                    TempData["UpdateMessage"] = "Data Updated Successfully";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }

            }
            return View();
        }

        public ActionResult Details(int id)
        {
            StudenDbcontext context = new StudenDbcontext();
            var row = context.GetStudents().Find(model => model.id == id);
            return View(row);
        }
        public ActionResult Delete(int id)
        {
            StudenDbcontext context = new StudenDbcontext();
            var row = context.GetStudents().Find(model => model.id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Delete(int id,Student std)
        {
            StudenDbcontext context = new StudenDbcontext();
            bool check = context.DeleteStudent(id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "Data Deleted Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}