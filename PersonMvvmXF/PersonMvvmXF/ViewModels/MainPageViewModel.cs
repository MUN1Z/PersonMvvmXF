using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PersonMvvmXF.Data;
using PersonMvvmXF.Entities;
using PersonMvvmXF.Services;
using Prism.Navigation;
using Xamarin.Forms;

namespace PersonMvvmXF.ViewModels
{
    public class MainPageViewModel : BaseViewModel, INavigationAware
    {
        protected readonly INavigationService _navigationService;
    
        private readonly Repository<Person> _repositoryPerson;
        private ObservableCollection<Person> _persons;

        public ICommand AddCommand { get; set; }
        public ICommand PersonClickCommand => new Command<Person>(PersonClick);


        public ObservableCollection<Person> Persons
        {
            get => _persons;
            set => SetProperty(ref _persons, value);
        }

        public MainPageViewModel(INavigationService navigationService) : base("Persons")
        {
            _navigationService = navigationService;
            _repositoryPerson = new Repository<Person>();
            _repositoryPerson.DeleteAll();
            AddCommand = new Command(AddPerson);
            LoadPersons();
        }

        public void LoadPersons()
        {
            Persons = new ObservableCollection<Person>(_repositoryPerson.GetAll());
        }

        public async void AddPerson()
        {
            _repositoryPerson.Persist(await ServiceGenerator.GetService().GetPerson());
            LoadPersons();
        }

        public void PersonClick(Person person)
        {
            var _params = new NavigationParameters();
            _params.Add("Person", person);
            _navigationService.NavigateAsync(new Uri("PersonPage", UriKind.Relative), _params);
        }

        public void OnNavigatedFrom(NavigationParameters parameters) { }

        public void OnNavigatedTo(NavigationParameters parameters) { }

        public void OnNavigatingTo(NavigationParameters parameters) { }

    }
}
