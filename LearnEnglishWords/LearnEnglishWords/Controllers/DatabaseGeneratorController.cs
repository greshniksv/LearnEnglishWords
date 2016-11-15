using System;
using System.Web.Mvc;
using LearnEnglishWords.Database;

namespace LearnEnglishWords.Controllers
{
    [Authorize]
    public class DatabaseGeneratorController : Controller
    {
        // GET: Database
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult CreateDatabase(string password)
        {
            if (password != "ldyqfx")
            {
                return RedirectToAction("CreateResult",
                    new { message = "Password is incorrect", success = false });
            }

            try
            {
               Db.CreateDb();
            }
            catch (Exception ex)
            {
                return RedirectToAction("CreateResult",
                    new { message = ex.Message, success = false });
            }
            
            return RedirectToAction("CreateResult", 
                new { message = "Database created successful", success = true });
        }

        [AllowAnonymous]
        public ActionResult CreateResult(string message, bool success)
        {
            if (success)
            {
                ViewBag.Info = message;
            }
            else
            {
                ViewBag.Error = message;
            }

            return View("Index");
        }

    }
}