using System;
using IucnRedList.Model;
using IucnRedList.WebService.Client;

namespace IucnRedList.ConsoleApp
{
  class Program
  {
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
      }

      Console.ReadKey();
    }
  }
}
