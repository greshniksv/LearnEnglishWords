using System;
using System.Web.Mvc;
using LearnEnglishWords.Commands;
using LearnEnglishWords.Extensions;
using LearnEnglishWords.Models;
using LearnEnglishWords.Queries;
using MediatR;
using Microsoft.Practices.Unity;

namespace LearnEnglishWords.Controllers
{
    public class DictionaryController : Controller
    {
        private readonly IMediator _mediator;

        /// <summary>Initializes a new instance of the <see cref="T:System.Web.Mvc.Controller" /> class.</summary>
        public DictionaryController()
        {
            _mediator = MvcApp.Unity.Resolve<IMediator>();
        }

        // GET: Home
        public ActionResult Index()
        {
            var userId = HttpContext.UserId();
            var dictionaries = _mediator.Send(new GetDictionariesQuery { UserId = userId });
            return View(dictionaries);
        }

        public ActionResult Show(int id)
        {
            var userId = HttpContext.UserId();
            var words = _mediator.Send(new GetWordsQuery { DictionaryId = id, UserId = userId });
            return View(words);
        }

        public ActionResult RemoveWord(int id)
        {
            var userId = HttpContext.UserId();
            try
            {
                _mediator.Send(new RemoveWordCommand() { WordId = id, UserId = userId });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
            return Json(new { Success = true, Message = "" });
        }

        public ActionResult SaveWord(WordModel model)
        {
            try
            {
                _mediator.Send(new SaveWordCommand { Word = model });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
            return Json(new { Success = true, Message = "" });
        }

        public ActionResult RemoveDictionary(int id)
        {
            var userId = HttpContext.UserId();
            try
            {
                _mediator.Send(new RemoveDictionaryCommand { DictionaryId = id, UserId = userId });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
            return Json(new { Success = true, Message = "" });
        }

        public ActionResult SaveDictionary(DictionaryModel model)
        {
            var userId = HttpContext.UserId();
            try
            {
                _mediator.Send(new SaveDictionaryCommand() { Model = model, UserId = userId });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
            return Json(new { Success = true, Message = "" });
        }
    }
}