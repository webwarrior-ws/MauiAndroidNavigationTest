namespace MauiAndroidNavigationTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var firstPage = new MainPage();

            var navPage = new NavigationPage(firstPage);
            NavigationPage.SetHasNavigationBar(firstPage, true);

            MainPage = navPage;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Title = "MauiAndroidNavigationTest";
            return window;
        }
    }
}
