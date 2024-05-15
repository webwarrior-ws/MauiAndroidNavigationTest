namespace MauiAndroidNavigationTest

open System
open System.Threading.Tasks
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Xaml
open Microsoft.Maui.ApplicationModel


type SecondPage() =
    inherit ContentPage()

    let _ = base.LoadFromXaml(typeof<SecondPage>)

    member this.OnCounterClicked(sender: obj, e: EventArgs) =
        MainThread.BeginInvokeOnMainThread(fun () ->
            let newPage = new ThirdPage()
            NavigationPage.SetHasNavigationBar(newPage, true)

            let navPage = new NavigationPage(newPage)
            NavigationPage.SetHasNavigationBar(navPage, true)

            this.Navigation.PushAsync(navPage).ContinueWith((fun (t: Task) -> 
                ()
            ), TaskContinuationOptions.OnlyOnFaulted)
            |> ignore
        )