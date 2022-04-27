using System.Net;
using Microsoft.Extensions.Logging;
using Orleans.Configuration;
using Orleans.Hosting;

var host = new SiloHostBuilder()
    // Use localhost clustering for a single local silo
    .UseLocalhostClustering()
    // Configure ClusterId and ServiceId
    .Configure<ClusterOptions>(co =>
    {
        co.ClusterId = "dev";
        co.ServiceId = "minimal-api";
    })
    .Configure<EndpointOptions>(eo =>
    {
        eo.AdvertisedIPAddress = IPAddress.Loopback;
    })
    .ConfigureLogging(logging => logging.AddConsole())
    .Build();

await host.StartAsync();

Console.ReadLine();