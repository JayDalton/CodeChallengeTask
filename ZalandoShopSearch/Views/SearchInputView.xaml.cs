using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace ZalandoShopSearch.Views
{
  /// <summary>
  /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
  /// </summary>
  public sealed partial class SearchInputView : Page
  {
    public SearchInputView()
    {
      this.InitializeComponent();
    }

    private void SearchArticleBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
      if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
      {
        //var suggestions = SearchPersons(sender.Text);
        //if (0 < suggestions.Count)
        //{
        //  sender.ItemsSource = suggestions;
        //}
        //else
        //{
        //  sender.ItemsSource = new string[] { "Keine Ergebnisse" };
        //}
      }
    }

    private void SearchArticleBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
      //if (args.ChosenSuggestion != null && args.ChosenSuggestion is PersonGroup)
      //{
      //  //User selected an item, take an action
      //  SelectPerson(args.ChosenSuggestion as Person);
      //}
      //else if (!string.IsNullOrEmpty(args.QueryText))
      //{
      //  //Do a fuzzy search based on the text
      //  var suggestions = SearchPersons(sender.Text);
      //  if (0 < suggestions.Count)
      //  {
      //    SelectPerson(suggestions.FirstOrDefault());
      //  }
      //}
    }

    private void SearchArticleBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
      //var person = args.SelectedItem as Person;

      ////Don't autocomplete the TextBox when we are showing "no results"
      //if (person != null)
      //{
      //  sender.Text = person.FormName;
      //}
    }

    //private List<Person> SearchPersons(string query)
    //{
    //  var groups = ViewModel.GroupedPersons;
    //  var suggestions = new List<Person>();

    //  foreach (var group in groups)
    //  {
    //    var matchingItems = group.Where(p => p.Name.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) >= 0);
    //    foreach (var item in matchingItems)
    //    {
    //      suggestions.Add(item);
    //    }
    //  }

    //  return suggestions
    //    .OrderByDescending(i => i.FormName.StartsWith(query, StringComparison.CurrentCultureIgnoreCase))
    //    .ThenBy(i => i.FormName)
    //    .ToList();
    //}
  }
}
