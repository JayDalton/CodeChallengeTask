using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

      // The ItemCacheManager does most of the heavy lifting. We pass it a callback that it will use to actually fetch data, and the max size of a request
      itemCache = new ItemCacheManager<Article>();
      itemCache.CacheChanged += ItemCache_CacheChanged;
    }

    // Factory method to create the datasource
    public static async Task<ItemsRangeDataSource> GetDataSource(IApiClientInterface client)
    {
      var ds = new ItemsRangeDataSource(client);
      await ds.SetSource(50);
      return ds;
    }

    public async Task SetSource(uint pageSize)
    {
      var content = await apiClient.GetArticlesAsync(1, pageSize);
      _count = content.TotalElements;

      CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    private void ItemCache_CacheChanged(object sender, CacheChangedEventArgs<Article> args)
    {
      CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, args.oldItem, args.newItem, args.itemIndex));
    }

    // Callback from itemcache that it needs items to be retrieved
    // Using this callback model abstracts the details of this specific datasource from the cache implementation
    private async Task<Article[]> fetchDataCallback(ItemIndexRange batch, CancellationToken ct)
    {

      // Fetch file objects from filesystem
      IReadOnlyList<StorageFile> results = await _queryResult.GetFilesAsync((uint)batch.FirstIndex, Math.Max(batch.Length, 20)).AsTask(ct);
      //var content = await apiClient.GetArticlesAsync();
      List<Article> files = new List<Article>();
      if (results != null)
      {
        for (int i = 0; i < results.Count; i++)
        {
          // Check if request has been cancelled, if so abort getting additional data
          ct.ThrowIfCancellationRequested();
          // Create our FileItem object with the file data and thumbnail 
          FileItem newItem = await FileItem.fromStorageFile(results[i], ct);
          files.Add(newItem);
        }
      }
      return files.ToArray();
    }

    public object this[int index]
    {
      get { return itemCache[index]; }
      set => throw new NotImplementedException();
    }

    private int _count = 1;
    public int Count
    {
      get { return _count; }
    }

    public void RangesChanged(ItemIndexRange visibleRange, IReadOnlyList<ItemIndexRange> trackedItems)
    {
      var a = visibleRange.FirstIndex;
      var b = visibleRange.LastIndex;
      var n = visibleRange.Length;

      string s = string.Format("* RangesChanged fired: Visible {0}->{1}", visibleRange.FirstIndex, visibleRange.LastIndex);
      foreach (ItemIndexRange r in trackedItems) { s += string.Format(" {0}->{1}", r.FirstIndex, r.LastIndex); }
      Debug.WriteLine(s);
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
