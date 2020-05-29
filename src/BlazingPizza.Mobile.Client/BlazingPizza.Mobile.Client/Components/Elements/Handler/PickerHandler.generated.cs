using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.MobileBlazorBindings.Core;
using Microsoft.MobileBlazorBindings.Elements;
using Microsoft.MobileBlazorBindings.Elements.Handlers;
using XF = Xamarin.Forms;

namespace BlazingPizza.Mobile.Client.Components.Elements.Handler
{
    public partial class PickerHandler : ViewHandler
    {
        public PickerHandler(NativeComponentRenderer renderer, XF.Picker pickerControl) : base(renderer, pickerControl)
        {
            PickerControl = pickerControl ?? throw new ArgumentNullException(nameof(pickerControl));

            Initialize(renderer);
        }

        partial void Initialize(NativeComponentRenderer renderer);

        public XF.Picker PickerControl { get; }

        public override void ApplyAttribute(ulong attributeEventHandlerId, string attributeName, object attributeValue, string attributeEventUpdatesAttributeName)
        {
            if (attributeEventHandlerId != 0)
            {
                ApplyEventHandlerId(attributeName, attributeEventHandlerId);
            }

            switch (attributeName)
            {
                case nameof(XF.Picker.SelectedItem):
                    PickerControl.SelectedItem = attributeValue;
                    break;
                case nameof(XF.Picker.TitleColor):
                    PickerControl.TitleColor = AttributeHelper.StringToColor((string)attributeValue);
                    break;
                case nameof(XF.Picker.Title):
                    PickerControl.Title = (string)attributeValue;
                    break;
                case nameof(XF.Picker.CharacterSpacing):
                    PickerControl.CharacterSpacing = AttributeHelper.StringToDouble((string)attributeValue);
                    break;
                case nameof(XF.Picker.TextColor):
                    PickerControl.TextColor = AttributeHelper.StringToColor((string)attributeValue);
                    break;
                case nameof(XF.Picker.SelectedIndex):
                    PickerControl.FontSize = AttributeHelper.StringToDouble((string)attributeValue);
                    break;
                case nameof(XF.Span.FontAttributes):
                    PickerControl.FontAttributes = (XF.FontAttributes)AttributeHelper.GetInt(attributeValue);
                    break;
                case nameof(XF.Span.FontSize):
                    PickerControl.FontSize = AttributeHelper.StringToDouble((string)attributeValue);
                    break;
                case nameof(XF.Span.FontFamily):
                    PickerControl.FontFamily = (string)attributeValue;
                    break;
                default:
                    base.ApplyAttribute(attributeEventHandlerId, attributeName, attributeValue, attributeEventUpdatesAttributeName);
                    break;
            }
        }

        partial void ApplyEventHandlerId(string attributeName, ulong attributeEventHandlerId);
    }
}
