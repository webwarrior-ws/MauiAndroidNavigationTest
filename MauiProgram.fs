namespace MauiAndroidNavigationTest

open Microsoft.Maui.Controls.Hosting
open Microsoft.Maui.Hosting

type MauiProgram =
    static member CreateMauiApp() =
        MauiApp
            .CreateBuilder()
            .UseMauiApp<App>()
            .ConfigureFonts(fun fonts ->
                fonts
                    .AddFont("OpenSans-Regular.ttf", "OpenSansRegular")
                    .AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold")
                |> ignore
            )
            .Build()
