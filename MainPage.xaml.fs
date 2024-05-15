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
        Android.Util.Log.Debug("Custom", "Go to second page button clicked") |> ignore
        MainThread.BeginInvokeOnMainThread(fun () ->
            let newPage = new SecondPage()
            NavigationPage.SetHasNavigationBar(newPage, true)

            let navPage = new NavigationPage(newPage)

            Android.Util.Log.Debug("Custom", "Navigating to second page") |> ignore
            this.Navigation.InsertPageBefore(navPage, this)
            this.Navigation.PopAsync().ContinueWith((fun (t: Task) -> 
                Android.Util.Log.Debug("Custom" ,sprintf "Exception: %A" t.Exception) |> ignore
            ), TaskContinuationOptions.OnlyOnFaulted)
            |> ignore
        );
