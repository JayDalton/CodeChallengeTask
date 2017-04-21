using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZalandoShopSearch.Models;

namespace ZalandoShopSearch.Services
{
  class ItemCacheManager<T>
  {
    List<ItemsPage<T>> cacheBlocks;

        public T this[int index]
        {
            get { return default(T); }
        }
  }
}
