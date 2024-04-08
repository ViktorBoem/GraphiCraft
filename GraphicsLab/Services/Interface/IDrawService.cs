using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace GraphicsLab.Services.Interface
{
    internal interface IDrawService
    {
        void Draw(object sender, SKPaintSurfaceEventArgs e);
    }
}
