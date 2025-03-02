var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Cardapio_ApiService>("apiservice");

builder.AddProject<Projects.Cardapio_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
