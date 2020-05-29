using System;
using Microsoft.MobileBlazorBindings;
using Microsoft.Extensions.Hosting;
using Xamarin.Essentials;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using BlazingPizza.Mobile.Client.Model;

namespace BlazingPizza.Mobile.Client
{
    public class App : Application
    {
        public App()
        {
            var host = MobileBlazorBindingsHost.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    var appSettings = new AppSettings
                    {
                        // This needs to be updated to your own publicly accessible API Server.
                        ApiServerUrl = "https://68ea015798d7.ngrok.io",
                    };

                    services.AddSingleton(appSettings);

                    var httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri(appSettings.ApiServerUrl);

                    services.AddSingleton(httpClient);

                })
                .Build();

            //MainPage = new ContentPage();
            host.AddComponent<AppShell>(parent: this);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
