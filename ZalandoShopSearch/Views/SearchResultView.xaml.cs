using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ZalandoShopSearch.Services;
using ZalandoShopSearch.ViewModels;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace ZalandoShopSearch.Views
{
  /// <summary>
  /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
  /// </summary>
  public sealed partial class SearchResultView : Page
  {
    ResultViewModel ViewModel { get; set; }

    public SearchResultView()
    {
      this.InitializeComponent();
      this.ViewModel = new ResultViewModel();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);
      var client = e.Parameter as IApiClientInterface;
      ViewModel.SetApiClient(client);

      Frame rootFrame = Window.Current.Content as Frame;

      if (rootFrame.CanGoBack)
      {
        // If we have pages in our in-app backstack and have opted in to showing back, do so
        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
      }
      else
      {
        // Remove the UI from the title bar if there are no pages in our in-app back stack
        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
      }
    }
  }
}
