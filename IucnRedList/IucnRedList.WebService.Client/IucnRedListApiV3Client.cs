using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IucnRedList.Model;

namespace IucnRedList.WebService.Client
{
  /// <summary>
  /// Http client to call IUCN Red List API V3 services
  /// </summary>
  public class IucnRedListApiV3Client : IDisposable
  {
    private const string cToken = "9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee"; // public token without registration

    private HttpClient mClient;

    private bool disposedValue = false;

    public IucnRedListApiV3Client()
    {
      mClient = new HttpClient();
      mClient.BaseAddress = new Uri(IucnRedListApiV3UriFormats.BaseAdress);
      mClient.DefaultRequestHeaders.Accept.Clear();
      mClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    /// <summary>
    /// Retrieves the list of world regions
    /// </summary>
    /// <returns>RegionsResponse as defined by IUCN API V3</returns>
    public async Task<RegionsResponse> GetRegionsAsync()
    {
      RegionsResponse regions = null;

      HttpResponseMessage response = await mClient.GetAsync(Uri.EscapeUriString(string.Format(IucnRedListApiV3UriFormats.Regions, cToken)));

      if (response.IsSuccessStatusCode)
      {
        regions = await response.Content.ReadAsAsync<RegionsResponse>();
      }

      return regions;
    }

    /// <summary>
    /// Retrieves the list of species for given world region. Supports pagination.
    /// </summary>
    /// <param name="region">Identifier (identifier field) of the region</param>
    /// <param name="page">Number of query page. One page has size 10 000</param>
    /// <returns>SpeciesResponse as defined by IUCN API V3</returns>
    public async Task<SpeciesResponse> GetSpeciesRegionalAssesmentsAsync(string region, uint page)
    {
      SpeciesResponse species = null;

      HttpResponseMessage response = await mClient.GetAsync(Uri.EscapeUriString(string.Format(IucnRedListApiV3UriFormats.SpeciesRegionalAssesments, region, page, cToken)));

      if (response.IsSuccessStatusCode)
      {
        species = await response.Content.ReadAsAsync<SpeciesResponse>();
      }

      return species;
    }

    /// <summary>
    /// Retrieves the list of conservation measures for given species.
    /// </summary>
    /// <param name="taxonId">Taxon identifier (taxonid field) of the species</param>
    /// <param name="region">Identifier (identifier field) of the region</param>
    /// <returns>ConservationMeasuresResponse as defined by IUCN API V3</returns>
    /// <remarks>Sometimes slow when called one by one per each species in filtered list, at least with public token. Replace with bulk query, whenever API provides such</remarks>
    public async Task<ConservationMeasuresResponse> GetConservationMeasuresBySpeciesIdRegionalAssesmentsAsync(int taxonId, string region)
    {
      ConservationMeasuresResponse measures = null;

      HttpResponseMessage response = await mClient.GetAsync(Uri.EscapeUriString(string.Format(IucnRedListApiV3UriFormats.ConservationMeasuresBySpeciesIdRegionalAssesments, taxonId, region, cToken)));

      if (response.IsSuccessStatusCode)
      {
        measures = await response.Content.ReadAsAsync<ConservationMeasuresResponse>();
      }

      return measures;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          mClient.Dispose();
          mClient = null;
        }

        disposedValue = true;
      }
    }
  }
}
