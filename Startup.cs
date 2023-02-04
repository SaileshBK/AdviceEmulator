using AdviceEmulator;
using AdviceEmulator.Service;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;

[assembly: WebJobsStartup(typeof(Startup))]
namespace AdviceEmulator
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.TryAddScoped(typeof(IAdviceService), typeof(AdviceService));
        }
    }
}
