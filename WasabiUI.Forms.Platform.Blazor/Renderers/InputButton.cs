using System;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.RenderTree;

namespace WasabiUI.Forms.Platform.Blazor.Renderers
{
    public class InputButton : InputBase<bool>
    {
        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "input");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "type", "button");
            builder.AddAttribute(3, "id", Id);
            builder.AddAttribute(4, "class", CssClass);
            //builder.AddAttribute(5, "checked", BindMethods.GetValue(CurrentValue));
            //builder.AddAttribute(6, "onchange", BindMethods.SetValueHandler(__value => CurrentValue = __value, CurrentValue));
            builder.CloseElement();
        }

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out bool result, out string validationErrorMessage)
            => throw new NotImplementedException($"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");
    }
}
