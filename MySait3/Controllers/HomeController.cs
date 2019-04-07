using MySait3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySait3.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            //var works = db.Works.Include(c => c.Curse);
            return View(/*works.ToList()*/);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var works = db.Works;
            //ViewBag.Works = works;
            return View(works);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var curs = db.Curses;
            //ViewBag.Curses = curs;
            return View(curs);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateCurse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCurse(Curse curs)
        {
            db.Curses.Add(curs);
            db.SaveChanges();

            return RedirectToAction("Contact");
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteCurse(int Id)
        {
            Curse c = db.Curses.Find(Id);
            if (c == null)
            {
                return HttpNotFound();
            }

            return View(c);
        }
        [HttpPost, ActionName("DeleteCurse")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteCurseConfirmed(int Id)
        {
            Curse c = db.Curses.Find(Id);
            if (c == null)
            {
                return HttpNotFound();
            }
            db.Curses.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Contact");
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditCurse(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            Curse curs = db.Curses.Find(Id);
            if (curs != null)
            {
                return View(curs);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditCurse(Curse curs)
        {
            db.Entry(curs).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Contact");
        }
        public ActionResult GetList(string typePublisher)
        {
            ViewBag.Messege = typePublisher;
            var works = db.Works;
            ViewBag.Works = works;
            return PartialView();
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Work work)
        {
            db.Works.Add(work);
            db.SaveChanges();

            return RedirectToAction("About");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Work w = db.Works.Find(Id);
            if (w == null)
            {
                return HttpNotFound();
            }

            return View(w);
        }
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Work w = db.Works.Find(Id);
            if (w == null)
            {
                return HttpNotFound();
            }
            db.Works.Remove(w);
            db.SaveChanges();
            return RedirectToAction("About");
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            Work work = db.Works.Find(Id);
            if (work != null)
            {
                return View(work);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Work work)
        {
            db.Entry(work).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("About");
        }
        [Authorize(Roles = "student")]
        
        public FilePathResult GetFile(string namefile)
        {
            string file_path = Server.MapPath("~/File/" + namefile);
            string file_type = "application/octet-strem";
            //string file_name = file.FileName;
            return File(file_path, file_type, namefile);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return HttpNotFound();
            }
            else
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/File/"), file.FileName);
                file.SaveAs(path);
                ViewBag.Path = path;
                return View();
            }
        }
        public ActionResult WorksCurse(int Id)
        {
            ViewBag.Id = Id;
            var works = db.Works.Include(c => c.Curse);
            return View(works.ToList());
        }
    }
}