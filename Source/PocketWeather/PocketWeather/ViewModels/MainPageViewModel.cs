using Prism.Mvvm;
using Prism.Navigation;
using PocketWeather.Models;
using SquaredInfinity.Collections;
using Xamarin.Forms;
using System.Reflection;
using FormsPlugin.Iconize;
using System.Windows.Input;
using Prism.Commands;
using System;
using System.Linq;
using Prism.Services;
using PocketWeather.Api;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PocketWeather.ViewModels
{
  public partial class MainPageViewModel : BindableBase, INavigationAware
  {

    #region SERVICES
    private IPageDialogService _dialogService;
    #endregion

    #region CONSTRUCTORS

    public MainPageViewModel(IPageDialogService dialogService)
    {
      this.DailyWeathers = new ObservableCollectionEx<DailyWeather>();
      _dialogService = dialogService;
    }

    #endregion

    public void OnNavigatedFrom(NavigationParameters parameters)
    {

    }

    public void OnNavigatedTo(NavigationParameters parameters)
    {
      Title = "Pocket Weather";
      HomeLand = "Saigon";
      BackgroundImageUrl = ImageSource.FromResource(Assembly.GetExecutingAssembly().GetName().Name + ".Assets.Background.bg_rain.jpg");

      //this.DailyWeathers.AddRange(DailyWeather.Examples);


      LoadData();
    }

    public void OnNavigatingTo(NavigationParameters parameters)
    {

    }
  }

  #region COMMANDS
  public partial class MainPageViewModel
  {
    public ICommand RefreshCommand => new DelegateCommand(async () =>
    {
      await LoadData();
    });

    public ICommand MenuCommand => new DelegateCommand(() =>
    {
      _dialogService.DisplayAlertAsync("About", "This is DVLUP Final Project", "OK");
    });

    private async Task LoadData()
    {
      IsBusy = true;
      try
      {
        var result = await ApiService.GetCurrentWeather();
        CityName = result.name;
        WeatherDescription = $"{System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(result.weather[0].description)}. Wind: {result.wind.speed} m/s";
        Temperature = $"{result.main.temp.ToString()}°";
        WeatherIcon = ImageSource.FromUri(new Uri($"https://openweathermap.org/img/w/{result.weather[0].icon}.png"));

        var foreCastResult = await ApiService.GetForecastWeather();
        UpdateForecast(foreCastResult.list);

        ShowLatestMessage();
      }
      catch (Exception ex)
      {
        await _dialogService.DisplayAlertAsync("Error", ex.Message, "OK");
      }
      IsBusy = false;
    }


    private void ShowLatestMessage()
    {
      LastUpdateTime = DateTime.Now;
      Message = $"Updated {LastUpdateTime.ToString("MMMM dd, yyyy h:mm:ss tt")}";
    }

    private void UpdateForecast(IList<ListInfo> listInfo)
    {
      var l = listInfo.Select(_ => new DailyWeather
      {
        dt = _.dt,
        Temp = _.temp.day,
        TempMax = _.temp.max,
        TempMin = _.temp.min,
        Main = _.weather[0].main,
        WeatherIcon = $"https://openweathermap.org/img/w/{_.weather[0].icon}.png"
      });

      DailyWeathers.Clear();
      DailyWeathers.AddRange(l);
    }
  }
  #endregion

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

    private ImageSource _refreshImageSource = null;
    public ImageSource RefreshImageSource
    {
      get
      {
        return _refreshImageSource;
      }
      set
      {
        SetProperty(ref _refreshImageSource, value);
      }
    }

    private DateTime _lastUpdateTime;
    public DateTime LastUpdateTime
    {
      get
      {
        return _lastUpdateTime;
      }
      set
      {
        SetProperty(ref _lastUpdateTime, value);
      }
    }

    private String _message;
    public String Message
    {
      get
      {
        return _message;
      }
      set
      {
        SetProperty(ref _message, value);
      }
    }

    private String _cityName;
    public String CityName
    {
      get
      {
        return _cityName;
      }
      set
      {
        SetProperty(ref _cityName, value);
      }
    }

    private String _weatherDescription;
    public String WeatherDescription
    {
      get
      {
        return _weatherDescription;
      }
      set
      {
        SetProperty(ref _weatherDescription, value);
      }
    }

    private String _temperature;
    public String Temperature
    {
      get
      {
        return _temperature;
      }
      set
      {
        SetProperty(ref _temperature, value);
      }
    }

    private ImageSource _weatherIcon = null;
    public ImageSource WeatherIcon
    {
      get
      {
        return _weatherIcon;
      }
      set
      {
        SetProperty(ref _weatherIcon, value);
      }
    }

    private bool _isBusy = false;
    public bool IsBusy
    {
      get
      {
        return _isBusy;
      }
      set
      {
        SetProperty(ref _isBusy, value);
      }
    }


    #endregion
  }
}