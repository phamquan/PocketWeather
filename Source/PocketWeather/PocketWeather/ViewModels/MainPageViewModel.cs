using Prism.Mvvm;
using Prism.Navigation;
using PocketWeather.Models;
using SquaredInfinity.Collections;
using Xamarin.Forms;

namespace PocketWeather.ViewModels
{
  public partial class MainPageViewModel : BindableBase, INavigationAware
  {

    #region CONSTRUCTORS

    public MainPageViewModel()
    {
      this.DailyWeathers = new ObservableCollectionEx<DailyWeather>();
    }

    #endregion

    public void OnNavigatedFrom(NavigationParameters parameters)
    {

    }

    public void OnNavigatedTo(NavigationParameters parameters)
    {
      Title = "Pocket Weather";
      HomeLand = "Saigon";
      BackgroundImageUrl = ImageSource.FromResource("PocketWeather.iOS.Assets.Background.bg_rain.jpg");

      this.DailyWeathers.AddRange(DailyWeather.Examples);

    }

    public void OnNavigatingTo(NavigationParameters parameters)
    {

    }
  }

  #region MainPageViewModel Properties

  public partial class MainPageViewModel
  {

    private string _title = string.Empty;
    public string Title
    {
      get
      {
        return _title;
      }
      set
      {
        SetProperty(ref _title, value);
      }
    }

    private string _homeLand = string.Empty;
    public string HomeLand
    {
      get
      {
        return _homeLand;
      }
      set
      {
        SetProperty(ref _homeLand, value);
      }
    }

    private ObservableCollectionEx<DailyWeather> _dailyWeathers = null;
    public ObservableCollectionEx<DailyWeather> DailyWeathers
    {
      get
      {
        return _dailyWeathers;
      }
      set
      {
        SetProperty(ref _dailyWeathers, value);
      }
    }

    private DailyWeather _selectedItem = null;
    public DailyWeather SelectedItem
    {
      get
      {
        return _selectedItem;
      }
      set
      {
        _selectedItem = value;

        if (_selectedItem == null)
          return;


        SetProperty(ref _selectedItem, null);
      }
    }

    private ImageSource _backgroundImageUrl = null;
    public ImageSource BackgroundImageUrl
    {
      get
      {
        return _backgroundImageUrl;
      }
      set
      {
        SetProperty(ref _backgroundImageUrl, value);
      }
    }

    #endregion
  }
}