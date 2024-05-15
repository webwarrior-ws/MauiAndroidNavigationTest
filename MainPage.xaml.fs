namespace MauiAndroidNavigationTest

open System
open System.Threading.Tasks
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Xaml
open Microsoft.Maui.ApplicationModel


type MainPage() =
    inherit ContentPage()

    let _ = base.LoadFromXaml(typeof<MainPage>)
    
    member this.OnCounterClicked(sender: obj, e: EventArgs) =
        MainThread.BeginInvokeOnMainThread(fun () ->
            let newPage = new SecondPage()
            NavigationPage.SetHasNavigationBar(newPage, true)

            let navPage = new NavigationPage(newPage)

            this.Navigation.InsertPageBefore(navPage, this)
            this.Navigation.PopAsync().ContinueWith((fun (t: Task) -> 
                ()
            ), TaskContinuationOptions.OnlyOnFaulted)
            |> ignore
        );
