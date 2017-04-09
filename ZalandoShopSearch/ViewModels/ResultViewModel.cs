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
      apiClient = new ApiClient();
      DataSource = new IncrementalDataSource(apiClient);
    }

    #region Properties

    public IncrementalDataSource DataSource { get; set; }

    #endregion Properties

    #region Methods


    #endregion Methods

  }
}
