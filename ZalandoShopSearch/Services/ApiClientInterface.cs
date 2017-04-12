using System.Collections.Generic;
using System.Threading.Tasks;
using ZalandoShopSearch.Models;

namespace ZalandoShopSearch.Services
{
  public interface IApiClientInterface
  {
    void SetGender(ApiGender gender);

    void SetFullText(string query);

    Task<IEnumerable<Facet>> GetFacetsAsync();

    Task<ArticlesPage> GetArticlesAsync(uint page = 1, uint size = 50);
  }
}
