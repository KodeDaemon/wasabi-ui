using System;
using Xamarin.Forms;

namespace WasabiUI.Forms.Platform.Blazor
{
    public interface IVisualElementRenderer : IRegisterable, IDisposable
    {
        /// <summary>
        /// Gets the VisualElement associated with this renderer.
        /// </summary>
        /// <value>The VisualElement.</value>
        VisualElement Element { get; }

        /// <summary>
        /// Gets the native view associated with this renderer.
        /// </summary>
        /// <value>The native view.</value>
        ComponentContainer NativeView { get; }

        /// <summary>
        /// Sets the VisualElement associated with this renderer.
        /// </summary>
        /// <param name="element">New element.</param>
        void SetElement(VisualElement element);

        SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint);

        void UpdateLayout();

        //Rect GetNativeContentGeometry();
    }
}
