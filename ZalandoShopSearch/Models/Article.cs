using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZalandoShopSearch.Models
{
  public partial class ArticlesPage
  {
    /// <summary>content elements in the response</summary>
    [JsonProperty("content", Required = Required.Always)]
    public IEnumerable<Article> Content { get; set; }

    /// <summary>total elements in the response</summary>
    [JsonProperty("totalElements", Required = Required.Always)]
    public int TotalElements { get; set; }

    /// <summary>total number of pages in the response</summary>
    [JsonProperty("totalPages", Required = Required.Always)]
    public int TotalPages { get; set; }

    /// <summary>page number</summary>
    [JsonProperty("page", Required = Required.Always)]
    public int Page { get; set; }

    /// <summary>total number of elements in a page</summary>
    [JsonProperty("size", Required = Required.Always)]
    public int Size { get; set; }

    public string ToJson()
    {
      return JsonConvert.SerializeObject(this);
    }

    public static ArticlesPage FromJson(string data)
    {
      return JsonConvert.DeserializeObject<ArticlesPage>(data);
    }
  }


  /// <summary>Zalando API Article Schema</summary>
  public partial class Article
  {
    /// <summary>unique article id</summary>
    [JsonProperty("id", Required = Required.Always)]
    public string Id { get; set; }

    /// <summary>unique article model id</summary>
    [JsonProperty("modelId", Required = Required.Always)]
    public string ModelId { get; set; }

    /// <summary>article name</summary>
    [JsonProperty("name", Required = Required.Always)]
    public string Name { get; set; }

    /// <summary>url of the article within the Zalando webshop</summary>
    [JsonProperty("shopUrl", Required = Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string ShopUrl { get; set; }

    /// <summary>the main color of the article</summary>
    [Newtonsoft.Json.JsonProperty("color", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Color { get; set; }

    /// <summary>will be true if at least one article unit is available</summary>
    [Newtonsoft.Json.JsonProperty("available", Required = Newtonsoft.Json.Required.Always)]
    public bool Available { get; set; }

    /// <summary>collection season the article belongs to</summary>
    [Newtonsoft.Json.JsonProperty("season", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ArticleSeason Season { get; set; }

    /// <summary>collection year the article belongs to. Could be either a year or 'ALL'</summary>
    [Newtonsoft.Json.JsonProperty("seasonYear", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.RegularExpression(@"^ALL$|^20[0-9]{2}$")]
    public string SeasonYear { get; set; }

    /// <summary>timestamp the article was available in the Zalando webshop</summary>
    [Newtonsoft.Json.JsonProperty("activationDate", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.DateTime ActivationDate { get; set; }

    /// <summary>any additional information of the article </summary>
    [Newtonsoft.Json.JsonProperty("additionalInfos", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.ObjectModel.ObservableCollection<string> AdditionalInfos { get; set; } = new System.Collections.ObjectModel.ObservableCollection<string>();

    /// <summary>gender of the article belongs to</summary>
    [Newtonsoft.Json.JsonProperty("genders", Required = Newtonsoft.Json.Required.Always, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.ObjectModel.ObservableCollection<Anonymous25> Genders { get; set; } = new System.Collections.ObjectModel.ObservableCollection<Anonymous25>();

    /// <summary>age group of the article belongs to</summary>
    [Newtonsoft.Json.JsonProperty("ageGroups", Required = Newtonsoft.Json.Required.Always, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.ObjectModel.ObservableCollection<Anonymous26> AgeGroups { get; set; } = new System.Collections.ObjectModel.ObservableCollection<Anonymous26>();

    [Newtonsoft.Json.JsonProperty("brand", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Brand Brand { get; set; } = new Brand();

    /// <summary>category keys of the article belongs to</summary>
    [Newtonsoft.Json.JsonProperty("categoryKeys", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.ObjectModel.ObservableCollection<string> CategoryKeys { get; set; } = new System.Collections.ObjectModel.ObservableCollection<string>();

    /// <summary>article attributes</summary>
    [Newtonsoft.Json.JsonProperty("attributes", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.ObjectModel.ObservableCollection<ArticleAttribute> Attributes { get; set; } = new System.Collections.ObjectModel.ObservableCollection<ArticleAttribute>();

    /// <summary>price of the article</summary>
    [Newtonsoft.Json.JsonProperty("units", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.ObjectModel.ObservableCollection<ArticleUnit> Units { get; set; } = new System.Collections.ObjectModel.ObservableCollection<ArticleUnit>();

    [Newtonsoft.Json.JsonProperty("tags", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.ObjectModel.ObservableCollection<string> Tags { get; set; }

    [Newtonsoft.Json.JsonProperty("media", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ArticleMedia Media { get; set; } = new ArticleMedia();

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static Article FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<Article>(data);
    }
  }

  public partial class Brand
  {
    /// <summary>The unique key for a brand</summary>
    [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Key { get; set; }

    /// <summary>Name of the brand</summary>
    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Name { get; set; }

    /// <summary>The url of the brand within the Zalando web shop</summary>
    [Newtonsoft.Json.JsonProperty("shopUrl", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string ShopUrl { get; set; }

    /// <summary>The url of the brand logo within the Zalando web shop</summary>
    [Newtonsoft.Json.JsonProperty("logoUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string LogoUrl { get; set; }

    /// <summary>The url of the large brand logo within the Zalando web shop</summary>
    [Newtonsoft.Json.JsonProperty("logoLargeUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string LogoLargeUrl { get; set; }

    [Newtonsoft.Json.JsonProperty("brandFamily", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public BrandFamily BrandFamily { get; set; }

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static Brand FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<Brand>(data);
    }
  }

  /// <summary>Zalando API Article Attribute Schema</summary>
  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.11.6284.26855")]
  public partial class ArticleAttribute
  {
    /// <summary>name of the article attribute</summary>
    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Name { get; set; }

    /// <summary>value of the article attribute</summary>
    [Newtonsoft.Json.JsonProperty("values", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.ObjectModel.ObservableCollection<string> Values { get; set; } = new System.Collections.ObjectModel.ObservableCollection<string>();

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static ArticleAttribute FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<ArticleAttribute>(data);
    }
  }

  /// <summary>Zalando API Article Image Schema</summary>
  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.11.6284.26855")]
  public partial class ArticleImage
  {
    /// <summary>sequence of the article images</summary>
    [Newtonsoft.Json.JsonProperty("orderNumber", Required = Newtonsoft.Json.Required.Always)]
    public int OrderNumber { get; set; }

    /// <summary>model or non model type article images</summary>
    [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Type { get; set; }

    /// <summary>thumbnail HD url of the article images</summary>
    [Newtonsoft.Json.JsonProperty("thumbnailHdUrl", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string ThumbnailHdUrl { get; set; }

    /// <summary>small image of the article</summary>
    [Newtonsoft.Json.JsonProperty("smallUrl", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string SmallUrl { get; set; }

    /// <summary>small HD image of the article</summary>
    [Newtonsoft.Json.JsonProperty("smallHdUrl", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string SmallHdUrl { get; set; }

    /// <summary>medium image of the article</summary>
    [Newtonsoft.Json.JsonProperty("mediumUrl", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string MediumUrl { get; set; }

    /// <summary>medium HD image of the article</summary>
    [Newtonsoft.Json.JsonProperty("mediumHdUrl", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string MediumHdUrl { get; set; }

    /// <summary>large image of the article</summary>
    [Newtonsoft.Json.JsonProperty("largeUrl", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string LargeUrl { get; set; }

    /// <summary>large HD image of the article</summary>
    [Newtonsoft.Json.JsonProperty("largeHdUrl", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string LargeHdUrl { get; set; }

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static ArticleImage FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<ArticleImage>(data);
    }
  }

  /// <summary>Zalando API Article Media Schema</summary>
  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.11.6284.26855")]
  public partial class ArticleMedia
  {
    [Newtonsoft.Json.JsonProperty("images", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.ObjectModel.ObservableCollection<ArticleImage> Images { get; set; } = new System.Collections.ObjectModel.ObservableCollection<ArticleImage>();

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static ArticleMedia FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<ArticleMedia>(data);
    }
  }

  /// <summary>Zalando API Article Price Schema</summary>
  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.11.6284.26855")]
  public partial class ArticlePrice
  {
    [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Currency { get; set; }

    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Always)]
    public double Value { get; set; }

    [Newtonsoft.Json.JsonProperty("formatted", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Formatted { get; set; }

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static ArticlePrice FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<ArticlePrice>(data);
    }
  }

  /// <summary>Zalando API Article Review Schema</summary>
  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.11.6284.26855")]
  public partial class ArticleReview
  {
    /// <summary>unique article review id</summary>
    [Newtonsoft.Json.JsonProperty("reviewId", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string ReviewId { get; set; }

    [Newtonsoft.Json.JsonProperty("articleId", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string ArticleId { get; set; }

    [Newtonsoft.Json.JsonProperty("articleModelId", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string ArticleModelId { get; set; }

    /// <summary>Customer short name in the article review</summary>
    [Newtonsoft.Json.JsonProperty("customerNickname", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string CustomerNickname { get; set; }

    /// <summary>customer city in the article review</summary>
    [Newtonsoft.Json.JsonProperty("customerCity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string CustomerCity { get; set; }

    /// <summary>customer country in the article review</summary>
    [Newtonsoft.Json.JsonProperty("customerCountry", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string CustomerCountry { get; set; }

    /// <summary>language in the article review</summary>
    [Newtonsoft.Json.JsonProperty("language", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Language { get; set; }

    /// <summary>title in the article review</summary>
    [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Title { get; set; }

    /// <summary>description of the article review</summary>
    [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Description { get; set; }

    /// <summary>article review created date and time</summary>
    [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.DateTime Created { get; set; }

    /// <summary>customer rating of the article</summary>
    [Newtonsoft.Json.JsonProperty("rating", Required = Newtonsoft.Json.Required.Always)]
    public int Rating { get; set; }

    /// <summary>customer recommend to the article</summary>
    [Newtonsoft.Json.JsonProperty("recommend", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool? Recommend { get; set; }

    /// <summary>customer review helpful count of the article</summary>
    [Newtonsoft.Json.JsonProperty("helpfulCount", Required = Newtonsoft.Json.Required.Always)]
    public int HelpfulCount { get; set; }

    /// <summary>customer review unhelpful count of the article</summary>
    [Newtonsoft.Json.JsonProperty("unhelpfulCount", Required = Newtonsoft.Json.Required.Always)]
    public int UnhelpfulCount { get; set; }

    [Newtonsoft.Json.JsonProperty("articleSizeRatings", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ArticleSizeRatings ArticleSizeRatings { get; set; }

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static ArticleReview FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<ArticleReview>(data);
    }
  }

  /// <summary>Zalando API Article Reviews Summary Schema</summary>
  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.11.6284.26855")]
  public partial class ArticleReviewsSummary
  {
    [Newtonsoft.Json.JsonProperty("articleModelId", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string ArticleModelId { get; set; }

    /// <summary>average star rating of the article</summary>
    [Newtonsoft.Json.JsonProperty("averageStarRating", Required = Newtonsoft.Json.Required.Always)]
    public double AverageStarRating { get; set; }

    /// <summary>number of user reviews of the article</summary>
    [Newtonsoft.Json.JsonProperty("numberOfUserReviews", Required = Newtonsoft.Json.Required.Always)]
    public int NumberOfUserReviews { get; set; }

    /// <summary>number of users recommended to the article</summary>
    [Newtonsoft.Json.JsonProperty("numberOfUserRecommendations", Required = Newtonsoft.Json.Required.Always)]
    public int NumberOfUserRecommendations { get; set; }

    /// <summary>number of positive recommendations to the article</summary>
    [Newtonsoft.Json.JsonProperty("numberOfUserPositiveRecommendations", Required = Newtonsoft.Json.Required.Always)]
    public int NumberOfUserPositiveRecommendations { get; set; }

    /// <summary>start rating distribution of the article</summary>
    [Newtonsoft.Json.JsonProperty("starRatingDistribution", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public StarRatingDistribution StarRatingDistribution { get; set; } = new StarRatingDistribution();

    /// <summary>size rating of the article</summary>
    [Newtonsoft.Json.JsonProperty("articleSizeRatings", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ArticleSizeRatings2 ArticleSizeRatings { get; set; }

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static ArticleReviewsSummary FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<ArticleReviewsSummary>(data);
    }
  }

  public partial class ArticleSizeRatings2
  {
    [Newtonsoft.Json.JsonProperty("OVERALL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double? OVERALL { get; set; }

    [Newtonsoft.Json.JsonProperty("CHEST", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double? CHEST { get; set; }

    [Newtonsoft.Json.JsonProperty("SLEEVES", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double? SLEEVES { get; set; }

    [Newtonsoft.Json.JsonProperty("SHOULDERS", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double? SHOULDERS { get; set; }

    [Newtonsoft.Json.JsonProperty("LENGTH", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double? LENGTH { get; set; }

    [Newtonsoft.Json.JsonProperty("LEG_FIT", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double? LEG_FIT { get; set; }

    [Newtonsoft.Json.JsonProperty("SHOE_WIDTH", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double? SHOE_WIDTH { get; set; }

    [Newtonsoft.Json.JsonProperty("BOOTLEG_WIDTH", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double? BOOTLEG_WIDTH { get; set; }

    [Newtonsoft.Json.JsonProperty("HIPS_OR_REAR", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double? HIPS_OR_REAR { get; set; }

    [Newtonsoft.Json.JsonProperty("CUP_SIZE", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double? CUP_SIZE { get; set; }

    [Newtonsoft.Json.JsonProperty("CHEST_GIRTH", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double? CHEST_GIRTH { get; set; }

    [Newtonsoft.Json.JsonProperty("COLLAR_SIZE", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double? COLLAR_SIZE { get; set; }

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static ArticleSizeRatings2 FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<ArticleSizeRatings2>(data);
    }
  }

  public partial class StarRatingDistribution
  {
    [Newtonsoft.Json.JsonProperty("1", Required = Newtonsoft.Json.Required.Always)]
    public int _1 { get; set; }

    [Newtonsoft.Json.JsonProperty("2", Required = Newtonsoft.Json.Required.Always)]
    public int _2 { get; set; }

    [Newtonsoft.Json.JsonProperty("3", Required = Newtonsoft.Json.Required.Always)]
    public int _3 { get; set; }

    [Newtonsoft.Json.JsonProperty("4", Required = Newtonsoft.Json.Required.Always)]
    public int _4 { get; set; }

    [Newtonsoft.Json.JsonProperty("5", Required = Newtonsoft.Json.Required.Always)]
    public int _5 { get; set; }

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static StarRatingDistribution FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<StarRatingDistribution>(data);
    }
  }

  /// <summary>Zalando API Article Unit Schema</summary>
  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.11.6284.26855")]
  public partial class ArticleUnit
  {
    /// <summary>article id (sku)</summary>
    [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Id { get; set; }

    /// <summary>article size</summary>
    [Newtonsoft.Json.JsonProperty("size", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Size { get; set; }

    [Newtonsoft.Json.JsonProperty("price", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ArticlePrice Price { get; set; } = new ArticlePrice();

    [Newtonsoft.Json.JsonProperty("originalPrice", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ArticlePrice OriginalPrice { get; set; } = new ArticlePrice();

    /// <summary>availability of the article</summary>
    [Newtonsoft.Json.JsonProperty("available", Required = Newtonsoft.Json.Required.Always)]
    public bool Available { get; set; }

    /// <summary>stock of the article</summary>
    [Newtonsoft.Json.JsonProperty("stock", Required = Newtonsoft.Json.Required.Always)]
    public int Stock { get; set; }

    /// <summary>partner id (vendor id) of the article</summary>
    [Newtonsoft.Json.JsonProperty("partnerId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string PartnerId { get; set; }

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static ArticleUnit FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<ArticleUnit>(data);
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.11.6284.26855")]
  public partial class ArticleSizeRatings
  {
    [Newtonsoft.Json.JsonProperty("OVERALL", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int? OVERALL { get; set; }

    [Newtonsoft.Json.JsonProperty("CHEST", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int? CHEST { get; set; }

    [Newtonsoft.Json.JsonProperty("SLEEVES", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int? SLEEVES { get; set; }

    [Newtonsoft.Json.JsonProperty("SHOULDERS", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int? SHOULDERS { get; set; }

    [Newtonsoft.Json.JsonProperty("LENGTH", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int? LENGTH { get; set; }

    [Newtonsoft.Json.JsonProperty("LEG_FIT", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int? LEG_FIT { get; set; }

    [Newtonsoft.Json.JsonProperty("SHOE_WIDTH", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int? SHOE_WIDTH { get; set; }

    [Newtonsoft.Json.JsonProperty("BOOTLEG_WIDTH", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int? BOOTLEG_WIDTH { get; set; }

    [Newtonsoft.Json.JsonProperty("HIPS_OR_REAR", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int? HIPS_OR_REAR { get; set; }

    [Newtonsoft.Json.JsonProperty("CUP_SIZE", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int? CUP_SIZE { get; set; }

    [Newtonsoft.Json.JsonProperty("CHEST_GIRTH", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int? CHEST_GIRTH { get; set; }

    [Newtonsoft.Json.JsonProperty("COLLAR_SIZE", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int? COLLAR_SIZE { get; set; }

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static ArticleSizeRatings FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<ArticleSizeRatings>(data);
    }
  }

  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.11.6284.26855")]
  public enum ArticleSeason
  {
    [System.Runtime.Serialization.EnumMember(Value = "SUMMER")]
    SUMMER = 0,

    [System.Runtime.Serialization.EnumMember(Value = "WINTER")]
    WINTER = 1,

    [System.Runtime.Serialization.EnumMember(Value = "ALL")]
    ALL = 2,

  }

  public partial class BrandFamily
  {
    /// <summary>The unique key for a brandFamily</summary>
    [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Key { get; set; }

    /// <summary>Name of the brandFamily</summary>
    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Name { get; set; }

    /// <summary>The url of the brandFamily within the Zalando web shop</summary>
    [Newtonsoft.Json.JsonProperty("shopUrl", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string ShopUrl { get; set; }

    public string ToJson()
    {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }

    public static BrandFamily FromJson(string data)
    {
      return Newtonsoft.Json.JsonConvert.DeserializeObject<BrandFamily>(data);
    }
  }

  public enum Anonymous25
  {
    [System.Runtime.Serialization.EnumMember(Value = "MALE")]
    MALE = 0,

    [System.Runtime.Serialization.EnumMember(Value = "FEMALE")]
    FEMALE = 1,

  }

  [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "8.11.6284.26855")]
  public enum Anonymous26
  {
    [System.Runtime.Serialization.EnumMember(Value = "BABY")]
    BABY = 0,

    [System.Runtime.Serialization.EnumMember(Value = "CHILD")]
    CHILD = 1,

    [System.Runtime.Serialization.EnumMember(Value = "TEEN")]
    TEEN = 2,

    [System.Runtime.Serialization.EnumMember(Value = "ADULT")]
    ADULT = 3,

  }
}
