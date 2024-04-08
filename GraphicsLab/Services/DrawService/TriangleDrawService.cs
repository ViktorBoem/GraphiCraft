using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsLab.Services.Interface;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using GraphicsLab.MVVM.Model.Triangle;
using System.Numerics;

namespace GraphicsLab.Services.DrawService
{
    class TriangleDrawService : IDrawService
    {
        DrawingTriangleParameters _drawingTriangleParameters = new DrawingTriangleParameters();
        TrianglesRepository _triangles = new TrianglesRepository();

        public void Draw(object sender, SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;

            var a = _drawingTriangleParameters.A;
            var b = _drawingTriangleParameters.B;
            var c = _drawingTriangleParameters.C;

            string? vertexShape = DrawingTriangleParameters.VertexShape;
            Color? triangleColor = DrawingTriangleParameters.TriangleColor;

            if (!CanDrawTriangle(canvas, a, b, c, out string message))
            {
                AppShell.Current.DisplayAlert("Error!!! Error!!! Error!!!", message, "OK");
                return;
            }

            _triangles.AddTriangle(_drawingTriangleParameters);

            foreach (var triangle in _triangles.GetAllTriangles())
            {
                DrawTriangle(canvas, DrawingTriangleParameters.TriangleColor, triangle.A, triangle.B, triangle.C);
                ViewTriangleVertices(canvas, DrawingTriangleParameters.TriangleColor, DrawingTriangleParameters.VertexShape, triangle.A, triangle.B, triangle.C);
            }
        }

        private void DrawTriangle(SKCanvas canvas, Color? triangleColor, SKPoint a, SKPoint b, SKPoint c)
        {
            using var paint = new SKPaint
            {
                Color = new SKColor((byte)(triangleColor.Red * 255),
                                    (byte)(triangleColor.Green * 255),
                                    (byte)(triangleColor.Blue * 255),
                                    (byte)(triangleColor.Alpha * 255)),
                StrokeWidth = 2.5f,
                IsAntialias = true,
                StrokeCap = SKStrokeCap.Round,
            };

            var path = new SKPath();
            path.MoveTo(a);
            path.LineTo(b);
            path.LineTo(c);
            path.Close();

            canvas.DrawPath(path, paint);
        }

        private void ViewTriangleVertices(SKCanvas canvas, Color? triangleColor, string? vertexShape, params SKPoint[] vertices)
        {
            using var paint = new SKPaint
            {
                Color = new SKColor((byte)(triangleColor.Red * 255),
                                    (byte)(triangleColor.Green * 255),
                                    (byte)(triangleColor.Blue * 255),
                                    (byte)(triangleColor.Alpha * 255)),
                StrokeWidth = 10,
                IsAntialias = true,
            };

            switch (vertexShape)
            {
                case "Default":
                    paint.StrokeCap = SKStrokeCap.Butt;
                    break;
                case "Circle":
                    paint.StrokeCap = SKStrokeCap.Round;
                    break;
                case "Square":
                    paint.StrokeCap = SKStrokeCap.Square;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unsupported vertex shape");
            }

            foreach (var vertex in vertices)
            {
                canvas.DrawLine(vertex, vertex, paint);
            }
        }

        private bool CanDrawTriangle(SKCanvas canvas, SKPoint a, SKPoint b, SKPoint c, out string message)
        {
            if (a.IsEmpty && b.IsEmpty && c.IsEmpty)
            {
                message = "Не можливо намалювати трикутник: введіть параметри точок.";
                return false;
            }

            if (a.Equals(b) || b.Equals(c) || a.Equals(c))
            {
                message = "Не можливо намалювати трикутник: дві або більше точок збігаються.";
                return false;
            }

            var clipBounds = canvas.LocalClipBounds;
            if (!clipBounds.Contains(a) || !clipBounds.Contains(b) || !clipBounds.Contains(c))
            {
                message = "Не можливо намалювати трикутник: одна або більше точок знаходяться за межами канви.";
                return false;
            }


            float area = Math.Abs(a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y)) / 2.0f;
            if (area == 0)
            {
                message = "Не можливо намалювати трикутник: точки лежать на одній прямій.";
                return false;
            }

            message = string.Empty;
            return true;
        }

        
    }
}
