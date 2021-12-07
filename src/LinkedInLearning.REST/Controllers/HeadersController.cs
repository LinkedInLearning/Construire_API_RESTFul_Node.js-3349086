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
    public class HeadersController : ControllerBase
    {
        private const string CUSTOM_HEADER = "CustomHeader";

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(HttpContext.Request.Headers[CUSTOM_HEADER]);
        }
    }
}