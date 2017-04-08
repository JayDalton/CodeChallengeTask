using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZalandoShopSearch.Models;

namespace ZalandoShopSearch.Services
{
  public interface IApiClientInterface
  {
    Task<IEnumerable<Facet>> GetFacetsAsync(string gender);

    Task<ArticlesPage> GetArticlesAsync();
  }
}
