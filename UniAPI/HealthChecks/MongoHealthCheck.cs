using BookStore.Models.Configurations;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UniAPI.HealthChecks
{
    public class MongoHealthCheck : IHealthCheck
    {
        private readonly IConfiguration _configuration;
        private readonly IOptionsMonitor<MongoDbConfiguration> _mongoConfig;

        public MongoHealthCheck(IConfiguration configuration, IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            _configuration = configuration;
            _mongoConfig = mongoConfig;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var client =
                    new MongoClient(_mongoConfig.CurrentValue.ConnectionString);
            }
            catch (Exception e)
            {
                return HealthCheckResult.Unhealthy("Ne kefi");
            }

            return HealthCheckResult.Healthy("MongoDb is Ok");
        }
    }
}