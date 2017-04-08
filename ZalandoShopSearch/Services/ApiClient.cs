using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using ZalandoShopSearch.Models;

namespace ZalandoShopSearch.Services
{
  public class ApiClient : IApiClientInterface
  {
    #region Fields

    const string baseUri = "http://api.zalando.com";

    private HttpClient httpClient;
    private HttpBaseProtocolFilter filter;
    private CancellationTokenSource cts;

    #endregion Fields

    public ApiClient()
    {
      filter = new HttpBaseProtocolFilter();
      httpClient = new HttpClient(filter);
      cts = new CancellationTokenSource();
    }

    #region Properties

    public string BaseUri { get { return baseUri; } }

    #endregion Properties

    #region Methods

    public async Task<IEnumerable<Facet>> GetFacetsAsync(string gender = "male")
    {
      var urlBuilder = new StringBuilder();
      urlBuilder.Append(baseUri).Append("/facets?");
      urlBuilder.Append("gender=").Append(gender);

      if (!Uri.TryCreate(urlBuilder.ToString(), UriKind.Absolute, out Uri resourceUri))
      {
        throw new Exception("TryCreate URI failed.");
      }

      try
      {
        var httpResponse = await httpClient.GetAsync(resourceUri).AsTask(cts.Token);

        if (httpResponse.IsSuccessStatusCode)
        {
          var content = await httpResponse.Content.ReadAsStringAsync();
          return JsonConvert.DeserializeObject<IEnumerable<Facet>>(content);
        }
      }
      catch (TaskCanceledException)
      {

      }
      catch (Exception ex)
      {
        throw;
      }


      return new List<Facet>();
    }

    public async Task<IEnumerable<Article>> GetArticlesAsync()
    {
      var urlBuilder = new StringBuilder();
      urlBuilder.Append(baseUri).Append("/articles?");
      urlBuilder.Append("brand=").Append("T60");

      if (!Uri.TryCreate(urlBuilder.ToString(), UriKind.Absolute, out Uri resourceUri))
      {
        throw new Exception("TryCreate URI failed.");
      }

      try
      {
        var httpResponse = await httpClient.GetAsync(resourceUri).AsTask(cts.Token);

        if (httpResponse.IsSuccessStatusCode)
        {
          var content = await httpResponse.Content.ReadAsStringAsync();
          var xxx = JsonConvert.DeserializeObject<ArticlesPage>(content);

          var yyy = xxx.Size;
        }
      }
      catch (TaskCanceledException)
      {

      }
      catch (Exception ex)
      {
        throw;
      }

      return new List<Article>();
    }

    #endregion Methods
  }
}
