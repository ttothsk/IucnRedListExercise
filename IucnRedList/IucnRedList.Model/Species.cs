﻿// generated by jsonutils.com
// edited names, added comments and code style aligned

using Newtonsoft.Json;

namespace IucnRedList.Model
{
  public class Species
  {
    [JsonProperty("taxonid")]
    public int TaxonId { get; set; }

    [JsonProperty("kingdom_name")]
    public string KingdomName { get; set; }

    [JsonProperty("phylum_name")]
    public string PhylumName { get; set; }

    [JsonProperty("class_name")]
    public string ClassName { get; set; }

    [JsonProperty("order_name")]
    public string OrderName { get; set; }

    [JsonProperty("family_name")]
    public string FamilyName { get; set; }

    [JsonProperty("genus_name")]
    public string GenusName { get; set; }

    [JsonProperty("scientific_name")]
    public string ScientificName { get; set; }

    [JsonProperty("infra_rank")]
    public object InfraRank { get; set; }

    [JsonProperty("infra_name")]
    public object InfraName { get; set; }

    [JsonProperty("population")]
    public object Population { get; set; }

    [JsonProperty("category")]
    public string Category { get; set; }
  }
}