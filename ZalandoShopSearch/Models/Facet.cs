using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZalandoShopSearch.Models
{
  //public class Facet
  //{
  //  public string Key { get; set; }
  //  public string DisplayName { get; set; }
  //  public uint Count { get; set; }
  //}

  //public class Entry
  //{
  //  public string Filter { get; set; }
  //  public IList<Facet> Facets { get; set; }
  //}


  /// <summary>Zalando API Facet Schema</summary>
  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.11.6284.26855")]
  public partial class Facet
  {
    [Newtonsoft.Json.JsonProperty("filter", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Filter { get; set; }

    /// <summary>list of the calculated article counts for each filter value</summary>
    [Newtonsoft.Json.JsonProperty("facets", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.ObjectModel.ObservableCollection<FacetValue> Facets { get; set; } = new System.Collections.ObjectModel.ObservableCollection<FacetValue>();

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static Facet FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<Facet>(data);
    }
  }

  /// <summary>Zalando API FacetValue Schema</summary>
  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.11.6284.26855")]
  public partial class FacetValue
  {
    [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Key { get; set; }

    [Newtonsoft.Json.JsonProperty("displayName", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string DisplayName { get; set; }

    /// <summary>number of articles matching this filter value</summary>
    [Newtonsoft.Json.JsonProperty("count", Required = Newtonsoft.Json.Required.Always)]
    public int Count { get; set; }

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static FacetValue FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<FacetValue>(data);
    }

    public override string ToString()
    {
      return this.DisplayName;
    }
  }
}
