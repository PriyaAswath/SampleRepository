using DemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebApi.Controllers
{
    public class DemoController : ApiController
    {
        [HttpGet]
        [Route("api/Demo/GetString")]
        public string GetMyName()
        {
            return "Welcome to Web API 2"; 
        }

        [HttpPost]
        [Route("api/Demo/GetBookName")]
        public IEnumerable<string> GetBookName([FromBody] Book source)
        {
            string[] data = new string[] { "Data", source.bookName, source.authorName };
            return data;
        }


        [HttpPost]
        [Route("api/Demo/GetBookNameHttp")]
        public HttpResponseMessage GetBookNameHttp([FromBody] Book source)
        {
            if (source.bookName == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Reuired values are missing");
            string[] data = new string[] {"Data", source.bookName , source.authorName  };
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, data);
            return response;
        }

    }
}
