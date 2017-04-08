using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
      Items = new ObservableCollection<object>();
    }

    #region Properties

    public ObservableCollection<object> Items { get; private set; }

    private IEnumerable<Facet> _facets;
    public IEnumerable<Facet> Facets
    {
      get { return _facets ?? new List<Facet>(); }
      private set { SetProperty(ref _facets, value); }
    }

    public bool IsDataLoaded { get; private set; }

    #endregion Properties

    #region Methods

    public async Task loadData()
    {

      Facets = await apiClient.GetFacetsAsync("male");

      var article = await apiClient.GetArticlesAsync();

    }

    #endregion Methods
  }
}
