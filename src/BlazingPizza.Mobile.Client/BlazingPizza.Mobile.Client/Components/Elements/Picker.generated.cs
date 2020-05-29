using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlazingPizza.Mobile.Client.Components.Elements.Handler;
using Microsoft.AspNetCore.Components;
using Microsoft.MobileBlazorBindings.Core;
using Microsoft.MobileBlazorBindings.Elements;
using XF = Xamarin.Forms;

namespace BlazingPizza.Mobile.Client.Components.Elements
{
    public partial class Picker : Layout
    {
        static Picker()
        {
            ElementHandlerRegistry
                .RegisterElementHandler<Picker>(renderer => new PickerHandler(renderer, new XF.Picker()));
        }

        [Parameter] public List<string> Items { get; set; }

        [Parameter] public object SelectedItem { get; set; }
        [Parameter] public XF.Color? TitleColor { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public double? CharacterSpacing { get; set; }
        [Parameter] public XF.Color? TextColor { get; set; }
        [Parameter] public int? SelectedIndex { get; set; }
        [Parameter] public XF.FontAttributes? FontAttributes { get; set; }
        [Parameter] public double? FontSize { get; set; }
        [Parameter] public string FontFamily { get; set; }

        public new XF.Picker NativeControl => ((PickerHandler)ElementHandler).PickerControl;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                if (Items != null)
                {
                    NativeControl.Items.Clear();
                    foreach (var item in Items)
                    {
                        NativeControl.Items.Add(item);
                    }
                }
            }
        }

        protected override void OnParametersSet()
        {
            if (Items != null && ElementHandler != null)
            {
                NativeControl.Items.Clear();
                foreach (var item in Items)
                {
                    NativeControl.Items.Add(item);
                }
            }
        }

        protected override void RenderAttributes(AttributesBuilder builder)
        {
            base.RenderAttributes(builder);

            if (SelectedItem != null)
            {
                builder.AddAttribute(nameof(SelectedItem), SelectedItem);
            }
            if (TitleColor != null)
            {
                builder.AddAttribute(nameof(TitleColor), AttributeHelper.ColorToString(TitleColor.Value));
            }
            if (Title != null)
            {
                builder.AddAttribute(nameof(Title), Title);
            }
            if (CharacterSpacing != null)
            {
                builder.AddAttribute(nameof(CharacterSpacing), AttributeHelper.DoubleToString((double)CharacterSpacing.Value));
            }
            if (TextColor != null)
            {
                builder.AddAttribute(nameof(TextColor), AttributeHelper.ColorToString(TextColor.Value));
            }
            if (SelectedIndex != null)
            {
                builder.AddAttribute(nameof(SelectedIndex), (int)SelectedIndex.Value);
            }
            if (FontAttributes != null)
            {
                builder.AddAttribute(nameof(FontAttributes), (int)FontAttributes.Value);
            }
            if (FontSize != null)
            {
                builder.AddAttribute(nameof(FontSize), AttributeHelper.DoubleToString(FontSize.Value));
            }
            if (FontFamily != null)
            {
                builder.AddAttribute(nameof(FontFamily), FontFamily);
            }

            RenderAdditionalAttributes(builder);
        }

        partial void RenderAdditionalAttributes(AttributesBuilder builder);
    }
}
