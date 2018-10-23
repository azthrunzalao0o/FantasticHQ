using System.Web.Mvc;

namespace FamilyHomeWeb.Controllers
{
    public class MinerController : BaseController
    {
        public const int WARNING_HASH = 25;
        public const int WARNING_TEMP = 70;
        public const int WARNING_WATT = 140;

        public ActionResult Index(string rigId)
        {
            ViewModels.Miner.IndexViewModel viewModel = new ViewModels.Miner.IndexViewModel()
            {
                MinerModel = GetMinerDetails(),
                DefaultActiveRigId = rigId
            };

            ViewBag.WarningHash = WARNING_HASH;
            ViewBag.WarningTemp = WARNING_TEMP;
            ViewBag.WarningWatt = WARNING_WATT;

            return View(viewModel);
        }

        public JsonResult ValidateEthos(string user, string password)
        {
            return Json("Hello", JsonRequestBehavior.AllowGet);
        }
    }
}