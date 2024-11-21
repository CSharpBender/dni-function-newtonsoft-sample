using Azure.Core.Serialization;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public static class Program
{
    public static void Main(string[] args)
    {
        var host = new HostBuilder()
                .ConfigureFunctionsWebApplication((IFunctionsWorkerApplicationBuilder builder) =>
                {
                    builder.Services.Configure<WorkerOptions>(workerOptions =>
                    {
                        var settings = NewtonsoftJsonObjectSerializer.CreateJsonSerializerSettings();
                        settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        settings.NullValueHandling = NullValueHandling.Ignore;

                        workerOptions.Serializer = new NewtonsoftJsonObjectSerializer(settings);
                    });
                })
                .ConfigureServices(services =>
                {
                    services.ConfigureSerializer();
                })
                .Build();

        host.Run();
    }
    //Without this, System.Text.Json.Serialization is used
    public static IServiceCollection ConfigureSerializer(this IServiceCollection services)
    {
        services.AddMvc().AddNewtonsoftJson();
        return services;
    }
}