using HCPeopleSearchApplication.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCPeopleSearchApplication.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace HCPeopleSearchApplication.Controllers
{
    public class PersonController : Controller
    {
        private PeopleDBContext db = new PeopleDBContext();
        // GET: Person
        public ActionResult Index()
        {          
            return View();
        }

        public JsonResult GetPersonDetails(string searchString)
        {

            if (searchString == null || searchString == "") {
                return Json("emptyString", JsonRequestBehavior.AllowGet);
            }
            var people = db.People.Where(acc => acc.FirstName.StartsWith(searchString)).ToList();
           // var result = JsonConvert.SerializeObject(people);
            return Json(people, JsonRequestBehavior.AllowGet);
        }

       
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Age,Address,Interests,image,FileName,ContentType")]Person person, HttpPostedFileBase upload)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {

                        person.FileName = System.IO.Path.GetFileName(upload.FileName);

                        person.ContentType = upload.ContentType;

                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            person.image = reader.ReadBytes(upload.ContentLength);
                        }

                        db.People.Add(person);

                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else {
                        return Content("Please upload your profile picture and create profile");
                    }
                    
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
           
           return Content("Please fill all the details to create profile,Please click back button of your browser");
        }

    

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

