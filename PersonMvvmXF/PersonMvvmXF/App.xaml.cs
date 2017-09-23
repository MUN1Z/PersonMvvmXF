using Prism.Unity;
using PersonMvvmXF.Views;
using Xamarin.Forms;

namespace PersonMvvmXF
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>("NavigationPage");
            Container.RegisterTypeForNavigation<MainPage>("MainPage");
            Container.RegisterTypeForNavigation<PersonPage>("PersonPage");
        }
    }
}
