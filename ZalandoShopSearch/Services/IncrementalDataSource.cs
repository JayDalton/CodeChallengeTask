using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;
using ZalandoShopSearch.ViewModels;

namespace ZalandoShopSearch.Services
{
  public class IncrementalDataSource : IList, ISupportIncrementalLoading, INotifyCollectionChanged
  {
    #region Fields

    List<object> _storage = new List<object>();
    bool _busy = false;

    uint totalPages = 1;
    uint currentPage = 0;

    IApiClientInterface _apiClient;

    #endregion Fields

    public IncrementalDataSource(IApiClientInterface apiClient)
    {
      _apiClient = apiClient;
    }

    void NotifyOfInsertedItems(int baseIndex, int count)
    {
      if (CollectionChanged == null)
      {
        return;
      }

      for (int i = 0; i < count; i++)
      {
        var args = new NotifyCollectionChangedEventArgs(
          NotifyCollectionChangedAction.Add, 
          _storage[i + baseIndex], 
          i + baseIndex
        );
        CollectionChanged(this, args);
      }
    }


    #region ISupportIncrementalLoading

    public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
    {
      return AsyncInfo.Run(c => loadContentAsync());
    }

    private async Task<LoadMoreItemsResult> loadContentAsync()
    {
      var page = await _apiClient.GetArticlesAsync(currentPage + 1);
      totalPages = (uint)page.TotalPages;
      currentPage = (uint)page.Page;

      var baseIndex = _storage.Count;
      var itemsCount = page.Content.Count();

      _storage.AddRange(page.Content.Select(a => new ArticleViewModel(a)));

      // Now notify of the new items
      NotifyOfInsertedItems(baseIndex, itemsCount);

      return new LoadMoreItemsResult { Count = (uint)itemsCount };
    }

    public bool HasMoreItems
    {
      get { return currentPage < totalPages; }
    }

    #endregion ISupportIncrementalLoading

    #region INotifyCollectionChanged

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    #endregion INotifyCollectionChanged

    #region IList

    public object this[int index]
    {
      get
      {
        return _storage[index];
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public bool IsFixedSize
    {
      get { return false; }
    }

    public bool IsReadOnly
    {
      get { return true; }
    }

    public int Count
    {
      get { return _storage.Count; }
    }

    public bool IsSynchronized
    {
      get { return false; }
    }

    public object SyncRoot => throw new NotImplementedException();

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
      return _storage.Contains(value);
    }

    public void CopyTo(Array array, int index)
    {
      ((IList)_storage).CopyTo(array, index);
    }

    public IEnumerator GetEnumerator()
    {
      return _storage.GetEnumerator();
    }

    public int IndexOf(object value)
    {
      return _storage.IndexOf(value);
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

    #endregion IList


  }
}
