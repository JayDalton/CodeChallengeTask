using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZalandoShopSearch.Models;

namespace ZalandoShopSearch.Services
{
  public interface IApiClient
  {
    Task<IEnumerable<Facet>> GetFacetsAsync(string gender);

    Task<IEnumerable<Article>> GetArticlesAsync();
  }
}
