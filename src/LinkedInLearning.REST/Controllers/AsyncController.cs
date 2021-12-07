using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkedInLearning.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncController : ControllerBase
    {
        private static Dictionary<string, Task> _processus = new Dictionary<string, Task>();

        [HttpGet]
        public IActionResult ProcessAsync()
        {
            var task = Task.Delay(10000);
            var guid = Guid.NewGuid().ToString();

            _processus.Add(guid, task);

            return Ok(guid);
        }

        [HttpGet("status/{guid}")]
        public IActionResult IsAsyncComplete(string guid)
        {
            if(!_processus.ContainsKey(guid))
                return BadRequest($"Process with GUID {guid} not launched");

            if(_processus[guid].IsCompleted)
                return Ok(new { Completed = true });

            return Ok(new { Completed = false});
        }
    }
}