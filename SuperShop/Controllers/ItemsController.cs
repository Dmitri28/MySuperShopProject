using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuperShop.Models;

namespace SuperShop.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        static int CategoryID = 0;

        private  ShopEntities db = new ShopEntities();
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Category);
            return View(items.ToList());
     
        }

        public ActionResult IndexByCategory(int? id)
        {
            var items = db.Items.Include(i => i.Category).Where(i=>i.CategoryId == id);
            Session["CategoryID"] = id;



            var category = db.Category.Find(id);
            if (category != null)
            {
                ViewBag.CategoryName = category.Name;
            }

            return View(items.ToList());
        }

        // GET: Items/Details/5


        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name");
            return View();
        }

        public ActionResult CreateByCategory()
        {
            if (Session["CategoryID"] == null)
            {
                return RedirectToAction("Index", "Categories");
            }

            int categoryID = (int)(Session["CategoryID"]);
            var category = db.Category.Find(categoryID);
            if (category != null)
            {
                ViewBag.CategoryName = category.Name;
            }

            return View();
        }


        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateByCategory([Bind(Include = "Id,Name,Description")] Items item)
        {

            if (Session["CategoryID"] == null)
            {
                return RedirectToAction("Index", "Categories");
            }

            int categoryID = (int)(Session["CategoryID"]);
            item.CategoryId = categoryID;

            try
            {
                db.Items.Add(item);
                db.SaveChanges();

                return RedirectToAction("IndexByCategory", "Items", new { id = categoryID });
            }
            catch
            {
                return View();
            }
        }


        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId,Description")] Items item)
        {
            try
            {
                db.Items.Add(item);
                db.SaveChanges();
             
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
       
        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = db.Items.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CategoryId,Description")] Items items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(items);
        }


        // POST: Items/Edit/5

        // GET: Items/Delete/5
        public ActionResult Delete(int?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Items items = db.Items.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
              
            return View(items);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            Items items = db.Items.Find(id);
            db.Items.Remove(items);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Items/Delete/5
       
    }
}
