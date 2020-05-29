using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.MobileBlazorBindings.Core;
using Microsoft.MobileBlazorBindings.Elements;

namespace BlazingPizza.Mobile.Client.Components.Elements
{
    public partial class Picker : Layout
    {
        [Parameter] public EventCallback<int> SelectedIndexChanged { get; set; }

        partial void RenderAdditionalAttributes(AttributesBuilder builder)
        {
            builder.AddAttribute("onselectedindexchanged", EventCallback.Factory.Create<ChangeEventArgs>(this, HandleSelectedIndexChanged));
        }

        private Task HandleSelectedIndexChanged(ChangeEventArgs evt)
        {
            return SelectedIndexChanged.InvokeAsync((int)evt.Value);
        }
    }
}
