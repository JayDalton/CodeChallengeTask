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

namespace ZalandoShopSearch.ViewModels
{
  public class SearchViewModel : NotificationBase
  {
    #region Fields

    const string baseUri = "https://api.zalando.com/facets";
    const string queryUri = "?gender=male&brandFamily=tommy h";

    private HttpClient httpClient;
    private CancellationTokenSource cts;
    private Uri apiUri;

    #endregion Fields

    public SearchViewModel(/*IApiClient client*/)
    {
      httpClient = new HttpClient();
      Items = new ObservableCollection<object>();
      apiUri = new Uri(string.Format(baseUri, queryUri));


      
      //string longurl = "http://somesite.com/news.php?article=1&lang=en";
      //var uriBuilder = new UriBuilder(longurl);
      //var query = HttpUtility.ParseQueryString(uriBuilder.Query);
      //query["action"] = "login1";
      //query["attempts"] = "11";
      //uriBuilder.Query = query.ToString();
      //longurl = uriBuilder.ToString();

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

      //Send the GET request
      var httpResponse = await httpClient.GetAsync(apiUri);
      if (httpResponse.IsSuccessStatusCode)
      {
        var content = await httpResponse.Content.ReadAsStringAsync();
        Facets = JsonConvert.DeserializeObject<IEnumerable<Facet>>(content);
      }
    }

    #endregion Methods
  }
}
