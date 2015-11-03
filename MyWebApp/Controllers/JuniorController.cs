using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class JuniorController : DefaultController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Junior
        public async Task<ActionResult> Index()
        {
            return View(await db.MemberInfoes.Where(x=> x.Group == "1").ToListAsync());
        }

        // GET: Junior/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberInfo memberInfo = await db.MemberInfoes.FindAsync(id);
            if (memberInfo == null)
            {
                return HttpNotFound();
            }
            return View(memberInfo);
        }

        // GET: Junior/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Junior/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Email,IsLeader,Group,PictureURL")] MemberInfo memberInfo)
        {
            if (ModelState.IsValid)
            {
                db.MemberInfoes.Add(memberInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(memberInfo);
        }

        // GET: Junior/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberInfo memberInfo = await db.MemberInfoes.FindAsync(id);
            if (memberInfo == null)
            {
                return HttpNotFound();
            }
            return View(memberInfo);
        }

        // POST: Junior/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Email,IsLeader,Group,PictureURL")] MemberInfo memberInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(memberInfo);
        }

        // GET: Junior/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberInfo memberInfo = await db.MemberInfoes.FindAsync(id);
            if (memberInfo == null)
            {
                return HttpNotFound();
            }
            return View(memberInfo);
        }

        // POST: Junior/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            MemberInfo memberInfo = await db.MemberInfoes.FindAsync(id);
            db.MemberInfoes.Remove(memberInfo);
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
