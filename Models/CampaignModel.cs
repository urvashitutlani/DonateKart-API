using System;

namespace DonateKart.Models
{
    public class CampaignModel
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalAmount { get; set; }
        public double ProcuredAmount { get; set; }
        public double TotalProcured { get; set; }
        public float BackersCount { get; set; }
    }
}