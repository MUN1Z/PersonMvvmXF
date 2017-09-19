using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PersonMvvmXF.Data;
using PersonMvvmXF.Entities;
using PersonMvvmXF.Services;
using Prism.Navigation;

namespace PersonMvvmXF.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly Repository<Person> _repositoryPerson;
        private ObservableCollection<Person> _persons;

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set { SetProperty(ref _persons, value); }
        }

        public MainPageViewModel(INavigationService navigationService) : base("PersonMvvmXF", navigationService)
        {
            _repositoryPerson = new Repository<Person>();
            GetPerson();
        }

        public async void GetPerson()
        {
            _repositoryPerson.DeleteAll();

            for (int i = 0; i < 10; i++)
            {
                _repositoryPerson.Persist(await ServiceGenerator.GetService().GetPerson());
            }

            Persons = new ObservableCollection<Person>(_repositoryPerson.GetAll());

            var person = _repositoryPerson.GetById(Persons.FirstOrDefault().Id);

            _repositoryPerson.Delete(Persons.LastOrDefault());

            Persons = new ObservableCollection<Person>(_repositoryPerson.GetAll());
            
        }

    }
}
