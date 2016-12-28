using System;
using System.Linq;
using System.Web.Mvc;
using LearnEnglishWords.Extensions;
using LearnEnglishWords.Models;
using LearnEnglishWords.Queries;
using MediatR;
using Microsoft.Practices.Unity;

namespace LearnEnglishWords.Controllers
{
    public class WizardController : Controller
    {
        private readonly IMediator _mediator;

        /// <summary>Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.</summary>
        public WizardController()
        {
            _mediator = MvcApp.Unity.Resolve<IMediator>();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectWords()
        {
            var userId = HttpContext.UserId();
            var dictionaries = _mediator.Send(new GetDictionariesQuery { UserId = userId }).ToList();
            return View(dictionaries);
        }

        public ActionResult SelectGame(GameSettingsModel model)
        {
            if (model == null)
            {
                return RedirectToAction("SelectWords", "Wizard");
            }

            if (model.Type == 4)
            {
                throw new Exception("TYPE Incorrect value");
            }

            return View(model);
        }

        public ActionResult ManualSelectWords(GameSettingsModel model)
        {
            var userId = HttpContext.UserId();
            var words = _mediator.Send(new GetWordsQuery { UserId = userId, DictionaryId = model.Dictionary });
            ViewBag.GameSettings = model;
            return View(words);
        }

    }
}