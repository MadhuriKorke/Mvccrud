using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Mvccrud.Models;

namespace Mvccrud.Controllers
{
    public class AdminController : Controller
    {
        //BALuser objuser=new BALuser();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Create(User obj)
        {
            if (ModelState.IsValid) // Server-side validation check
            {
                BALuser objb = new BALuser();
                objb.save(obj);
                TempData["SuccessMessage"] = "Data has been saved successfully!";
                return RedirectToAction("Create"); // Redirect to avoid form resubmission
            }
            else
            {
                TempData["ErrorMessage"] = "Please fill all required fields.";
                return View(obj); // Return the same view with validation errors
            }
        }

        public ActionResult list()
        {
            DataSet ds = new DataSet();
            BALuser objuser = new BALuser();
            ds = objuser.GetUser();
            User objU = new User();
            List<User> objlist = new List<User>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                User objU2 = new User();
                objU2.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["iD"].ToString());
                objU2.UName = ds.Tables[0].Rows[i]["Name"].ToString();
                objU2.UAddress = ds.Tables[0].Rows[i]["Address"].ToString();
                objlist.Add(objU2);
            }
            objU.Users = objlist;
            return View(objU);

           
        }

        //[HttpGet]
        //public ActionResult Edit(int id) 
        //{
        // User obj1 = new User();
        //    obj1.ID = id;
        //    BALuser user = new BALuser();
        //    DataSet dss= new DataSet();
        //    dss = user.fetchrecord(obj1);
        //    User objU1 = new User();
        //    //List<User> objlist1 = new List<User>();

        //        User objU2 = new User();
        //        objU2.ID = Convert.ToInt32(dss.Tables[0].Rows[0]["iD"].ToString());
        //        objU2.UName = dss.Tables[0].Rows[0]["Name"].ToString();
        //        objU2.UAddress = dss.Tables[0].Rows[0]["Address"].ToString();
        //        //objlist1.Add(objU2);

        //    //objU1.Users = objlist1;
        //    return View(objU2);

        //    //return View(obj1);
        //}


        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id <= 0) // Check if ID is valid
            {
                TempData["ErrorMessage"] = "Invalid ID provided.";
                return RedirectToAction("Index"); // Redirect to prevent loading the Edit page with invalid ID
            }

            BALuser user = new BALuser();
            User objU2 = new User();
            DataSet dss = user.fetchrecord(new User { ID = id });

            if (dss.Tables[0].Rows.Count > 0)
            {
                objU2.ID = Convert.ToInt32(dss.Tables[0].Rows[0]["iD"].ToString());
                objU2.UName = dss.Tables[0].Rows[0]["Name"].ToString();
                objU2.UAddress = dss.Tables[0].Rows[0]["Address"].ToString();
            }
            else
            {
                TempData["ErrorMessage"] = "No record found for the given ID.";
                return RedirectToAction("Index");
            }

            return View(objU2);
        }


        //[HttpPost]
        //public ActionResult Edit(User obj) 
        //{
        //    BALuser obje=new BALuser();
        //    obje.update(obj);
        //    TempData["SuccessMessage"] = "Data has been saved successfully!";
        //    return View();
        //}



        [HttpPost]
        public ActionResult Edit(User obj)
        {
            if (ModelState.IsValid) // Validate the model
            {
                BALuser obje = new BALuser();
                obje.update(obj);
                TempData["SuccessMessage"] = "Data has been updated successfully!";
                return RedirectToAction("Edit", new { id = obj.ID }); // Redirect to the same page to avoid resubmission
            }
            else
            {
                TempData["ErrorMessage"] = "Please fill all required fields.";
                return View(obj); // Return to the view with validation errors
            }
        }


        [HttpPost]
        public ActionResult show(int id)
        {
            User obj1 = new User();
            obj1.ID = id;
            BALuser user = new BALuser();
            DataSet dss = new DataSet();
            dss = user.fetchrecord(obj1);
            User objU1 = new User();
            //List<User> objlist1 = new List<User>();

            User objU2 = new User();
            objU2.ID = Convert.ToInt32(dss.Tables[0].Rows[0]["iD"].ToString());
            objU2.UName = dss.Tables[0].Rows[0]["Name"].ToString();
            objU2.UAddress = dss.Tables[0].Rows[0]["Address"].ToString();
            //objlist1.Add(objU2);

            //objU1.Users = objlist1;
            return View(objU2);
            //return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            User obj1 = new User();
            obj1.ID = id;
            DataSet dss = new DataSet();
            BALuser objuser1 = new BALuser();
            dss = objuser1.fetchrecord(obj1);
            User objU11 = new User();
            //List<User> objlist1 = new List<User>();

            User objU22 = new User();
            objU22.ID = Convert.ToInt32(dss.Tables[0].Rows[0]["iD"].ToString());
            objU22.UName = dss.Tables[0].Rows[0]["Name"].ToString();
            objU22.UAddress = dss.Tables[0].Rows[0]["Address"].ToString();
            //objlist1.Add(objU2);

            //objU1.Users = objlist1;
            return View(objU22);

            //return View("list");
        }

        [HttpPost]
        public ActionResult Delete(User objd)
        {

            BALuser objbd = new BALuser();
            objbd.delete(objd);
            return RedirectToAction("list");
            
            
            //return View();
        }

        [HttpGet]
        public ActionResult xyz()
        {
            return View();
        }

      



    }
}