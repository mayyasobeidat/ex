using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using MStart.Models;

namespace MStart.Controllers
{
    public class HomeController : Controller
    {
        private MStartEntities db = new MStartEntities();

        public ActionResult Index()
        {
            return View(db.User_Table.ToList());
        }

        public ActionResult Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return View("Index", db.User_Table.ToList());
            }
            else
            {
                var searchResults = db.User_Table
                    .Where(p => p.Username.ToLower().Contains(search.ToLower())
                            || p.Email.ToLower().Contains(search.ToLower())
                            || p.ID.ToString() == search).ToList();

                if (searchResults != null && searchResults.Count > 0)
                {
                    return View("Index", searchResults);
                }

                else
                {
                    ViewBag.Message = "The User Not Found.";
                    return View("Index", searchResults);

                }
            }
        }

        public ActionResult DeleteUser(int? ID)
        {
            var Users = db.User_Table.Find(ID);
            var Acc = db.Accounts.FirstOrDefault(a => a.User_ID == ID);

            if (Acc != null)
            {
                var accID = Acc.ID;
            }      
            var UserAcc = db.Accounts.Find(Acc);


            // Disable entity validation
            db.Configuration.ValidateOnSaveEnabled = false;

            Users.Status = 2; //Delete
            db.Entry(Users).State = EntityState.Modified;

            if (UserAcc != null)
            {
                UserAcc.Status = 2; //Delete
                db.Entry(UserAcc).State = EntityState.Modified;
            }

            db.SaveChanges();

            // Enable entity validation again
            db.Configuration.ValidateOnSaveEnabled = true;

            return RedirectToAction("Index");
        }




        public ActionResult Create(int? id)
        {
            ViewBag.id = id;
            if (id == null)
            {
                return View();
            }
            else
            {
                User_Table user_Table = db.User_Table.Find(id);
                Session["DateTime_UTC"] = user_Table.DateTime_UTC;
                Session["Server_DateTime"] = user_Table.Server_DateTime;
                Session["Date_Of_Birth"] = user_Table.Date_Of_Birth;

                return View(user_Table);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Server_DateTime,DateTime_UTC,Update_DateTime_UTC,Username,Email,First_Name,Last_Name,Status,Gender,Date_Of_Birth")] User_Table user_Table, int? id, string submitButton)
        {
            if (ModelState.IsValid)
            {
                // Validate username
                if (!Regex.IsMatch(user_Table.Username, "^[a-zA-Z0-9]+$"))
                {
                    ModelState.AddModelError("Username", "Username should only contain English letters and numbers.");
                    return View(user_Table);
                }

                // Validate email
                if (!IsValidEmail(user_Table.Email))
                {
                    ModelState.AddModelError("Email", "Invalid email format.");
                    return View(user_Table);
                }

                // Check if username is unique
                if (db.User_Table.Any(u => u.Username == user_Table.Username && u.ID != id))
                {
                    ModelState.AddModelError("Username", "The username is already taken.");
                    return View(user_Table);
                }

                // Check if email is unique
                if (db.User_Table.Any(u => u.Email == user_Table.Email && u.ID != id))
                {
                    ModelState.AddModelError("Email", "The email is already taken.");
                    return View(user_Table);
                }

                if (id == null)
                {
                    user_Table.Server_DateTime = DateTime.Now;
                    user_Table.DateTime_UTC = DateTime.UtcNow;

                    db.User_Table.Add(user_Table);
                }
                else
                {
                    user_Table.Update_DateTime_UTC = DateTime.UtcNow;
                    user_Table.DateTime_UTC = (DateTime)Session["DateTime_UTC"];
                    user_Table.Server_DateTime = (DateTime)Session["Server_DateTime"];
                    user_Table.Date_Of_Birth = (DateTime)Session["Date_Of_Birth"];

                    db.Entry(user_Table).State = EntityState.Modified;
                }

                db.SaveChanges();

                if (submitButton == "Save")
                {
                    return RedirectToAction("Index");
                }
                else if (submitButton == "Save & Continue")
                {
                    return RedirectToAction("Create", new { id = user_Table.ID });
                }
            }

            return View(user_Table);
        }



        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }


    }
}