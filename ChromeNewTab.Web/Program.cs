using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Radzen;

namespace ChromeNewTab.Web
{
  public class Program
  {
    public static async System.Threading.Tasks.Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("app");
        builder.Services.AddSingleton<DialogService>();
        await builder.Build().RunAsync();
    }
  }
}
