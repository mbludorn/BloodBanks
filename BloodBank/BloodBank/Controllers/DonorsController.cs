using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPractice.Controllers
{
    public class DonorsController : Controller
    {
        //Step 1: crate a connects to our database
        Models.BloodBanksEntities db = new Models.BlookdbanksEntities();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            //list the contents of our cotact forms
            return View(db.BloodBanks);
        }

        public ActionResult Details(int id)
        {
            return View(db.BloodBanks.Find(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.BloodBankss.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.BloodBank bloodbanks)
        {
             //tell the db context that the cotact form needs to be updated
            db.Entry(bloodbanks).State = System.Data.EntityState.Modified;
            //save changes
            db.SaveChanges();

            //kick the user back to the list
            return RedirectToAction("Index", "Donor");
        }

        public ActionResult Delete(int id)
        {
            return View(db.Bloodbanks.Find(id));
        }

        public ActionResult DeleteConfirm(int id)
        {
            //get the form to delete from the database
            Models.BloodBanks formToDelete = db.Bloodbanks.Find(id);

            db.ContactForms.Remove(formToDelete);

            //save changes
            db.SaveChanges();

            //kick the user back to the list
            return RedirectToAction("Index", "Patient");



        }
