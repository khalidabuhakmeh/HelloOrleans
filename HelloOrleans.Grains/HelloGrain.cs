using Microsoft.Extensions.Logging;
using Orleans;

namespace HelloOrleans.Grains;

public interface IHelloGrain : IGrainWithStringKey
{
    Task<string> SayHello(string greeting);
}

public class HelloGrain : Grain, IHelloGrain
{
    private readonly ILogger<HelloGrain> logger;

    public HelloGrain(ILogger<HelloGrain> logger)
    {
        this.logger = logger;
    }
    
    public Task<string> SayHello(string greeting)
    {
        logger.LogInformation("I'm here! Not There!");
        return Task.FromResult($"Hello, {greeting}!");
    }
}
