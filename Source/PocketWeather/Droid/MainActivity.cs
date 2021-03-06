﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PocketWeather.Droid
{
  [Activity(Label = "PocketWeather.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    protected override void OnCreate(Bundle bundle)
    {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(bundle);

      global::Xamarin.Forms.Forms.Init(this, bundle);
      FormsPlugin.Iconize.Droid.IconControls.Init(Resource.Id.toolbar);
      LoadApplication(new App());

      // IMPORTANT: Initialize XFGloss AFTER calling LoadApplication on the Android platform
      //XFGloss.Droid.Library.Init(this, bundle);
    }
  }
}
