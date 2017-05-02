using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using ZalandoShopSearch.Models;

namespace ZalandoShopSearch.Services
{
  public class ApiClient : IApiClientInterface
  {
    #region Fields

    const string baseUri = "https://api.zalando.com";

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

    public void SetGender(ApiGender gender)
    {
      var key = "gender";
      switch (gender)
      {
        case ApiGender.Male:
          uriParams[key] = "male";
          break;
        case ApiGender.Female:
          uriParams[key] = "female";
          break;
      }
    }

    public void SetPage(uint page)
    {
      var key = "page";
      if (page != 0)
      {
        uriParams[key] = page.ToString();
      }
      else
      {
        uriParams.Remove(key);
      }
    }

    public void SetPageSize(uint size)
    {
      var key = "pageSize";
      if (size != 0)
      {
        uriParams[key] = size.ToString();
      }
      else
      {
        uriParams.Remove(key);
      }
    }

    public void SetFullText(string text)
    {
      var key = "fullText";
      if (!string.IsNullOrWhiteSpace(text))
      {
        uriParams[key] = text;
      }
      else
      {
        uriParams.Remove(key);
      }
    }

    public async Task<IEnumerable<Facet>> GetFacetsAsync()
    {
      SetFullText(string.Empty);
      var resourceUri = generateUriParams("facets");

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
        throw;
      }
      catch (Exception ex)
      {
        throw;
      }

      return new List<Facet>();
    }

    public async Task<ItemsPage<Article>> GetArticlesAsync(uint page = 1, uint size = 30)
    {
      SetPage(page);
      SetPageSize(size);

      var resourceUri = generateUriParams("articles");

      try
      {
        var httpResponse = await httpClient.GetAsync(resourceUri).AsTask(cts.Token);

        if (httpResponse.IsSuccessStatusCode)
        {
          var content = await httpResponse.Content.ReadAsStringAsync();
          return JsonConvert.DeserializeObject<ItemsPage<Article>>(content);
        }
      }
      catch (TaskCanceledException)
      {

      }
      catch (Exception ex)
      {
        throw;
      }

      return new ItemsPage<Article>();
    }

    private Uri generateUriParams(string node)
    {
      var urlBuilder = new StringBuilder();
      urlBuilder.Append(baseUri).Append("/" + node + "?");

      foreach (var item in uriParams)
      {
        urlBuilder.Append(item.Key).Append("=").Append(item.Value).Append("&");
      }

      if (!Uri.TryCreate(urlBuilder.ToString(), UriKind.Absolute, out Uri resourceUri))
      {
        throw new Exception("TryCreate URI failed.");
      }

      return resourceUri;
    }

    #endregion Methods

    #region Enums

    #endregion Enums
  }

  public enum ApiGender
  {
    Male,
    Female
  }

}
