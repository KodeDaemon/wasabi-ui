using Xamarin.Forms;

namespace WasabiUI.Forms.Core.Renderers
{
    public interface IWasabiVisualElement : IWasabiNavigableElement
    {

        bool InputTransparent { get; set; }

        bool IsEnabled { get; set; }

        double X { get; set; }

        double Y { get; set; }

        double AnchorX { get; set; }

        double AnchorY { get; set; }

        double TranslationX { get; set; }

        double TranslationY { get; set; }

        double Width { get; set; }

        double Height { get; set; }

        double Rotation { get; set; }

        double RotationX { get; set; }

        double RotationY { get; set; }

        double Scale { get; set; }

        double ScaleX { get; set; }

        double ScaleY { get; set; }

        string Transform { get; set; }

        IVisual Visual { get; set; }
    }
}