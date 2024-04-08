using GraphicsLab.Services.DrawService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using SkiaSharp;
using GraphicsLab.Services.Interface;

namespace GraphicsLab.MVVM.ViewModel
{
    internal class TriangleDrawViewModel
    {
        private readonly IDrawService _triangleDrawService = new TriangleDrawService();

        public ICommand InvalidateCanvaCommand { get; }
        public ICommand DrawTriangleCommand { get; }

        public ICommand IsTriangleDrawCommand => new Command(() => IsTriangleDraw = true);


        public static bool IsTriangleDraw { get; set; } = false;

        public TriangleDrawViewModel()
        {
            InvalidateCanvaCommand = new Command<SKCanvasView>(InvalidateCanva);
            DrawTriangleCommand = new Command<SKPaintSurfaceEventArgs>(TriangleDraw);
        }

        private void TriangleDraw(SKPaintSurfaceEventArgs e)
        {
            _triangleDrawService.Draw(this, e);
        }

        private void InvalidateCanva(SKCanvasView canvasView)
        {
            IsTriangleDraw = true;
            canvasView.InvalidateSurface();
        }
    }
}
