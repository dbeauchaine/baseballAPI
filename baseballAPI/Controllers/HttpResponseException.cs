using System;
using System.Net;

namespace BaseballAPI.Controllers
{
    public class HttpResponseException : Exception
    {
        public HttpStatusCode Status { get; }

        public HttpResponseException(HttpStatusCode status)
        {
            Status = status;
        }
    }
}
