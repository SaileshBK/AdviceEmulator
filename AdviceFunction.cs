using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AdviceEmulator.Service;

namespace AdviceEmulator
{
    public class AdviceFunction
    {
        private IAdviceService _adviceService;
        public AdviceFunction(IAdviceService adviceService)
        {
            _adviceService = adviceService;

        }

        [FunctionName("DailyAdviceFunction")]
        public async Task DailyAdviceFunctionAsync([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var response = await _adviceService.GetDailyAdvie();
        }

        [FunctionName("DailyAdviceFunctionTrigger")]
        public async Task<IActionResult> DailyAdviceFunctionTriggerAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var response = await _adviceService.GetDailyAdvie();

            return new OkObjectResult(response);
        }

        
    }
}
