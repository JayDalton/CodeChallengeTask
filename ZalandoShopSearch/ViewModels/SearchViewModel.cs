using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using ZalandoShopSearch.Models;
using ZalandoShopSearch.Services;

namespace ZalandoShopSearch.ViewModels
{
  public class SearchViewModel : NotificationBase
  {
    #region Fields

    IApiClientInterface apiClient;

    #endregion Fields

    public SearchViewModel()
    {
    }

    #region Properties

    public IApiClientInterface Client
    {
      get { return apiClient; }
    }

    private IEnumerable<Facet> _facets;
    public IEnumerable<Facet> Facets
    {
      get { return _facets ?? new List<Facet>(); }
      private set { SetProperty(ref _facets, value); }
    }

    private bool isMaleEnabled;
    public bool IsGenderMaleEnabled
    {
      get { return isMaleEnabled; }
      set { SetProperty(ref isMaleEnabled, value); }
    }

    private bool isFemaleEnabled;
    public bool IsGenderFemaleEnabled
    {
      get { return isFemaleEnabled; }
      set { SetProperty(ref isFemaleEnabled, value); }
    }

    #endregion Properties

    #region Methods

    public void SetApiClient(IApiClientInterface client)
    {
      apiClient = client;
    }

    public async Task LoadFacetsForSuggestion()
    {
      Facets = await apiClient?.GetFacetsAsync();
    }

    public async Task SetGenderToMale()
    {
      IsGenderMaleEnabled = false;
      IsGenderFemaleEnabled = true;
      apiClient.SetGender(ApiGender.Male);
      await LoadFacetsForSuggestion();
    }

    public async Task SetGenderToFemale()
    {
      IsGenderMaleEnabled = true;
      IsGenderFemaleEnabled = false;
      apiClient.SetGender(ApiGender.Female);
      await LoadFacetsForSuggestion();
    }

    public void SetQueryText(string query)
    {
      apiClient.SetFullText(query);
    }

    #endregion Methods
  }
}
