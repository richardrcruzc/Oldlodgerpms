

using Microsoft.eShopOnContainers.BuildingBlocks.Resilience.Http;

namespace LodgerPms.WebMVC.Infrastructure
{
    public interface IResilientHttpClientFactory
    {
        ResilientHttpClient CreateResilientHttpClient();
    }
}
