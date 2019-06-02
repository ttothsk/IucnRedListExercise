﻿// generated by jsonutils.com
// edited names, added comments and code style aligned

using System.Collections.Generic;
using Newtonsoft.Json;

namespace IucnRedList.Model
{
  /// <summary>
  /// Represents IUCN Red List API V3 response for Species service methods
  /// </summary>
  /// <see cref="http://apiv3.iucnredlist.org/api/v3/docs#species"/>
  public class SpeciesResponse
  {
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("region_identifier")]
    public string RegionIdentifier { get; set; }

    [JsonProperty("page")]
    public string Page { get; set; }

    [JsonProperty("result")]
    public IList<Species> Result { get; set; }
  }
}
