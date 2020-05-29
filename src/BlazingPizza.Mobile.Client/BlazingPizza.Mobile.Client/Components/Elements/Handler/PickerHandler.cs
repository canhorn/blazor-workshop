using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.MobileBlazorBindings.Core;
using Microsoft.MobileBlazorBindings.Elements.Handlers;

namespace BlazingPizza.Mobile.Client.Components.Elements.Handler
{
    public partial class PickerHandler : ViewHandler
    {
        partial void Initialize(NativeComponentRenderer renderer)
        {
            RegisterEvent(
                eventName: "onselectedindexchanged",
                setId: id => SelectedIndexChangedEventHandlerId = id,
                clearId: id => { if (SelectedIndexChangedEventHandlerId == id) SelectedIndexChangedEventHandlerId = 0; });
            PickerControl.SelectedIndexChanged += (s, e) =>
            {
                if (SelectedIndexChangedEventHandlerId != default)
                {
                    renderer.Dispatcher.InvokeAsync(() => renderer.DispatchEventAsync(
                        SelectedIndexChangedEventHandlerId, 
                        null, 
                        new ChangeEventArgs 
                        { 
                            Value = PickerControl.SelectedIndex,
                        }
                    ));
                }
            };
        }

        public ulong SelectedIndexChangedEventHandlerId { get; set; }
    }
}
