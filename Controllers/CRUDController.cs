using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeeksForGeeks.Controllers
{
    public class CRUDController : Controller
    {
        // To create View of this Action result
        public ActionResult create()
        {
            return View();
        }

        // Specify the type of attribute i.e.
        // it will add the record to the database
        [HttpPost]
        public ActionResult create(Student model)
        {

            // To open a connection to the database
            using (var context = new g4gEntities1())
            {
                // Add data to the particular table
                context.Students.Add(model);

                // save the changes
                context.SaveChanges();
            }
            string message = "Created the record successfully";

            // To display the message on the screen
            // after the record is created successfully
            ViewBag.Message = message;

            // write @Viewbag.Message in the created
            // view at the place where you want to
            // display the message
            return View();
        }

        [HttpGet] // Set the attribute to Read
        public ActionResult Read()
        {
            using (var context = new g4gEntities1())
            {

                // Return the list of data from the database
                var data = context.Students.ToList();
                return View(data);
            }
        }

        // To fill data in the form 
        // to enable easy editing
        public ActionResult Update(int Studentid)
        {
            using (var context = new g4gEntities1())
            {
                var data = context.Students.Where(x => x.StudentNo == Studentid).SingleOrDefault();
                return View(data);
            }
        }

        // To specify that this will be 
        // invoked when post method is called
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int Studentid, Student model)
        {
            using (var context = new g4gEntities1())
            {

                // Use of lambda expression to access
                // particular record from a database
                var data = context.Students.FirstOrDefault(x => x.StudentNo == Studentid);

                // Checking if any such record exist 
                if (data != null)
                {
                    data.Name = model.Name;
                    data.Sections = model.Sections;
                    data.EmailId = model.EmailId;
                    data.Branch = model.Branch;
                    context.SaveChanges();

                    // It will redirect to 
                    // the Read method
                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }


        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Studentid)
        {
            using (var context = new g4gEntities1())
            {
                var data = context.Students.FirstOrDefault(x => x.StudentNo == Studentid);
                if (data != null)
                {
                    context.Students.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }

    }
}