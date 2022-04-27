using System.Net;
using HelloOrleans.Grains;
using Orleans;
using Orleans.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IClusterClient>(_ =>
{
    return new ClientBuilder()
        .UseLocalhostClustering()
        .Configure<ClusterOptions>(co =>
        {
            co.ClusterId = "dev";
            co.ServiceId = "minimal-api";
        }).Configure<EndpointOptions>(eo =>
        {
            eo.AdvertisedIPAddress = IPAddress.Loopback;
        })
        .Build();
});

var app = builder.Build();

app.MapGet("/", async (IClusterClient client) =>
{
    var grain = client.GetGrain<IHelloGrain>("friend");
    var result = await grain.SayHello("Good Morning!");
    return result;
});

// initialize to the server
await app
    .Services
    .GetRequiredService<IClusterClient>()
    .Connect(async e => {
        await Task.Delay(TimeSpan.FromSeconds(1));
        // let's keep trying
        return true;
    });

app.Run();