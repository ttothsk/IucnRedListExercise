using System;
using System.Net.Http;
using System.Net.Http.Headers;
using IucnRedList.Model;

namespace IucnRedList.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri("http://apiv3.iucnredlist.org/api/v3/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //GET Method  
        HttpResponseMessage response = client.GetAsync("region/list?token=9bb4facb6d23f48efbf424bb05c0c1ef1cf6f468393bc745d42179ac4aca5fee").Result;
        if (response.IsSuccessStatusCode)
        {
          RegionsResponse responseContent = response.Content.ReadAsAsync<RegionsResponse>().Result;

          foreach (Region result in responseContent.Results)
          {
            Console.WriteLine(string.Format("{0}-{1}", result.Identifier, result.Name));
          }

        }
        else
        {
          Console.WriteLine("Internal server Error");
        }
      }

      Console.ReadKey();
    }
  }
}
