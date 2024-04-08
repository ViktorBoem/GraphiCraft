using System.ComponentModel;
using GraphicsLab.MVVM.Model.Triangle;
using System.Runtime.CompilerServices;

namespace GraphicsLab.MVVM.ViewModel.TriangleDrawHelperViewModel
{
    public class PickerShapeViewModel : INotifyPropertyChanged
    {
        public List<string> Shapes { get; } = new List<string>
        {
            "Default", "Circle", "Square", 
        };

        public PickerShapeViewModel()
        {
            SelectedShape = Shapes[0];
        }

        public string? SelectedShape
        {
            get => DrawingTriangleParameters.VertexShape;
            set
            {
                DrawingTriangleParameters.VertexShape = value;
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
