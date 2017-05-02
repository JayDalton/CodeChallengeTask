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
using ZalandoShopSearch.Models;
using ZalandoShopSearch.ViewModels;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace ZalandoShopSearch
{
  /// <summary>
  /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    MainViewModel ViewModel { get; set; }

    public MainPage()
    {
      this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);

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

    private async void GenderButton_Click(object sender, RoutedEventArgs e)
    {
      if (sender is Button)
      {
        Button btn = sender as Button;
        string gender = btn.Tag.ToString();
        switch (gender)
        {
          case "Male":
            await ViewModel.SetGender();
            break;
          case "Female":
            await ViewModel.SetGender();
            break;
        }
        SearchArticleBox.Text = string.Empty;
        SearchArticleBox.Text = string.Empty;
        SearchArticleBox.Focus(FocusState.Programmatic);
      }
    }

    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {
    }

    private void SearchArticleBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
      if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
      {
        var suggestions = SearchFacetValue(sender.Text);
        if (0 < suggestions.Count)
        {
          sender.ItemsSource = suggestions;
        }
        else
        {
          sender.ItemsSource = new string[] { "Keine Ergebnisse" };
        }
      }
    }

    private void SearchArticleBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
      if (args.ChosenSuggestion != null && args.ChosenSuggestion is FacetValue)
      {
        //User selected an item, take an action
        var facetValue = args.ChosenSuggestion as FacetValue;
      }
      else
      {
      }
    }

    private void SearchArticleBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
      if (args.SelectedItem is FacetValue)
      {
        var facet = args.SelectedItem as FacetValue;
        sender.Text = facet.DisplayName;
      }
    }

    private List<FacetValue> SearchFacetValue(string query)
    {
      var facets = ViewModel.Facets;
      var suggestions = new List<FacetValue>();

      foreach (var facet in ViewModel.Facets)
      {
        var matchingItems = facet.Facets.Where(p => p.DisplayName.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) >= 0);
        foreach (var item in matchingItems)
        {
          suggestions.Add(item);
        }
      }

      return suggestions
        .OrderByDescending(i => i.DisplayName.StartsWith(query, StringComparison.CurrentCultureIgnoreCase))
        .ThenBy(i => i.DisplayName)
        .ToList();
    }

  }
}
