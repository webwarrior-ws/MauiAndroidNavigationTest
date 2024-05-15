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

    member this.OnButtonClicked(sender: obj, e: EventArgs) =
        Android.Util.Log.Debug("Custom", "Go to third page button clicked") |> ignore
        MainThread.BeginInvokeOnMainThread(fun () ->
            let newPage = new ThirdPage()
            NavigationPage.SetHasNavigationBar(newPage, true)

            let navPage = new NavigationPage(newPage)
            NavigationPage.SetHasNavigationBar(navPage, true)

            Android.Util.Log.Debug("Custom", "Navigating to third page") |> ignore
            this.Navigation.PushAsync(navPage).ContinueWith((fun (t: Task) -> 
                Android.Util.Log.Debug("Custom" ,sprintf "Exception: %A" t.Exception) |> ignore
            ), TaskContinuationOptions.OnlyOnFaulted)
            |> ignore
        )