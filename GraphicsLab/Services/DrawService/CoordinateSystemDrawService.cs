using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsLab.Services.Interface;
using Microsoft.Maui.Controls;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace GraphicsLab.Services.DrawService
{
    internal class CoordinateSystemDrawService : IDrawService
    {
        public void Draw(object sender, SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            SKImageInfo info = e.Info;

            canvas.Clear(SKColors.White);

            canvas.Translate(info.Width / 2f, info.Height / 2f);

            canvas.Scale(1, -1);

            DrawAxes(canvas, info);
            DrawAxisLabels(canvas, info, true);
        }

        private void DrawAxes(SKCanvas canvas, SKImageInfo info)
        {
            using (SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Black,
                StrokeWidth = 2
            })
            {
                canvas.DrawLine(0, -info.Height / 2, 0, info.Height / 2, paint);
                canvas.DrawLine(-info.Width / 2, 0, info.Width / 2, 0, paint);
            }

            DrawGrid(canvas, info);
        }

        private void DrawGrid(SKCanvas canvas, SKImageInfo info)
        {
            using (SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = new SKColor(0, 0, 0, 50),
                StrokeWidth = 1
            })
            {
                int divisionSize = 25;
                int horizontalDivisions = info.Width / divisionSize;
                int verticalDivisions = info.Height / divisionSize;

                for (int i = -horizontalDivisions / 2; i <= horizontalDivisions / 2; i++)
                {
                    float x = i * divisionSize;
                    canvas.DrawLine(x, -info.Height / 2, x, info.Height / 2, paint);
                }

                for (int i = -verticalDivisions / 2; i <= verticalDivisions / 2; i++)
                {
                    float y = i * divisionSize;
                    canvas.DrawLine(-info.Width / 2, y, info.Width / 2, y, paint);
                }
            }
        }

        private void DrawAxisLabels(SKCanvas canvas, SKImageInfo info, bool realSize = false)
        {
            using (SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.StrokeAndFill,
                Color = SKColors.Black,
                StrokeWidth = 0.5f,
                TextSize = 10,
                TextAlign = SKTextAlign.Center,
                SubpixelText = true,
                IsEmbeddedBitmapText = true,
                IsLinearText = true,
                IsAntialias = true
            })
            {
                int divisionSize = 25;
                int horizontalDivisions = info.Width / divisionSize;
                int verticalDivisions = info.Height / divisionSize;

                canvas.Save();
                canvas.Scale(1, -1);

                for (int i = -horizontalDivisions / 2; i <= horizontalDivisions / 2; i++)
                {
                    if (i != 0)
                    {
                        float x = i * divisionSize;
                        canvas.DrawText(x.ToString(), x - paint.TextSize / 4, paint.TextSize, paint);
                    }
                }

                paint.TextAlign = SKTextAlign.Left;

                for (int i = -verticalDivisions / 2; i <= verticalDivisions / 2; i++)
                {
                    if (i != 0)
                    {
                        float y = i * divisionSize;
                        canvas.DrawText(y.ToString(), paint.TextSize / 2, -(y - paint.TextSize / 2), paint);
                    }
                }

                canvas.Restore();
            }
        }
    }
}
