using Microsoft.MobileBlazorBindings.Core;
using Microsoft.MobileBlazorBindings.Elements.Handlers;
using System;
using XF = Xamarin.Forms;

namespace BlazingPizza.Mobile.Client.Elements.Handlers
{
    public class XWebViewHandler : ViewHandler
    {
        public XWebViewHandler(NativeComponentRenderer renderer, XF.WebView webViewControl)
            : base(renderer, webViewControl)
        {
            WebViewControl = webViewControl ?? throw new ArgumentNullException(nameof(webViewControl));

            Initialize(renderer);
        }

        public XF.WebView WebViewControl { get; }

        public override void ApplyAttribute(ulong attributeEventHandlerId, string attributeName, object attributeValue, string attributeEventUpdatesAttributeName)
        {
            switch (attributeName)
            {
                case nameof(XF.WebView.Source):
                    WebViewControl.Source = attributeValue.ToString();
                    break;
                default:
                    base.ApplyAttribute(attributeEventHandlerId, attributeName, attributeValue, attributeEventUpdatesAttributeName);
                    break;
            }
        }

        void Initialize(NativeComponentRenderer renderer)
        {

            RegisterEvent(
                eventName: "ongobackrequested",
                setId: id => GoBackRequestedEventHandlerId = id,
                clearId: id => { if (GoBackRequestedEventHandlerId == id) GoBackRequestedEventHandlerId = 0; });
            WebViewControl.GoBackRequested += (s, e) =>
            {
                if (GoBackRequestedEventHandlerId != default)
                {
                    renderer.Dispatcher.InvokeAsync(() => renderer.DispatchEventAsync(GoBackRequestedEventHandlerId, null, e));
                }
            };

            RegisterEvent(
                eventName: "onnavigating",
                setId: id => NavigatingEventHandlerId = id,
                clearId: id => { if (NavigatingEventHandlerId == id) NavigatingEventHandlerId = 0; });
            WebViewControl.Navigating += (s, e) =>
            {
                if (NavigatingEventHandlerId != default)
                {
                    renderer.Dispatcher.InvokeAsync(() => renderer.DispatchEventAsync(NavigatingEventHandlerId, null, e));
                }
            };

            RegisterEvent(
                eventName: "onnavigated",
                setId: id => NavigatedEventHandlerId = id,
                clearId: id => { if (NavigatedEventHandlerId == id) NavigatedEventHandlerId = 0; });
            WebViewControl.Navigated += (s, e) =>
            {
                if (NavigatedEventHandlerId != default)
                {
                    renderer.Dispatcher.InvokeAsync(() => renderer.DispatchEventAsync(NavigatedEventHandlerId, null, e));
                }
            };

            RegisterEvent(
                eventName: "onreloadrequested",
                setId: id => ReloadRequestedEventHandlerId = id,
                clearId: id => { if (ReloadRequestedEventHandlerId == id) ReloadRequestedEventHandlerId = 0; });
            WebViewControl.ReloadRequested += (s, e) =>
            {
                if (ReloadRequestedEventHandlerId != default)
                {
                    renderer.Dispatcher.InvokeAsync(() => renderer.DispatchEventAsync(ReloadRequestedEventHandlerId, null, e));
                }
            };

            RegisterEvent(
                eventName: "ongoforwardrequested",
                setId: id => GoForwardRequestedEventHandlerId = id,
                clearId: id => { if (GoForwardRequestedEventHandlerId == id) GoForwardRequestedEventHandlerId = 0; });
            WebViewControl.GoForwardRequested += (s, e) =>
            {
                if (GoForwardRequestedEventHandlerId != default)
                {
                    renderer.Dispatcher.InvokeAsync(() => renderer.DispatchEventAsync(GoForwardRequestedEventHandlerId, null, e));
                }
            };
        }

        public ulong GoBackRequestedEventHandlerId { get; set; }
        public ulong NavigatingEventHandlerId { get; set; }
        public ulong NavigatedEventHandlerId { get; set; }
        public ulong ReloadRequestedEventHandlerId { get; set; }
        public ulong GoForwardRequestedEventHandlerId { get; set; }

    }
}
