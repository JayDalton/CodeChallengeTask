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

    public SearchViewModel(/*IApiClient client*/)
    {
      apiClient = new ApiClient();
      SetGenderToFemale();
    }

    #region Properties

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

    public async Task LoadFacetsForSuggestion()
    {
      Facets = await apiClient.GetFacetsAsync();
    }

    public void SetGenderToMale()
    {
      IsGenderMaleEnabled = false;
      IsGenderFemaleEnabled = true;
      apiClient.SetGender(ApiClient.GENDER.MALE);
    }

    public void SetGenderToFemale()
    {
      IsGenderMaleEnabled = true;
      IsGenderFemaleEnabled = false;
      apiClient.SetGender(ApiClient.GENDER.FEMALE);
    }

    #endregion Methods
  }
}
