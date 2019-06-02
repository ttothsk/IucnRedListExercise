﻿// generated by jsonutils.com
// edited names, added comments and code style aligned

using System.Collections.Generic;
using Newtonsoft.Json;

namespace IucnRedList.Model
{
  /// <summary>
  /// Represents IUCN Red List API V3 response for Region list service method
  /// </summary>
  /// <see cref="http://apiv3.iucnredlist.org/api/v3/docs#regions"/>
  public class RegionsResponse
  {
    public RegionsResponse()
    {
      Display = "Number of regions: " + Count;
    }

    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("results")]
    public IList<Region> Results { get; set; }

    [JsonIgnore]
    public string Display { get; set; }
  }
}
