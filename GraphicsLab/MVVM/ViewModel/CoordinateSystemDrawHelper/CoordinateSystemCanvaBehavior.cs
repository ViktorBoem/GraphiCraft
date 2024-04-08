using System.Windows.Input;
using SkiaSharp.Views.Maui.Controls;
using SkiaSharp.Views.Maui;

namespace GraphicsLab.MVVM.ViewModel.CoordinateSystemDrawHelper
{
    public class CoordinateSystemCanvaBehavior : Behavior<SKCanvasView>
    {
        TriangleDrawViewModel triangleDrowViewModel = new TriangleDrawViewModel();

        protected override void OnAttachedTo(SKCanvasView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.PaintSurface += OnPaintSurface;
        }

        protected override void OnDetachingFrom(SKCanvasView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.PaintSurface -= OnPaintSurface;
        }


        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {

            var canvasView = sender as SKCanvasView;

            if (canvasView?.BindingContext is CoordinateSystemDrawViewModel viewModel)
            {
                ICommand command = viewModel.DrawCoordinateSystemCommand;

                if (command?.CanExecute(e) ?? false)
                {
                    command.Execute(e);
                }
            }

            if (TriangleDrawViewModel.IsTriangleDraw)
            {
                ICommand command = triangleDrowViewModel.DrawTriangleCommand;

                if (command?.CanExecute(e) ?? false)
                {
                    command.Execute(e);
                }
            }
        }
    }
}
