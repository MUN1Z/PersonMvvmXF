using System.Collections.ObjectModel;
using System.Windows.Input;
using PersonMvvmXF.Data;
using PersonMvvmXF.Entities;
using PersonMvvmXF.Services;
using Prism.Navigation;
using Xamarin.Forms;

namespace PersonMvvmXF.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly Repository<Person> _repositoryPerson;
        private ObservableCollection<Person> _persons;

        public ICommand AddCommand { get; set; }

        public ObservableCollection<Person> Persons
        {
            get => _persons;
            set => SetProperty(ref _persons, value);
        }

        public MainPageViewModel(INavigationService navigationService) : base("PersonMvvmXF", navigationService)
        {
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

    }
}
