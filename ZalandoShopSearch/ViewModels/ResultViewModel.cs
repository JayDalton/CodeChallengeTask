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
    }

    #region Properties

    public ObservableCollection<ArticleViewModel> Articles { get; set; } = new ObservableCollection<ArticleViewModel>();

    #endregion Properties

    #region Methods

    public async Task loadData()
    {
      var article = await apiClient.GetArticlesAsync();
      foreach (var item in article.Content)
      {
        Articles.Add(new ArticleViewModel(item));
      }
    }

    #endregion Methods

  }
}
