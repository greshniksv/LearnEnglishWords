using System.Web.Mvc;
using LearnEnglishWords.Extensions;
using LearnEnglishWords.Queries;
using MediatR;
using Microsoft.Practices.Unity;

namespace LearnEnglishWords.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IMediator _mediator;

        /// <summary>Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.</summary>
        public SettingsController()
        {
            _mediator = MvcApp.Unity.Resolve<IMediator>();
        }

        // GET: Home
        public ActionResult Index()
        {
            var userId = HttpContext.UserId();
            var user = _mediator.Send(new GetUserByQuery {UserId = userId});
            ViewBag.IsAdmin = user.Login == "admin";

            return View();
        }
    }
}