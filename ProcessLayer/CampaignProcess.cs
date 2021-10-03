using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using DonateKart.Models;

namespace DonateKart.ProcessLayer
{
    public class CampaignProcess : ICampaignProcess
    {
        public IEnumerable<GetCampaigns> GetAllCampaigns()
        {
            var responseString = GetApiResponse();
            List<CampaignModel> campaign = new JavaScriptSerializer().Deserialize<List<CampaignModel>>(responseString);
            campaign = campaign.OrderByDescending(x => x.TotalAmount).ToList();
            return campaign.Select(x => new GetCampaigns
            {
                Title = x.Title,
                TotalAmount = x.TotalAmount,
                BackersCount = x.BackersCount,
                EndDate = x.EndDate
            });
        }

        public IEnumerable<GetCampaigns> GetActiveCampaigns()
        {
            var responseString = GetApiResponse();
            List<CampaignModel> campaign = new JavaScriptSerializer().Deserialize<List<CampaignModel>>(responseString);
            DateTime activeDate = DateTime.Now.AddDays(-30);
            campaign = campaign.Where(x => x.EndDate >= DateTime.Now).ToList();
            campaign = campaign.Where(y => y.StartDate >= activeDate).ToList();
            return campaign.Select(x => new GetCampaigns
            {
                Title = x.Title,
                TotalAmount = x.TotalAmount,
                BackersCount = x.BackersCount,
                EndDate = x.EndDate
            });
        }

        public IEnumerable<GetCampaigns> GetClosedCampaigns()
        {
            var responseString = GetApiResponse();
            List<CampaignModel> campaign = new JavaScriptSerializer().Deserialize<List<CampaignModel>>(responseString);
            campaign = campaign.Where(x => x.EndDate < DateTime.Now).Where(y => y.ProcuredAmount >= y.TotalAmount).ToList();
            return campaign.Select(x => new GetCampaigns
            {
                Title = x.Title,
                TotalAmount = x.TotalAmount,
                BackersCount = x.BackersCount,
                EndDate = x.EndDate
            });
        }

        private string GetApiResponse()
        {

            var responseString = "";
            var request = (HttpWebRequest)WebRequest.Create("https://testapi.donatekart.com/api/campaign");
            request.Method = "GET";
            request.ContentType = "application/json";

            using (var response1 = request.GetResponse())
            {
                using (var reader = new StreamReader(response1.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }
            return responseString;
        }
    }
}