using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace LinkedInLearning.REST.Filters
{
    // prevents the action filter methods to be invoked twice
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class,
          AllowMultiple = false)]
    public class ETagFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;

            if (request.Method == HttpMethod.Get.Method &&
             response.StatusCode == (int)HttpStatusCode.OK)
            {
                var res = JsonConvert.SerializeObject(context.Result);

                // generate etag string
                // from the response body
                var etag = GenerateETag(res);

                //fetch etag from the incoming request header
                if (request.Headers.Keys.Contains(HeaderNames.IfNoneMatch))
                {
                    var incomingEtag =
                                  request.Headers[HeaderNames.IfNoneMatch]
                                      .ToString();

                    // if both the etags are equal
                    // raise a 304 Not Modified Response
                    if (incomingEtag.Equals(etag))
                    {
                        context.Result =
                                  new StatusCodeResult(
                                  (int)HttpStatusCode.NotModified);
                    }
                }

                // add ETag response header 
                response.Headers.Add(HeaderNames.ETag, new[] { etag });
            }

            base.OnActionExecuted(context);
        }

        private string GenerateETag(string response)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(response);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}