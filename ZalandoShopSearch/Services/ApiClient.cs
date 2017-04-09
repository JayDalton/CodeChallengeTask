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

    private Dictionary<string, string> uriParams;

    private HttpClient httpClient;
    private HttpBaseProtocolFilter filter;
    private CancellationTokenSource cts;

    #endregion Fields

    public ApiClient()
    {
      uriParams = new Dictionary<string, string>();
      filter = new HttpBaseProtocolFilter();
      httpClient = new HttpClient(filter);
      cts = new CancellationTokenSource();

      httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
      httpClient.DefaultRequestHeaders.Add("Accept-Language", "de-DE");
      httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
    }

    #region Properties

    public string BaseUri { get { return baseUri; } }

    #endregion Properties

    #region Methods

    public void SetGender(GENDER gender)
    {
      switch (gender)
      {
        case GENDER.MALE:
          uriParams["gender"] = "male";
          break;
        case GENDER.FEMALE:
          uriParams["gender"] = "female";
          break;
      }
    }

    public async Task<IEnumerable<Facet>> GetFacetsAsync()
    {
      var urlBuilder = new StringBuilder();
      urlBuilder.Append(baseUri).Append("/facets?");
      foreach (var item in uriParams)
      {
        urlBuilder.Append(item.Key).Append("=").Append(item.Value).Append("&");
      }

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

    public async Task<ArticlesPage> GetArticlesAsync(uint page = 1, uint size = 30)
    {
      var urlBuilder = new StringBuilder();
      urlBuilder.Append(baseUri).Append("/articles?");
      urlBuilder.Append("page=").Append(page).Append("&");
      urlBuilder.Append("pageSize=").Append(size).Append("&");
      //urlBuilder.Append("brand=").Append("T60");

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
          return JsonConvert.DeserializeObject<ArticlesPage>(content);
        }
      }
      catch (TaskCanceledException)
      {

      }
      catch (Exception ex)
      {
        throw;
      }

      return new ArticlesPage();
    }

    #endregion Methods

    #region Enums

    public enum GENDER
    {
      MALE,
      FEMALE
    }

    #endregion Enums
  }
}
