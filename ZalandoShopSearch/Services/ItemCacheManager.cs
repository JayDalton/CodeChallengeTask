using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;
using ZalandoShopSearch.Models;

namespace ZalandoShopSearch.Services
{
  // EventArgs class for the CacheChanged event 
  public class CacheChangedEventArgs<T> : EventArgs
  {
    public T oldItem { get; set; }
    public T newItem { get; set; }
    public int itemIndex { get; set; }
  }

  class ItemCacheManager<T>
  {
    Dictionary<uint, T> cacheItems;
    List<ItemsPage<T>> cacheBlocks;
    private Windows.UI.Xaml.DispatcherTimer timer;

    public ItemCacheManager()
    {
      cacheItems = new Dictionary<uint, T>();
      timer = new Windows.UI.Xaml.DispatcherTimer();
      timer.Tick += (sender, args) =>
      {
        Debug.WriteLine("Hello World!");
      };
      timer.Interval = new TimeSpan(20 * 10000);
    }

    public T this[uint index]
    {
      get
      {
        if (cacheItems.TryGetValue(index, out T value))
        {
          return value;
        }
        return default(T);
      }
      set
      {
        cacheItems[index] = value;
      }
    }

    public event TypedEventHandler<object, CacheChangedEventArgs<T>> CacheChanged;

    public void UpdateRanges(ItemIndexRange[] ranges)
    {

    }
  }
}
