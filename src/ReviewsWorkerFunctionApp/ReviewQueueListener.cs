using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace ReviewsWorkerFunctionApp
{
    public static class ReviewQueueListener
    {
        [FunctionName("ReviewQueueListener")]
        public static async Task Run([QueueTrigger("review-submitted", Connection = "ReviewQueueConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"Started processing at {DateTime.UtcNow:o}. Message: {nameof(ReviewQueueListener)}");

            // Wait for 15 seconds to allow messages to build up in the queue.
            await Task.Delay(15 * 1000);

            log.LogInformation($"Finished processing at {DateTime.UtcNow:o}. Message: {nameof(ReviewQueueListener)}");
        }
    }
}
