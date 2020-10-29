using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChallanManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallanController : ControllerBase
    {
        private IChallanService _challanService = new ChallanService();

        [Route("CreateChallan")]
        [HttpPost]
        public IActionResult CreateChallan(ChallanRequest challanRequest)
        {
            return Ok(_challanService.CreateChallan(challanRequest));
        }

        [Route("GetChallans")]
        [HttpPost]
        public IActionResult GetChallan(ChallanRequest challanRequest)
        {
            return Ok(_challanService.GetChallans(challanRequest));
        }


        [Route("PayChallan")]
        [HttpPost]
        public IActionResult PayChallan(ChallanRequest challanRequest)
        {
            return Ok(_challanService.SubmitChallan(challanRequest));
        }
    }
}
