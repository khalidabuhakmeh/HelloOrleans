# Microsoft Orleans Client/Server Scenario

I created a demo application that allows an incoming web 
request to distribute a request to a server using localhost
clustering. This is based on my knowledge so far.

## Thoughts

- The clustering configuration can seem intimidating but is straightforward once you go through the steps. This could use a database to manage server instances.
- Orleans guarantees deliverability, but how? I don't see a storage mechanism. I imagine the docs mean garaunteed as long as the sender remains healthy. https://dotnet.github.io/orleans/docs/implementation/messaging_delivery_guarantees.html