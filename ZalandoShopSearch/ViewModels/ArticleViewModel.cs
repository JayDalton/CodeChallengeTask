using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using ZalandoShopSearch.Models;

namespace ZalandoShopSearch.ViewModels
{
  public class ArticleViewModel : NotificationBase<Article>
  {
    public ArticleViewModel(Article article) : base(article)
    {
    }

    public string Name { get { return This.Name; } }

    public string Color { get { return This.Color; } }


    public string BrandName { get { return This.Brand.Name; } }

    public string Price { get { return This.Units[0].Price.Formatted; } }

    public string Size { get { return string.Format("Size: {0}", This.Units[0].Size); } }

    private BitmapImage _image;
    public BitmapImage Image
    {
      get
      {
        if (_image == null)
        {

          _image = new BitmapImage(new Uri(This.Media.Images[0].LargeHdUrl));
        }
        return _image;
      }
    }

  }
}
