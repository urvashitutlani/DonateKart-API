using DonateKart.ProcessLayer;
using System.Web.Http;

namespace DonateKart.Controllers
{
    public class CampaignController : ApiController
    {
        [HttpGet]
        [Route("v1/GetCampaigns")]
        public IHttpActionResult GetAll()
        {
            var response = new CampaignProcess().GetAllCampaigns();
            return Ok(response);
        }

        [HttpGet]
        [Route("v1/GetActiveCampaigns")]
        public IHttpActionResult GetActive()
        {
            var response = new CampaignProcess().GetActiveCampaigns();
            return Ok(response);
        }

        
        [HttpGet]
        [Route("v1/GetClosedCampaigns")]
        public IHttpActionResult GetClosed()
        {
            var response = new CampaignProcess().GetClosedCampaigns();
            return Ok(response);
        }
    }
}
