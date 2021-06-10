using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Bogus;

namespace ReviewsWorkerFunctionApp
{
    public static class ReviewGenerator
    {
        [FunctionName("ReviewGenerator")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Generating review with {nameof(ReviewGenerator)}.");

            var faker = new Faker("en");

            var messageString = JsonConvert.SerializeObject(
                new
                {
                    EventId = Guid.NewGuid(),
                    EventType = "ReviewSubmitted",
                    Content = new {
                        Text = faker.Rant.Review()
                    }
                });

            log.LogInformation($"Sending review: {messageString}");

            return new OkObjectResult(messageString);
        }
    }
}
