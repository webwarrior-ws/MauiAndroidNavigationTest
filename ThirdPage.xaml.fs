namespace MauiAndroidNavigationTest

open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Xaml

type ThirdPage() =
    inherit ContentPage()

    let _ = base.LoadFromXaml(typeof<ThirdPage>)

    override self.OnBackButtonPressed() =
        self.Parent |> ignore
        self.Navigation.NavigationStack |> ignore
        (self.Parent.Parent :?> NavigationPage).Navigation.NavigationStack |> ignore
        false
