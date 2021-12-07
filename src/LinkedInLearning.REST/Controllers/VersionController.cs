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
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        public string Get() => "Hello world v1.0!";

        [HttpGet, MapToApiVersion("2.0")]
        public string GetV2() => "Hello world v2.0! This is the V2 version of API";
    }
}