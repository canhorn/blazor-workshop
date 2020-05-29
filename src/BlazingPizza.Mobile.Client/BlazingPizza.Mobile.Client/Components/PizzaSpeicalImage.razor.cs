using System;
using Microsoft.AspNetCore.Components;
using Microsoft.MobileBlazorBindings.Elements;
using XF = Xamarin.Forms;

namespace BlazingPizza.Mobile.Client.Components
{
    public class PizzaSpeicalImageModel : ComponentBase
    {
        [Parameter]
        public PizzaSpecial Special { get; set; }
        [Parameter]
        public EventCallback<PizzaSpecial> OnTap { get; set; }

        protected Frame frame;

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                var tapGestureRecognizer = new XF.TapGestureRecognizer();
                tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;

                frame.NativeControl.GestureRecognizers.Add(tapGestureRecognizer);
            }
        }

        private void OnTapGestureRecognizerTapped(
            object sender, 
            EventArgs args
        )
        {
            OnTap.InvokeAsync(
                Special
            );
        }
    }
}
