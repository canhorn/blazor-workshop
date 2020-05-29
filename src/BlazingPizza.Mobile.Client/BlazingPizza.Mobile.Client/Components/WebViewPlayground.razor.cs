using BlazingPizza.Mobile.Client.Elements;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.MobileBlazorBindings.Elements;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XF = Xamarin.Forms;

namespace BlazingPizza.Mobile.Client.Components
{
    public class WebViewPlaygroundModel : ComponentBase
    {
        public XWebView TheWebView { get; set; }
        public bool GoBackRequested { get; set; }
        public bool GoForwardRequested { get; set; }
        public string NavigationStatus { get; set; } = "EMPTY";

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }

        public async Task HandleOnClick()
        {
            var result = await TheWebView.EvaluateJavaScriptAsync("JSON.stringify({hello: 'value'})");
        }

        public void HandleGoBackRequested()
        {
            GoBackRequested = true;
        }

        public void HandleGoForwardRequested()
        {
            GoForwardRequested = true;
        }

        public void HandleNavigating(XF.WebNavigatingEventArgs args)
        {
            NavigationStatus = $"Navigating to {args.Url}";
        }
        public void HandleNavigated(XF.WebNavigatedEventArgs args)
        {
            NavigationStatus = $"Navigated to {args.Url}";
        }
    }
}
