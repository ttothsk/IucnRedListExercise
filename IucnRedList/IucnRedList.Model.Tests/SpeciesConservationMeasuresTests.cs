using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IucnRedList.Model.Tests
{
  [TestClass]
  public class SpeciesConservationMeasuresTests
  {
    /// <summary>
    /// If conservation measures deserialized, ConservationMeasures string is ; separated concatenation of measures' titles and marked as set
    /// </summary>
    [TestMethod]
    public void ConservationMeasuresMatchesConservationMeasuresResponseResult()
    {
      ConservationMeasuresResponse measures = new ConservationMeasuresResponse();
      measures.Result = CreateTestConservationMeasures();

      Species species = new Species();
      species.ProcessConservationMeasures(measures);

      Assert.IsTrue(species.ConservationMeasuresSet);
      Assert.AreEqual("Site/area protection;Resource & habitat protection;Site/area management", species.ConservationMeasures);
    }

    /// <summary>
    /// If conservation measures response is null, call was unsuccessfull, ConservationMeasures string should be empty and marked as unset
    /// </summary>
    [TestMethod]
    public void NoConservationMeasuresResponse_ConservationMeasuresEmptyAndConservationMeasuresNotSet()
    {
      ConservationMeasuresResponse measures = null;


      Species species = new Species();
      species.ProcessConservationMeasures(measures);

      Assert.IsFalse(species.ConservationMeasuresSet);
      Assert.AreEqual(null, species.ConservationMeasures);
    }

    /// <summary>
    /// If conservation measures were not deserialized, call was unsuccessfull, ConservationMeasures string should be empty and marked as unset
    /// </summary>
    [TestMethod]
    public void NoConservationMeasuresResult_ConservationMeasuresEmptyAndConservationMeasuresNotSet()
    {
      ConservationMeasuresResponse measures = new ConservationMeasuresResponse();
      measures.Result = null;


      Species species = new Species();
      species.ProcessConservationMeasures(measures);

      Assert.IsFalse(species.ConservationMeasuresSet);
      Assert.AreEqual(null, species.ConservationMeasures);
    }

    /// <summary>
    /// If there is empty list of conservation measures, ConservationMeasures string should be empty, but marked as set to avoid repeated call
    /// </summary>
    [TestMethod]
    public void EmptyConservationMeasuresResponseResult_ConservationMeasuresEmptyAndConservationMeasuresSet()
    {
      ConservationMeasuresResponse measures = new ConservationMeasuresResponse();
      measures.Result = new List<ConservationMeasure>();


      Species species = new Species();
      species.ProcessConservationMeasures(measures);

      Assert.IsTrue(species.ConservationMeasuresSet);
      Assert.AreEqual(string.Empty, species.ConservationMeasures);
    }

    private static List<ConservationMeasure> CreateTestConservationMeasures()
    {
      List<ConservationMeasure> measures = new List<ConservationMeasure>();

      ConservationMeasure measure1 = new ConservationMeasure()
      {
        Code = "1.1",
        Title = "Site/area protection"
      };

      ConservationMeasure measure2 = new ConservationMeasure()
      {
        Code = "1.2",
        Title = "Resource & habitat protection"
      };

      ConservationMeasure measure3 = new ConservationMeasure()
      {
        Code = "2.1",
        Title = "Site/area management"
      };

      measures.Add(measure1);
      measures.Add(measure2);
      measures.Add(measure3);

      return measures;
    }
  }
}
