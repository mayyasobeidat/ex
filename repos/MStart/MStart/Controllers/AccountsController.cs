using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using MStart.Models;

namespace MStart.Controllers
{
    public class AccountsController : Controller
    {
        private MStartEntities db = new MStartEntities();

        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.User_Table);
            return View(accounts.ToList());
        }
        public ActionResult Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return View("Index", db.Accounts.ToList());
            }
            else
            {
                var searchResults = db.Accounts
                    .Where(p => p.Account_Number.ToLower().Contains(search.ToLower())
                    || p.User_ID.ToString() == search
                    || p.ID.ToString() == search).ToList();

                if (searchResults != null && searchResults.Count > 0)
                {
                    return View("Index", searchResults);
                }

                else
                {
                    ViewBag.Message = "The Account Not Found.";
                    return View("Index", searchResults);

                }
            }
        }
        public ActionResult DeleteUser(int? ID)
        {
            var Accountt = db.Accounts.Find(ID);

            Accountt.Status = 2; //Delete

            db.Configuration.ValidateOnSaveEnabled = false;

            db.Entry(Accountt).State = EntityState.Modified;
            db.SaveChanges();

            db.Configuration.ValidateOnSaveEnabled = true;

            return RedirectToAction("Index");
        }

 

        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                var existingUserIDs = db.Accounts.Select(a => a.User_ID).ToList();

                var users = db.User_Table
                    .Where(u => !existingUserIDs.Contains(u.ID))
                    .Select(u => new SelectListItem
                    {
                        Value = u.ID.ToString(),
                        Text = u.Username
                    })
                    .ToList();
                ViewBag.User_ID = users;
                return View();
            }
            else
            {
                Account account = db.Accounts.Find(id);
                ViewBag.User_ID = new SelectList(db.User_Table.Where(u => db.Accounts.Any(a => a.ID == id && a.User_ID == u.ID)), "ID", "Username", account.User_ID);
                Session["DateTime_UTC"] = account.DateTime_UTC;
                Session["Server_DateTime"] = account.Server_DateTime;
                return View(account);
            }
  
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "ID,User_ID,Server_DateTime,DateTime_UTC,Update_DateTime_UTC,Account_Number,Balance,Currency,Status")] Account account, int? id, string submitButton)
        {
            if (ModelState.IsValid)
            {
              

                if (id == null)
                {
                    account.Server_DateTime = DateTime.Now;
                    account.DateTime_UTC = DateTime.UtcNow;

                    db.Accounts.Add(account);
                }
                else
                {
                    account.Update_DateTime_UTC = DateTime.UtcNow;
                    account.DateTime_UTC = (DateTime)Session["DateTime_UTC"];
                    account.Server_DateTime = (DateTime)Session["Server_DateTime"];
                    db.Entry(account).State = EntityState.Modified;
                }

                db.SaveChanges();

                if (submitButton == "Save")
                {
                    return RedirectToAction("Index");
                }
                else if (submitButton == "Save & Continue")
                {
                    return RedirectToAction("Create", new { id = account.ID });
                }
            }

            ViewBag.User_ID = new SelectList(db.User_Table, "ID", "Username", account.User_ID);
            return View(account);
        }

    }
}
