using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyFunctionApp
{
    public class MyHttpFunctionWithDto
    {
        private readonly ILogger<MyHttpFunctionWithDto> _logger;

        public MyHttpFunctionWithDto(ILogger<MyHttpFunctionWithDto> logger)
        {
            _logger = logger;
        }

        [Function(nameof(MyHttpFunctionWithDto))]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(new ResponseDto { Name = "Error" });
        }

        private class ResponseDto
        {
            [JsonProperty("usesNewtonsoftJson")]
            [JsonPropertyName("usesSystemTextJsonSerialization")]
            public required string Name { get; set; }
        }
    }
}