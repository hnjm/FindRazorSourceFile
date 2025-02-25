﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
#if DEBUG
using FindRazorSourceFile.WebAssembly;
#endif
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SampleSite.Client.Services;
using SampleSite.Components;
using SampleSite.Components.Services;

namespace SampleSite.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
#if DEBUG
            builder.UseFindRazorSourceFile();
#endif
            builder.RootComponents.Add<App>("app");
            builder.Services
                .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                .AddScoped<IWeatherForecastService, WeatherForecastService>();
            await builder.Build().RunAsync();
        }
    }
}
