﻿namespace MauiAndroidNavigationTest

open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Xaml

type ThirdPage() =
    inherit ContentPage()

    let _ = base.LoadFromXaml(typeof<ThirdPage>)
