using Microsoft.AspNetCore.Components;
using WasabiUI.Forms.Components.Interfaces;
using Xamarin.Forms;

namespace WasabiUI.Forms.Components
{
    public class WasabiLabel : WasabiComponentBase, ILabel
    {
        public Menu Menu { get; set; }
        public string AutomationId { get; set; }
        public string ClassId { get; set; }
        public INavigation Navigation { get; set; }
        public Style Style { get; set; }
        public bool InputTransparent { get; set; }
        public bool IsEnabled { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double AnchorX { get; set; }
        public double AnchorY { get; set; }
        public double TranslationX { get; set; }
        public double TranslationY { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Rotation { get; set; }
        public double RotationX { get; set; }
        public double RotationY { get; set; }
        public double Scale { get; set; }
        public double ScaleX { get; set; }
        public double ScaleY { get; set; }
        public string Transform { get; set; }
        public IVisual Visual { get; set; }
        public LayoutOptions VerticalOptions { get; set; }
        public LayoutOptions HorizontalOptions { get; set; }
        public Xamarin.Forms.Thickness Margin { get; set; }
        public double MarginLeft { get; set; }
        public double MarginTop { get; set; }
        public double MarginRight { get; set; }
        public double MarginBottom { get; set; }
        public TextAlignment HorizontalTextAlignment { get; set; }
        public TextAlignment VerticalTextAlignment { get; set; }
        public Color TextColor { get; set; }
        public Font Font { get; set; }
        public string Text { get; set; }
        public string FontFamily { get; set; }
        public double FontSize { get; set; }
        public FontAttributes FontAttributes { get; set; }
        public TextDecorations TextDecorations { get; set; }
        public LineBreakMode LineBreakMode { get; set; }
        public double LineHeight { get; set; }
        public int MaxLines { get; set; }
    }
}
