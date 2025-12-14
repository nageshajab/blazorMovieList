using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace blazorMovieList
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(sp => new HttpClient
            {
                // BaseAddress = new Uri("https://myreactappapimanagementservice.azure-api.net/myreactappbackendapi/")
                BaseAddress = new Uri("http://localhost:7018/")
            });

            // Add authentication core
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddBlazoredLocalStorage();
            
            //await builder.Build().RunAsync();
            var app = builder.Build();
            await app.RunAsync();
        }
    }
}
