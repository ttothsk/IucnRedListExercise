namespace IucnRedList.WebService.Client
{
  public static class IucnRedListApiV3UriFormats
  {
    public static string BaseAdress = "http://apiv3.iucnredlist.org/api/v3/";

    public static string Regions = "region/list?token={0}";

    public static string SpeciesRegionalAssesments = "species/region/{0}/page/{1}?token={2}";

    public static string ConservationMeasuresBySpeciesIdRegionalAssesments = "measures/species/id/{0}/region/{1}?token={2}";
  }
}
