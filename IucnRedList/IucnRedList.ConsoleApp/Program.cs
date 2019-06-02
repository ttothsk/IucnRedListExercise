using System;
using System.Collections.Generic;
using System.Linq;
using IucnRedList.Model;
using IucnRedList.WebService.Client;

namespace IucnRedList.ConsoleApp
{
  class Program
  {
    const int cMaxQueryNr = 20; // query/display restriction because of Conservation Measures fetch speed, 10 000 is full page
    const string cMammals = "MAMMALIA";
    const string cCriticallyEndangered = "CR";

    static void Main(string[] args)
    {
      using (IucnRedListApiV3Client client = new IucnRedListApiV3Client())
      {
        RegionsResponse regions = client.GetRegionsAsync().Result;

        if (regions == null)
        {
          Console.WriteLine("Error ocurred loading the list of regions");
          Console.ReadKey();
          return;
        }

        Console.WriteLine("Regions:");

        for (int i = 0; i < regions.Results.Count; i++)
        {
          Console.WriteLine(string.Format("{0}  {1}", i, regions.Results[i].Name));
        }

        Console.WriteLine();
        Console.WriteLine("Enter number of region");

        string selection = Console.ReadLine();

        int regionNr;

        if (!int.TryParse(selection, out regionNr)
            || regionNr < 0
            || regionNr >= regions.Results.Count)
        {
          Console.WriteLine("Invalid region number");
          Console.ReadKey();
          return;
        }

        string region = regions.Results[regionNr].Identifier;

        SpeciesResponse species = client.GetSpeciesRegionalAssesmentsAsync(region, 0).Result;

        if (species == null)
        {
          Console.WriteLine("Error ocurred loading the list of species");
          Console.ReadKey();
          return;
        }

        List<Species> criticallyEndangered = species.Result.Where(s => s.Category == cCriticallyEndangered).ToList();

        Console.WriteLine();
        Console.WriteLine("Critically endangered species:");

        FetchMeasuresAndPrintSpeciesDetails(criticallyEndangered, region, client);

        Console.WriteLine();

        List<Species> mammals = species.Result.Where(s => s.ClassName == cMammals).ToList();

        Console.WriteLine();
        Console.WriteLine("Mammals:");

        FetchMeasuresAndPrintSpeciesDetails(mammals, region, client);

        Console.WriteLine();
      }

      Console.WriteLine("Press any key to quit");

      Console.ReadKey();
    }

    static void FetchMeasuresAndPrintSpeciesDetails(List<Species> speciesList, string region, IucnRedListApiV3Client client)
    {
      for (int i = 0; i < Math.Min(cMaxQueryNr, speciesList.Count); i++)
      {
        Species species = speciesList[i];

        if (!species.ConservationMeasuresSet) // fetch only if not already set, even if previous result was empty
        {
          ConservationMeasuresResponse conservationMeasures = client.GetConservationMeasuresBySpeciesIdRegionalAssesmentsAsync(species.TaxonId, region).Result;

          if (conservationMeasures != null)
          {
            species.ProcessConservationMeasures(conservationMeasures);
          }
        }

        Console.WriteLine(species.GetDisplayInfo());
      }
    }
  }
}
