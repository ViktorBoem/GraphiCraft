using System.ComponentModel;
using GraphicsLab.MVVM.Model.Triangle;
using Mopups.Services;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GraphicsLab.MVVM.View.Widgets;
using CommunityToolkit.Mvvm.Input;

namespace GraphicsLab.MVVM.ViewModel.TriangleDrawHelperViewModel
{
    public class ColorPickerViewModel : INotifyPropertyChanged
    {
        private static ColorPickerViewModel? _instance;
        public static ColorPickerViewModel Instance => _instance ?? (_instance = new ColorPickerViewModel());

        public IAsyncRelayCommand VisualColorPickerCommand { get; }

        private ColorPickerViewModel()
        {
            SelectedColor = Color.FromArgb("#1f1f1f");
            VisualColorPickerCommand = new AsyncRelayCommand(VisualColorPicker);
        }

        public Color? SelectedColor
        {
            get => DrawingTriangleParameters.TriangleColor;
            set
            {
                DrawingTriangleParameters.TriangleColor = value;
                OnPropertyChanged();
            }
        }

        private async Task VisualColorPicker()
        {
            await MopupService.Instance.PushAsync(new ColorPickerPopup());
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
