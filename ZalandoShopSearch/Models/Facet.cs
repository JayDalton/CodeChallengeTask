using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZalandoShopSearch.Models
{
  public partial class Facet
  {
    [JsonProperty("filter", Required = Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Filter { get; set; }

    [JsonProperty("facets", Required = Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ObservableCollection<FacetValue> Facets { get; set; } = new ObservableCollection<FacetValue>();

    public string ToJson()
    {
      return JsonConvert.SerializeObject(this);
    }

    public static Facet FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<Facet>(data);
    }
  }

}
