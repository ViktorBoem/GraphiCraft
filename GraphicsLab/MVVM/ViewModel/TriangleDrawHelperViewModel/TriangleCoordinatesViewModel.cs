using GraphicsLab.MVVM.Model.Triangle;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GraphicsLab.MVVM.ViewModel.TriangleDrawHelperViewModel
{
    public class TriangleCoordinatesViewModel : INotifyPropertyChanged
    {
        public TriangleCoordinatesViewModel()
        {
            (X1, Y1, X2, Y2) = (null, null, null, null);
        }

        public float? X1
        {
            get => DrawingTriangleParameters.X1;
            set
            {
                DrawingTriangleParameters.X1 = value;
                OnPropertyChanged();
            }
        }

        public float? Y1
        {
            get => DrawingTriangleParameters.Y1;
            set
            {
                DrawingTriangleParameters.Y1 = value;
                OnPropertyChanged();
            }
        }

        public float? X2
        {
            get => DrawingTriangleParameters.X2;
            set
            {
                DrawingTriangleParameters.X2 = value;
                OnPropertyChanged();
            }
        }

        public float? Y2
        {
            get => DrawingTriangleParameters.Y2;
            set
            {
                DrawingTriangleParameters.Y2 = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
