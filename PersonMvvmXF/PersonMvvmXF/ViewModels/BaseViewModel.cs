using Prism.Mvvm;
using Prism.Navigation;

namespace PersonMvvmXF.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public BaseViewModel(string title, INavigationService navigationService)
        {
            Title = title;
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void NavigateTo(string page)
        {
            _navigationService.NavigateAsync(page);
        }
        
    }
}
