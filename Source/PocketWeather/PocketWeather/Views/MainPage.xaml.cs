using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XFGloss;

namespace PocketWeather.Views
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();

      NavigationPage.SetHasNavigationBar(this, false);
    }
  }
}
