using Prism.DryIoc;
using Xamarin.Forms;
using PocketWeather.Views;

namespace PocketWeather
{
  public partial class App
  {

    public App()
    {
      InitializeComponent();

      //MainPage = new PrismDemoPage();
    }

    protected App(IPlatformInitializer platformInitializer = null) : base(platformInitializer)
    {
    }

    protected override void OnInitialized()
    {
      NavigationService.NavigateAsync("Navigation/MainPage");
    }

    protected override void RegisterTypes()
    {
      Container.RegisterTypeForNavigation<NavigationPage>("Navigation");
      Container.RegisterTypeForNavigation<AboutPage>("AboutPage");
      Container.RegisterTypeForNavigation<MainPage>("MainPage");
    }
  }
}
