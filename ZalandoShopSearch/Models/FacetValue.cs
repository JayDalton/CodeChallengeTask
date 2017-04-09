using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZalandoShopSearch.Models
{
  public partial class FacetValue
  {
    [JsonProperty("key", Required = Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Key { get; set; }

    [JsonProperty("displayName", Required = Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string DisplayName { get; set; }

    /// <summary>number of articles matching this filter value</summary>
    [JsonProperty("count", Required = Required.Always)]
    public int Count { get; set; }

    public string ToJson()
    {
      return JsonConvert.SerializeObject(this);
    }

    public static FacetValue FromJson(string data)
    {
      return JsonConvert.DeserializeObject<FacetValue>(data);
    }

    public override string ToString()
    {
      return string.Format("{0} ({1})", DisplayName, Key);
    }
  }
}
