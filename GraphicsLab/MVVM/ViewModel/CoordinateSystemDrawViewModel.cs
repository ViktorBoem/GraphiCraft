using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GraphicsLab.Services.DrawService;
using GraphicsLab.Services.Interface;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace GraphicsLab.MVVM.ViewModel
{
    public class CoordinateSystemDrawViewModel
    {
        private readonly IDrawService _drawService = new CoordinateSystemDrawService();
        public ICommand DrawCoordinateSystemCommand { get; set; }

        public CoordinateSystemDrawViewModel()
        {
            DrawCoordinateSystemCommand = new Command<SKPaintSurfaceEventArgs>(DrawCoordinateSystem);
        }

        private void DrawCoordinateSystem(SKPaintSurfaceEventArgs e)
        {
            _drawService.Draw(this, e);
        }
    }
}
