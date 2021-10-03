using DonateKart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonateKart.ProcessLayer
{
    public interface ICampaignProcess
    {
        IEnumerable<GetCampaigns> GetAllCampaigns();
        IEnumerable<GetCampaigns> GetActiveCampaigns();
        IEnumerable<GetCampaigns> GetClosedCampaigns();
    }
}
