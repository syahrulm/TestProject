using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Newtonsoft.Json;

namespace TestProject.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View("Index");
		}

		public JsonResult TransLateNumber(string numberToTranslate)
		{
			if (String.IsNullOrEmpty(numberToTranslate)) return Json(new { Value = numberToTranslate, StringValue = String.Empty}, JsonRequestBehavior.AllowGet);
			CharReader charReaderUtility = new CharReader(numberToTranslate);
			return Json(new { Value = numberToTranslate, StringValue = charReaderUtility.DataToPrint }, JsonRequestBehavior.AllowGet);

		}

	}
}
