using JetBrains.Annotations;
using Microsoft.Maui.Controls;
using System;

namespace MauiAndroidNavigationTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var newPage = new SecondPage();
                NavigationPage.SetHasNavigationBar(newPage, true);

                var navPage = new NavigationPage(newPage);

                //this.Navigation.PushAsync(navPage).ContinueWith((Task t) => { }, TaskContinuationOptions.OnlyOnFaulted);
                this.Navigation.InsertPageBefore(navPage, this);
                this.Navigation.PopAsync().ContinueWith((Task t) => { }, TaskContinuationOptions.OnlyOnFaulted);
            });
        }
    }

}
