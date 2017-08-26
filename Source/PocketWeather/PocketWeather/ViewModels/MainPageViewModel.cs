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
using Prism.Services;

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

      var icn = new IconImage();
      icn.Icon = "fa-refresh";
      icn.IconColor = Color.White;
      icn.IconSize = 15;

      RefreshImageSource = icn.Source;

      this.DailyWeathers.AddRange(DailyWeather.Examples);

    }

    public void OnNavigatingTo(NavigationParameters parameters)
    {

    }
  }

  #region COMMANDS
  public partial class MainPageViewModel
  {
    public ICommand RefreshCommand => new DelegateCommand(() =>
    {
      LastUpdateTime = DateTime.Now;
      Message = $"Updated {LastUpdateTime.ToString("MMMM dd, yyyy h:mm:ss tt")}";
    });

    public ICommand MenuCommand => new DelegateCommand(() =>
    {
      _dialogService.DisplayAlertAsync("About", "This is DVLUP Final Project", "OK");
    });


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


    #endregion
  }
}