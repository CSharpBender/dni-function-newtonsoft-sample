using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace MyFunctionApp
{
    public class MyHttpFunction
    {
        private readonly ILogger<MyHttpFunction> _logger;

        public MyHttpFunction(ILogger<MyHttpFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(MyHttpFunction))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestData request)
        {
            var response = request.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(new { Name = "Error" });
            return response;
        }
    }
}