using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using WasabiUI.Forms.Core;
using Xamarin.Forms;

namespace WasabiUI.Forms.Components
{
    public class BuildableBaseComponent : BaseMatDomComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Inject]
        protected DeviceState DeviceState { get; set; }

        public string Id => IdGeneratorHelper.Generate("wasabi_id_");

        public double Width { get; set; } = double.NaN;

        public double Height { get; set; } = double.NaN;

        public double MinWidth { get; set; } = 0;

        public double MinHeight { get; set; } = 0;

        public double MaxWidth { get; set; } = double.PositiveInfinity;

        public double MaxHeight { get; set; } = double.PositiveInfinity;

        public Thickness Margin { get; set; } = Thickness.Zero;

        public Thickness Padding { get; set; } = Thickness.Zero;

        public string Tag { get; set; }

        public Alignment HorizontalAlignment { get; set; } = Alignment.Stretch;

        public Alignment VerticalAlignment { get; set; } = Alignment.Stretch;

        public double Opacity { get; set; } = 1;
    }

    public struct Thickness : IEquatable<Thickness>
    {
        public static readonly Thickness Zero = new Thickness(0);

        public double Left { get; }

        public double Top { get; }

        public double Right { get; }

        public double Bottom { get; }

        public double HorizontalThickness => Left + Right;

        public double VerticalThickness => Top + Bottom;

        public Point TopLeft => new Point(Left, Top);

        public Point Size => new Point(Left + Right, Top + Bottom);

        internal bool IsDefault => Left == 0 && Top == 0 && Right == 0 && Bottom == 0;

        public Thickness(double uniformSize) : this(uniformSize, uniformSize, uniformSize, uniformSize)
        {
        }

        public Thickness(double horizontalSize, double verticalSize) : this(horizontalSize, verticalSize, horizontalSize, verticalSize)
        {
        }

        public Thickness(double left, double top, double right, double bottom) : this()
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public static implicit operator Thickness(double uniformSize) =>
            new Thickness(uniformSize);

        public static implicit operator Thickness((double horizontalSize, double verticalSize) t) =>
            new Thickness(t.horizontalSize, t.verticalSize);

        public static implicit operator Thickness((double left, double top, double right, double bottom) t) =>
            new Thickness(t.left, t.top, t.right, t.bottom);

        public static bool operator ==(Thickness a, Thickness b) => a.Equals(b);

        public static bool operator !=(Thickness a, Thickness b) => !(a == b);

        public override string ToString() => $"[{Left}, {Top}, {Right}, {Bottom}]";

        public override bool Equals(object obj) => obj is Thickness t && Equals(t);

        public bool Equals(Thickness other) =>
            Left == other.Left &&
            Top == other.Top &&
            Right == other.Right &&
            Bottom == other.Bottom;

        public override int GetHashCode()
        {
            var hashCode = -1819631549;
            hashCode = hashCode * -1521134295 + Left.GetHashCode();
            hashCode = hashCode * -1521134295 + Top.GetHashCode();
            hashCode = hashCode * -1521134295 + Right.GetHashCode();
            hashCode = hashCode * -1521134295 + Bottom.GetHashCode();
            return hashCode;
        }
    }

    public struct Point
    {
        public static readonly Point Zero = new Point(0, 0);
        public static readonly Point One = new Point(1, 1);
        public static readonly Point UnitX = new Point(1, 0);
        public static readonly Point UnitY = new Point(0, 1);
        public static readonly Point PositiveInfinity = new Point(double.PositiveInfinity, double.PositiveInfinity);

        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double this[int dimension]
        {
            get
            {
                switch (dimension)
                {
                    case 0: return X;
                    case 1: return Y;
                    default: throw new ArgumentOutOfRangeException(nameof(dimension));
                }
            }
        }

        public Point WithX(double x) => new Point(x, Y);
        public Point WithY(double y) => new Point(X, y);
        public Point OrWhereNaN(Point fallbackValue) =>
            new Point(X.OrIfNan(fallbackValue.X), Y.OrIfNan(fallbackValue.Y));

        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();

        public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
        public static Point operator -(Point a, Point b) => a + -b;
        public static Point operator -(Point p) => new Point(-p.X, -p.Y);
        public static Point operator *(Point a, Point b) => new Point(a.X * b.X, a.Y * b.Y);
        public static Point operator *(double d, Point p) => new Point(d * p.X, d * p.Y);
        public static Point operator *(Point p, double d) => new Point(d * p.X, d * p.Y);

        public static bool operator ==(Point a, Point b) => a.Equals(b);
        public static bool operator !=(Point a, Point b) => !a.Equals(b);

        public static Point Min(Point a, Point b) => new Point(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y));
        public static Point Max(Point a, Point b) => new Point(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y));

        public static Point Clamp(Point point, Point min, Point max) => new Point(
            Helpers.Clamp(point.X, min.X, max.X),
            Helpers.Clamp(point.Y, min.Y, max.Y));

        public override string ToString() => $"({X}, {Y})";
    }
    public enum Alignment
    {
        Stretch, Start, Center, End
    }

    public enum ImageStretch
    {
        None, Fill, Uniform, UniformToFill
    }

    public class ColumnDefinition
    {
        public GridLength Width { get; set; }

        public double MinWidth { get; set; } = 0;

        public double MaxWidth { get; set; } = double.PositiveInfinity;

        public ColumnDefinition(GridLength size) => Width = size;
    }

    public static class Helpers
    {
        public const Orientation Landscape = Orientation.Landscape;
        public const Orientation Portrait = Orientation.Portrait;
        public const Alignment Left = Alignment.Start;
        public const Alignment Top = Alignment.Start;
        public const Alignment Right = Alignment.End;
        public const Alignment Bottom = Alignment.End;
        public const Alignment Center = Alignment.Center;
        public const Alignment Stretch = Alignment.Stretch;
        public const ImageStretch None = ImageStretch.None;
        public const ImageStretch Fill = ImageStretch.Fill;
        public const ImageStretch Uniform = ImageStretch.Uniform;
        public const ImageStretch UniformToFill = ImageStretch.UniformToFill;



        public static IReadOnlyList<RowDefinition> Rows(params string[] sizeStrings) =>
            sizeStrings.Select(s => new RowDefinition(GridLength.Parse(s))).ToList();

        public static IReadOnlyList<ColumnDefinition> Columns(params string[] sizeStrings) =>
            sizeStrings.Select(s => new ColumnDefinition(GridLength.Parse(s))).ToList();

        public static double Clamp(double value, double min, double max) =>
            value < min ? min : (value > max ? max : value);

        public static double OrIfNan(this double value, double fallbackValue) =>
            double.IsNaN(value) ? fallbackValue : value;

        public static bool EqualsApprox(double a, double b, double tolerance = .001) =>
            Math.Abs(a - b) <= tolerance;

        public static Thickness T(double uniformSize) =>
            new Thickness(uniformSize);

        public static Thickness T(double horizontalSize, double verticalSize) =>
            new Thickness(horizontalSize, verticalSize, horizontalSize, verticalSize);

        public static Thickness T(double left, double top, double right, double bottom) =>
            new Thickness(left, top, right, bottom);
    }

    public class RowDefinition
    {
        public GridLength Height { get; set; }

        public double MinHeight { get; set; } = 0;

        public double MaxHeight { get; set; } = double.PositiveInfinity;

        public RowDefinition(GridLength size) => Height = size;
    }

    public struct GridLength
    {
        public double Value { get; }

        public GridUnitType GridUnitType { get; }

        public bool IsAbsolute => GridUnitType == GridUnitType.Absolute;

        public bool IsAuto => GridUnitType == GridUnitType.Auto;

        public bool IsStar => GridUnitType == GridUnitType.Star;

        public GridLength(double value, GridUnitType unitType) : this()
        {
            Value = value;
            GridUnitType = unitType;
        }

        public static GridLength Parse(string s)
        {
            if (s == "*")
                return new GridLength(1, GridUnitType.Star);

            if (s.Equals("auto", StringComparison.OrdinalIgnoreCase))
                return new GridLength(1, GridUnitType.Auto);

            if (double.TryParse(s, out var absSize))
                return new GridLength(absSize, GridUnitType.Absolute);

            if (s.EndsWith("*") && double.TryParse(s.Substring(0, s.Length - 1), out var starSize))
                return new GridLength(starSize, GridUnitType.Star);

            throw new FormatException($"'{s}' is not a valid format for '{nameof(GridLength)}'");
        }


    }

    public enum GridUnitType
    {
        Absolute, Star, Auto
    }
}
