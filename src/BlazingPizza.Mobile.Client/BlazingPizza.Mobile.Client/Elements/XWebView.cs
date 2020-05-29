using BlazingPizza.Mobile.Client.Elements.Handlers;
using Microsoft.AspNetCore.Components;
using Microsoft.MobileBlazorBindings.Core;
using Microsoft.MobileBlazorBindings.Elements;
using System.Threading.Tasks;
using XF = Xamarin.Forms;

namespace BlazingPizza.Mobile.Client.Elements
{
    public class XWebView : View
    {
        static XWebView()
        {
            ElementHandlerRegistry
                .RegisterElementHandler<XWebView>(renderer => new XWebViewHandler(renderer, new XF.WebView()));
        }

        public new XF.WebView NativeControl => NativeControl as XF.WebView;

        [Parameter] public string Source { get; set; }
        [Parameter] public EventCallback GoBackRequested { get; set; }
        [Parameter] public EventCallback<XF.WebNavigatingEventArgs> Navigating { get; set; }
        [Parameter] public EventCallback<XF.WebNavigatedEventArgs> Navigated { get; set; }
        [Parameter] public EventCallback ReloadRequested { get; set; }
        [Parameter] public EventCallback GoForwardRequested { get; set; }

        public bool CanGoForward => NativeControl.CanGoForward;
        public bool CanGoBack => NativeControl.CanGoBack;

        public void Eval(string script) => NativeControl.Eval(script);
        public Task<string> EvaluateJavaScriptAsync(string script) => NativeControl.EvaluateJavaScriptAsync(script);
        public void GoBack() => NativeControl.GoBack();
        public void GoForward() => NativeControl.GoForward();
        public void Reload() => NativeControl.Reload();

        protected override void RenderAttributes(AttributesBuilder builder)
        {
            base.RenderAttributes(builder);

            if (Source != null)
            {
                builder.AddAttribute(nameof(Source), Source);
            }

            RenderAdditionalAttributes(builder);
        }
        void RenderAdditionalAttributes(AttributesBuilder builder)
        {
            builder.AddAttribute("ongobackrequested", GoBackRequested);
            builder.AddAttribute("onnavigating", Navigating);
            builder.AddAttribute("onnavigated", Navigated);
            builder.AddAttribute("onreloadrequested", ReloadRequested);
            builder.AddAttribute("ongoforwardrequested", GoForwardRequested);
        }
    }
}
