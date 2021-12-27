<!-- default file list -->
*Files to look at*:

* [MauiProgram.cs](./TabPage_CreateItems/MauiProgram.cs)
* [MainPage.xaml](./TabPage_CreateItems/MainPage.xaml)
* [MainPage.xaml.cs](./TabPage_CreateItems/MainPage.xaml.cs)
<!-- default file list end -->

# Create MAUI Tab Page Items Manually

This lesson explains how to use the [TabPage](http://docs.devexpress.com/MAUI/DevExpress.Maui.Navigation.TabPage) component with manually created tab items to implement bottom tab navigation in a .NET MAUI application.

1. Install a [.NET MAUI development](https://docs.microsoft.com/en-gb/dotnet/maui/get-started/installation) environment and open the solution in Visual Studio 22 Preview.
2. Register the following NuGet feed in Visual Studio: https://nuget.devexpress.com/free/api.  
	If you are an active DevExpress [Universal](https://www.devexpress.com/subscriptions/universal.xml) customer or have registered our [free Xamarin UI controls](https://www.devexpress.com/xamarin/), this MAUI preview will be available in your personal NuGet feed automatically.
4. Restore NuGet packages.  
5. Run the application on an Android device or emulator.  

<img src="./img/devexpress-maui-tab-page.png"/>

The following step-by-step instructions describe how to create the same application.

## Create a New MAUI Application and Add a Tab Page

Create a new .NET MAUI solution in Visual Studio 22 Preview.  
Refer to the following Microsoft documentation for more information on how to get started with .NET MAUI: [.NET Multi-platform App UI](https://docs.microsoft.com/dotnet/maui/).

Register https://nuget.devexpress.com/free/api as a package source in Visual Studio, if you are not an active DevExpress [Universal](https://www.devexpress.com/subscriptions/universal.xml) customer or have not yet registered our [free Xamarin UI controls](https://www.devexpress.com/xamarin/).

Install the **DevExpress.Maui.Navigation** package from your NuGet feed.

In the *MauiProgram.cs* file, register a handler for the [TabPage](http://docs.devexpress.com/MAUI/DevExpress.Maui.Navigation.TabPage) class:

```cs
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using DevExpress.Maui;

namespace TabPage_CreateItems {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
	    var builder = MauiApp.CreateBuilder();
                builder
                    .UseMauiApp<App>()
                    .UseDevExpress()
                    .ConfigureFonts(fonts =>
                        {
                            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                        });

            return builder.Build();
        }
    }
}
```

In the *MainPage.xaml* file, use the *dxn* prefix to declare the **DevExpress.Maui.Navigation** namespace and create a [TabPage](http://docs.devexpress.com/MAUI/DevExpress.Maui.Navigation.TabPage) instance:

```xaml
<dxn:TabPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:dxn="clr-namespace:DevExpress.Maui.Navigation;assembly=DevExpress.Maui.Navigation"
             x:Class="TabPage_CreateItems.MainPage">
</dxn:TabPage>
```

In the *MainPage.xaml.cs* file, change the MainPage’s base class from ContentPage to TabPage:

```cs
using DevExpress.Maui.Navigation;

namespace TabPage_CreateItems {
    public partial class MainPage : TabPage {
        public MainPage() {
            InitializeComponent();
        }
    }
}
```

## Create Tab Items
Add icons for tabs ([.svg files](./TabPage_CreateItems/Resources/Images/)) to the project and set their **Build Action** property to **MauiImage**.

Add [TabPageItem](http://docs.devexpress.com/MAUI/DevExpress.Maui.Navigation.TabPageItem) objects to the [TabPage.Items](http://docs.devexpress.com/MAUI/DevExpress.Maui.Navigation.TabPage.Items) collection:

```xaml
<dxn:TabPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:dxn="clr-namespace:DevExpress.Maui.Navigation;assembly=DevExpress.Maui.Navigation"
             xmlns:local="clr-namespace:TabPage_CreateItems"
             x:Class="TabPage_CreateItems.MainPage">
    <dxn:TabPageItem>
        <dxn:TabPageItem.Content>
            <ContentPage Title="Mail" IconImageSource="email">
                <Label Text="Mail List Here" 
                       HorizontalOptions="Center" 
                       VerticalOptions="CenterAndExpand"/>
            </ContentPage>   
        </dxn:TabPageItem.Content>
    </dxn:TabPageItem>

    <dxn:TabPageItem>
        <dxn:TabPageItem.Content>
            <ContentPage Title="Calendar" IconImageSource="calendar">
                <Label Text="Calendar Here" 
                       HorizontalOptions="Center" 
                       VerticalOptions="CenterAndExpand"/>
            </ContentPage>
        </dxn:TabPageItem.Content>
    </dxn:TabPageItem>

    <dxn:TabPageItem>
        <dxn:TabPageItem.Content>
            <ContentPage Title="People" IconImageSource="people">
                <Label Text="People Here" 
                        HorizontalOptions="Center" 
                        VerticalOptions="CenterAndExpand"/>
            </ContentPage>
        </dxn:TabPageItem.Content>
    </dxn:TabPageItem>
</dxn:TabPage>
```

Note that you can skip the **Items** property tags in the XAML markup as this property has a *ContentProperty* attribute.

## Customize the Tab Page Appearance

Move the header panel with tabs to the bottom of the page, set up tabs to fill all the available space in the header panel, and hide the selected item indicator:

```xaml
<dxn:TabPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:dxn="clr-namespace:DevExpress.Maui.Navigation;assembly=DevExpress.Maui.Navigation"
             xmlns:local="clr-namespace:TabPage_CreateItems"
             x:Class="TabPage_CreateItems.MainPage"
             HeaderPanelPosition="Bottom"
             ItemHeaderWidth="*"
             IsSelectedItemIndicatorVisible="False">
    <!-- Tab items here. -->
</dxn:TabPage>
```

Specify icon and text colors for tabs in the header panel. Use the **ItemHeaderIconColor** and **ItemHeaderTextColor** properties of the [TabPage](http://docs.devexpress.com/MAUI/DevExpress.Maui.Navigation.TabPage) object to specify the same colors for all tab items when they are not selected, and the **SelectedHeaderIconColor** and **SelectedHeaderTextColor** properties of [TabPageItem](http://docs.devexpress.com/MAUI/DevExpress.Maui.Navigation.TabPageItem) objects to set icon and text colors for individual tabs in the selected state:

```xaml
<dxn:TabPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:dxn="clr-namespace:DevExpress.Maui.Navigation;assembly=DevExpress.Maui.Navigation"
             xmlns:local="clr-namespace:TabPage_CreateItems"
             x:Class="TabPage_CreateItems.MainPage"
             HeaderPanelPosition="Bottom"
             ItemHeaderWidth="*"
             IsSelectedItemIndicatorVisible="False"
             ItemHeaderIconColor="#757575"
             ItemHeaderTextColor="#757575">
    <dxn:TabPage.Resources>
        <Color x:Key="mail_blue">#1e88e5</Color>
        <Color x:Key="calendar_green">#43a047</Color>
        <Color x:Key="people_red">#e53935</Color>
    </dxn:TabPage.Resources>
    <dxn:TabPageItem SelectedHeaderIconColor="{StaticResource mail_blue}"
                     SelectedHeaderTextColor="{StaticResource mail_blue}">
        <dxn:TabPageItem.Content>
            <ContentPage Title="Mail" IconImageSource="email">
                <Label Text="Mail List Here" 
                       HorizontalOptions="Center" 
                       VerticalOptions="CenterAndExpand"/>
            </ContentPage>
        </dxn:TabPageItem.Content>
    </dxn:TabPageItem>

    <dxn:TabPageItem SelectedHeaderIconColor="{StaticResource calendar_green}"
                     SelectedHeaderTextColor="{StaticResource calendar_green}">
        <dxn:TabPageItem.Content>
            <ContentPage Title="Calendar" IconImageSource="calendar">
                <Label Text="Calendar Here" 
                       HorizontalOptions="Center" 
                       VerticalOptions="CenterAndExpand"/>
            </ContentPage>
        </dxn:TabPageItem.Content>
    </dxn:TabPageItem>

    <dxn:TabPageItem SelectedHeaderIconColor="{StaticResource people_red}"
                     SelectedHeaderTextColor="{StaticResource people_red}">
        <dxn:TabPageItem.Content>
            <ContentPage Title="People" IconImageSource="people">
                <Label Text="People Here" 
                       HorizontalOptions="Center" 
                       VerticalOptions="CenterAndExpand"/>
            </ContentPage>
        </dxn:TabPageItem.Content>
    </dxn:TabPageItem>
</dxn:TabPage>
```
