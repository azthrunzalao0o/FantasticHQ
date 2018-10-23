using FamilyHomeWeb.Controllers.EntityFramework;
using System.Web.Mvc;

namespace FamilyHomeWeb.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewModels.Home.IndexViewModel viewModel = new ViewModels.Home.IndexViewModel()
            {
                WeatherModel = GetWeatherInformation(),
                MinerModel = GetMinerDetails(),
                StockModel = GetFinanceModel(),
                Reminders = ReminderDataController.GetTodayReminders()
            };
            return View(viewModel);
        }

        public JsonResult SelectUser(string userName)
        {
            string retVal;
            try
            {
                System.Web.HttpContext.Current.Application["User"] = userName;
                retVal = "Good";
            }
            catch
            {
                retVal = "Bad";
            }
            return Json(retVal, JsonRequestBehavior.AllowGet);
        }
    }
}