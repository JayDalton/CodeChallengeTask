using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using ZalandoShopSearch.Models;

namespace ZalandoShopSearch.Services
{
  public class ItemsRangeDataSource : IList, INotifyCollectionChanged, IItemsRangeInfo
  {
    #region Fields

    IApiClientInterface apiClient;
    ItemCacheManager<Article> itemCache;

    #endregion Fields

    public bool IsFixedSize => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public bool IsSynchronized => throw new NotImplementedException();

    public object SyncRoot => throw new NotImplementedException();

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    public ItemsRangeDataSource(IApiClientInterface client)
    {
      apiClient = client;
      itemCache = new ItemCacheManager<Article>();
    }

    // Factory method to create the datasource
    public static async Task<ItemsRangeDataSource> GetDataSource()
    {
      return new ItemsRangeDataSource(null);
    }

    public object this[int index]
    {
      get { return itemCache[index]; }
      set => throw new NotImplementedException();
    }

    public int Count
    {
      get { return 1; }
    }

    public void RangesChanged(ItemIndexRange visibleRange, IReadOnlyList<ItemIndexRange> trackedItems)
    {
      var a = visibleRange.FirstIndex;
      var b = visibleRange.LastIndex;
      var n = visibleRange.Length;

      throw new NotImplementedException();
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public int Add(object value)
    {
      throw new NotImplementedException();
    }

    public void Clear()
    {
      throw new NotImplementedException();
    }

    public bool Contains(object value)
    {
      throw new NotImplementedException();
    }

    public int IndexOf(object value)
    {
      throw new NotImplementedException();
    }

    public void Insert(int index, object value)
    {
      throw new NotImplementedException();
    }

    public void Remove(object value)
    {
      throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
      throw new NotImplementedException();
    }

    public void CopyTo(Array array, int index)
    {
      throw new NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
      throw new NotImplementedException();
    }
  }
}
