using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZalandoShopSearch.Models;
using static ZalandoShopSearch.Services.ApiClient;

namespace ZalandoShopSearch.Services
{
  public interface IApiClientInterface
  {
    void SetGender(ApiGender gender);

    Task<IEnumerable<Facet>> GetFacetsAsync();

    Task<ArticlesPage> GetArticlesAsync(uint page = 1, uint size = 50);
  }
}
