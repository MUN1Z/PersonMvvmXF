using System.Collections.Generic;
using System.Collections.ObjectModel;
using PersonMvvmXF.Entities;
using PersonMvvmXF.Services;
using Prism.Navigation;

namespace PersonMvvmXF.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        private ObservableCollection<Person> _persons;

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set { SetProperty(ref _persons, value); }
        }

        public MainPageViewModel(INavigationService navigationService) : base("PersonMvvmXF", navigationService)
        {
            GetPerson();
        }

        public async void GetPerson()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 10; i++)
            {
                persons.Add(await ServiceGenerator.GetService().GetPerson());
            }

            Persons = new ObservableCollection<Person>(persons); 
        }

    }
}
