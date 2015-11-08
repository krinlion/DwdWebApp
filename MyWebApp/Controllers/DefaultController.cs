using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class DefaultController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Default
        public ActionResult _JuniorList()
        {
            return View( db.MemberInfoes.Where(x => x.Group == "1" && x.IsLeader == "Y").ToList());
        }

        public ActionResult _SeniorList()
        {
            return View(db.MemberInfoes.Where(x => x.Group == "2" && x.IsLeader == "Y").ToList());
        }
    }
}