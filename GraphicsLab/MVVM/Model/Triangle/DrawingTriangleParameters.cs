using SkiaSharp;

namespace GraphicsLab.MVVM.Model.Triangle
{
    public class DrawingTriangleParameters
    {
        public static float? X1 { get; set; }
        public static float? Y1 { get; set; }
        public static float? X2 { get; set; }
        public static float? Y2 { get; set; }
        public static Color? TriangleColor { get; set; }
        public static string? VertexShape { get; set; }

        public SKPoint A => new SKPoint(X1 ?? 0, Y1 ?? 0);
        public SKPoint B => new SKPoint(X2 ?? 0, Y2 ?? 0);
        public SKPoint C => FindC(A, B);

        public SKPoint FindC(SKPoint a, SKPoint b)
        {
            float angle = 60 * (float)Math.PI / 180;

            float x3 = (float)(Math.Cos(angle) * (b.X - a.X) - Math.Sin(angle) * (b.Y - a.Y) + a.X);
            float y3 = (float)(Math.Sin(angle) * (b.X - a.X) + Math.Cos(angle) * (b.Y - a.Y) + a.Y);

            return new SKPoint(x3, y3);
        }
    }
}
