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
    public class DEWsPictureController : DefaultController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DEWsPicture
        public async Task<ActionResult> Index()
        {
            return View(await db.DEWsPictureModels.ToListAsync());
        }

        // GET: DEWsPicture/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEWsPictureModels dEWsPictureModels = await db.DEWsPictureModels.FindAsync(id);
            if (dEWsPictureModels == null)
            {
                return HttpNotFound();
            }
            return View(dEWsPictureModels);
        }

        // GET: DEWsPicture/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DEWsPicture/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        //public async Task<ActionResult> Create([Bind(Include = "Content")] DEWsPictureViewModels dEWsPictureViewModels)
        public async Task<ActionResult> Create(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                byte[] byteStream = new byte[upload.ContentLength];
                upload.InputStream.Read(byteStream, 0, upload.ContentLength);
                DEWsPictureModels picture = new DEWsPictureModels
                {
                    Content = byteStream,
                    ContentType = upload.ContentType
                };
                db.DEWsPictureModels.Add(picture);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(upload);
        }

        // GET: DEWsPicture/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEWsPictureModels dEWsPictureModels = await db.DEWsPictureModels.FindAsync(id);
            if (dEWsPictureModels == null)
            {
                return HttpNotFound();
            }
            return View(dEWsPictureModels);
        }

        // POST: DEWsPicture/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Seq,Content")] DEWsPictureModels dEWsPictureModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEWsPictureModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dEWsPictureModels);
        }

        // GET: DEWsPicture/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEWsPictureModels dEWsPictureModels = await db.DEWsPictureModels.FindAsync(id);
            if (dEWsPictureModels == null)
            {
                return HttpNotFound();
            }
            return View(dEWsPictureModels);
        }

        // POST: DEWsPicture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DEWsPictureModels dEWsPictureModels = await db.DEWsPictureModels.FindAsync(id);
            db.DEWsPictureModels.Remove(dEWsPictureModels);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: DEWsPicture/GetImage/5
        public async Task<ActionResult> GetImage(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            DEWsPictureModels dEWsPictureModels = await db.DEWsPictureModels.FindAsync(id);
            if (dEWsPictureModels == null)
            {
                return HttpNotFound();
            }
            return File(dEWsPictureModels.Content, dEWsPictureModels.ContentType);
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
