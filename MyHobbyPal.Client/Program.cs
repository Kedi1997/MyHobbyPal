using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyHobbyPal.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddHttpClient(
                "MyHobbyPalClient",
                (services, client) =>
                {
                    client.BaseAddress = new Uri("http://localhost:5000/graphql");
                    client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "http://localhost:5000/graphql");
                });
            builder.Services.AddMyHobbyPalClient();

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/graphql") });
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //builder.Services.AddSingleton();

            await builder.Build().RunAsync();
        }
    }
}
