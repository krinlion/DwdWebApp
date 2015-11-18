using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class NoticeController : DefaultController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Notice
        public async Task<ActionResult> Index()
        {
            NoticeViewModel viewModel = new NoticeViewModel();
            viewModel.NoticeList = await db.Notices.ToListAsync();

            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.IsAdmin = db.MemberInfoes.Where(x => x.Email == User.Identity.Name && x.IsAdmin == true).Any();
            }
            else
            {
                ViewBag.IsAdmin = false;
            }

            ViewBag.나는누구 = "유휘성";

            return View(await db.Notices.ToListAsync());
        }

        // GET: Notice/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = await db.Notices.FindAsync(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // GET: Notice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notice/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Seq,Title,Content,WriteDate,Writer")] Notice notice)
        {
            if (ModelState.IsValid)
            {
                db.Notices.Add(notice);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(notice);
        }

        // GET: Notice/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = await db.Notices.FindAsync(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // POST: Notice/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Seq,Title,Content,WriteDate,Writer")] Notice notice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notice).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(notice);
        }

        // GET: Notice/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = await db.Notices.FindAsync(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // POST: Notice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Notice notice = await db.Notices.FindAsync(id);
            db.Notices.Remove(notice);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
