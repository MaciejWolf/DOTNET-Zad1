using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BuzzerController : Controller
    {
        private readonly Buzzer buzzer = new Buzzer();

        [HttpGet("{input}")]
        public ActionResult<string> GetSignal(int input)
        {
            string signal;
            try
            {
                signal = buzzer.GetSignal(input);
            }
            catch(ArgumentOutOfRangeException)
            {
                return BadRequest();
            }

            return signal;
        }
    }
}
