using System.Threading;
using System.Web.Mvc;
using LearnEnglishWords.Commands;
using LearnEnglishWords.Models;
using LearnEnglishWords.Queries;
using MediatR;
using Microsoft.Practices.Unity;

namespace LearnEnglishWords.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IMediator _mediator;

        /// <summary>Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.</summary>
        public RegisterController()
        {
            _mediator = MvcApp.Unity.Resolve<IMediator>();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var usersByLogin = _mediator.Send(new GetUserByQuery { Login = model.Login });
                var usersByEmail = _mediator.Send(new GetUserByQuery { Email = model.Email });

                if (usersByLogin == null && usersByEmail == null)
                {
                    _mediator.Send(new AddUserCommand {UserModel = model});
                    return View("Successfully");
                }

                if (usersByLogin != null)
                {
                    ViewBag.Error = "Пользователь с таким логином уже существует";
                }

                if (usersByEmail != null)
                {
                    ViewBag.Error = "Пользователь с таким E-Mail уже существует";
                }
            }

            return View("Index", model);
        }

        public ActionResult RestorePassword(string email)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(email))
            {
                var usersByEmail = _mediator.Send(new GetUserByQuery { Email = email });

                if (usersByEmail != null)
                {
                    // Send mail
                    _mediator.Send(new RestorePasswordCommand {Email = email});
                    return View("PasswordRestored");
                }

                // Brute-force breaker
                Thread.Sleep(1000);
                ViewBag.Error = "Пользователь с таким E-Mail не найден";
            }

            return View("RestorePassword");
        }
    }
}