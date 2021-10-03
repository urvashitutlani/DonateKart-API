using System;

namespace DonateKart.Models
{
    public class GetCampaigns
    {
        public string Title { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalAmount { get; set; }
        public float BackersCount { get; set; }
    }

}