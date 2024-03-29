﻿// generated by jsonutils.com
// edited names, added comments and code style aligned

using Newtonsoft.Json;

namespace IucnRedList.Model
{
  /// <summary>
  /// Represents IUCN Red List API V3 Region result item
  /// </summary>
  public class Region
  {
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("identifier")]
    public string Identifier { get; set; }
  }
}
