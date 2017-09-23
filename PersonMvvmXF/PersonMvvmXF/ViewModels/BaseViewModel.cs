using Prism.Mvvm;
using Prism.Navigation;

namespace PersonMvvmXF.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public BaseViewModel(string title)
        {
            Title = title;
        }
    }
}
