using PersonMvvmXF.Entities;
using Prism.Navigation;

namespace PersonMvvmXF.ViewModels
{
    public class PersonPageViewModel : BaseViewModel, INavigationAware
    {
        protected readonly INavigationService _navigationService;

        private Person _person;

        public Person Person
        {
            get => _person;
            set => SetProperty(ref _person, value);
        }
        
        public PersonPageViewModel(INavigationService navigationService) : base("Person")
        {
            _navigationService = navigationService;
        }
      
        public void OnNavigatedFrom(NavigationParameters parameters) { }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Person = (Person)parameters["Person"];
        }

        public void OnNavigatingTo(NavigationParameters parameters) { }
    }
}
