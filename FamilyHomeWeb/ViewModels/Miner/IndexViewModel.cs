using FamilyHomeWeb.Models.MinerModels;
using System.Linq;

namespace FamilyHomeWeb.ViewModels.Miner
{
    public class IndexViewModel
    {
        public PanelDetails MinerModel { get; set; }
        public string DefaultActiveRigId { get; set; }

        public string PrintActiveKeywordForDefaultRig(string Id)
        {
            string activeStr = string.Empty;
            if (!string.IsNullOrEmpty(DefaultActiveRigId))
            {
                if (DefaultActiveRigId.Equals(Id))
                {
                    activeStr = @"active";
                }
            }
            else
            {
                if (MinerModel.Rigs.Keys.FirstOrDefault().Equals(Id))
                {
                    activeStr = @"active";
                }
            }
            return activeStr;
        }
    }
}