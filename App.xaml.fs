namespace MauiAndroidNavigationTest

open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Xaml

type App() as this =
    inherit Application()

    do this.LoadFromXaml typeof<App> |> ignore<App>
    do
        let firstPage = new MainPage()
        let navPage = new NavigationPage(firstPage)
        NavigationPage.SetHasNavigationBar(firstPage, false)

        this.MainPage <- navPage

    override this.CreateWindow(activationState: IActivationState) =
        let window = base.CreateWindow(activationState)
        window.Title <- "MauiAndroidNavigationTest"
        window
