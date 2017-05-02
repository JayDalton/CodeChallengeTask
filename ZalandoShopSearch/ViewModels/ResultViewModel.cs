using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZalandoShopSearch.Models;
using ZalandoShopSearch.Services;

namespace ZalandoShopSearch.ViewModels
{
  public class ResultViewModel : NotificationBase
  {
    #region Fields

    IApiClientInterface apiClient;

    #endregion Fields

    public ResultViewModel()
    {
    }

    #region Properties

    //public IncrementalDataSource DataSource { get; set; }

    public ItemsRangeDataSource DataSource { get; set; }

    #endregion Properties

    #region Methods

    public async Task SetApiClient(IApiClientInterface client)
    {
      apiClient = client;
      //DataSource = new IncrementalDataSource(apiClient);
      var ds = await ItemsRangeDataSource.GetDataSource(client);
      DataSource = ds;
    }

    #endregion Methods

  }
}
