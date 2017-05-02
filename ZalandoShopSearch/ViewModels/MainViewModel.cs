using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZalandoShopSearch.Models;
using ZalandoShopSearch.Services;

namespace ZalandoShopSearch.ViewModels
{
  public class MainViewModel : NotificationBase
  {
    #region Fields

    IApiClientInterface apiClient;

    #endregion Fields

    public MainViewModel()
    {

    }

    #region Properties

    public IApiClientInterface Client
    {
      get { return apiClient; }
    }

    private IEnumerable<Facet> _facets;
    public IEnumerable<Facet> Facets
    {
      get { return _facets ?? new List<Facet>(); }
      private set { SetProperty(ref _facets, value); }
    }

    private bool isMaleEnabled;
    public bool IsGenderMaleEnabled
    {
      get { return isMaleEnabled; }
      set { SetProperty(ref isMaleEnabled, value); }
    }

    private bool isFemaleEnabled;
    public bool IsGenderFemaleEnabled
    {
      get { return isFemaleEnabled; }
      set { SetProperty(ref isFemaleEnabled, value); }
    }

    #endregion Properties

    #region Methods

    public async Task SetGender()
    {

    }

    #endregion Methods
  }
}
