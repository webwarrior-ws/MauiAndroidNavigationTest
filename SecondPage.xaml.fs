namespace MauiAndroidNavigationTest

open System
open System.Threading.Tasks
open System.Linq
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

            Android.Util.Log.Error("Errors", "Switching to new page") |> ignore
            Android.Util.Log.Error("Errors", sprintf "NavPage Handler = %A" navPage.Handler) |> ignore
            navPage.HandlerChanged.Add(fun _e -> 
                try
                    Android.Util.Log.Error("Errors", sprintf "NavPage.Handler = %A" navPage.Handler) |> ignore
                    Android.Util.Log.Error("Errors", sprintf "NavPage.Handler.MauiContext = %A" navPage.Handler.MauiContext) |> ignore
                    Android.Util.Log.Error("Errors", sprintf "NavPage.Handler.MauiContext.Context = %A" navPage.Handler.MauiContext.Context) |> ignore
                with
                | :? NullReferenceException -> ()
            )
            navPage.LayoutChanged.Add(fun _e -> 
                try
                    Android.Util.Log.Error("Errors", sprintf "(LayoutChanged)Handler = %A" navPage.Handler) |> ignore
                    Android.Util.Log.Error("Errors", sprintf "(LayoutChanged)Handler.MauiContext = %A" navPage.Handler.MauiContext) |> ignore
                    Android.Util.Log.Error("Errors", sprintf "(LayoutChanged)Handler.MauiContext.Context = %A" navPage.Handler.MauiContext.Context) |> ignore
                with
                | :? NullReferenceException -> ()
            )

            Android.Util.Log.Error("Errors", sprintf  "currentPage Navigation stack (before push) = %A" (this.Navigation.NavigationStack.ToArray())) |> ignore
            Android.Util.Log.Error("Errors", sprintf  "navPage Navigation stack (before push) = %A" (navPage.Navigation.NavigationStack.ToArray())) |> ignore

            this.Navigation.PushAsync(navPage).ContinueWith((fun (t: Task) -> 
                ()
            ), TaskContinuationOptions.OnlyOnFaulted)
            |> ignore

            Android.Util.Log.Error("Errors", sprintf  "currentPage Navigation stack (after push) = %A" (this.Navigation.NavigationStack.ToArray())) |> ignore
            Android.Util.Log.Error("Errors", sprintf  "navPage Navigation stack (after push) = %A" (navPage.Navigation.NavigationStack.ToArray())) |> ignore
        )