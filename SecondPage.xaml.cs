namespace MauiAndroidNavigationTest;

public partial class SecondPage : ContentPage
{
	public SecondPage()
	{
		InitializeComponent();
	}
    private void OnButtonClicked(object sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            var newPage = new ThirdPage();
            NavigationPage.SetHasNavigationBar(newPage, true);

            var navPage = new NavigationPage(newPage);
            NavigationPage.SetHasNavigationBar(navPage, true);

            this.Navigation.PushAsync(navPage).ContinueWith((Task t) => { }, TaskContinuationOptions.OnlyOnFaulted);
        });
    }
}