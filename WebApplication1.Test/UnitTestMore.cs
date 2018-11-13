using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;
using Hl7.Fhir;
using System.Collections;

namespace WebApplication1.Test
{
  [TestClass]
  public class UnitTestMore
  {
    #region Class Initialize
    static string[] myServers = new string[3];
    //string url = ;
    static string url;


    [ClassInitialize()]
    public static void ClassInit(TestContext context)
    {
      myServers[0] = "https://fhir-open-api-dstu2.smarthealthit.org";
      myServers[1] = "https://fhir-open.sandboxcerner.com/dstu2/d075cf8b-3261-481d-97e5-ba6c48d3b41f";
      myServers[2] = "https://fhir-open.sandboxcerner.com/dstu2/0b8a0111-e8e6-4c26-a91c-5069cbc6b1ca";

      url = myServers[0].ToString();
    }

    [TestInitialize()]
    public void Initialize()
    {
    }

    [TestCleanup()]
    public void Cleanup()
    {
    }

    [ClassCleanup()]
    public static void ClassCleanup()
    {
    }


    #endregion

    [TestMethod]
    public void TestMethodz()
    {
      Assert.IsFalse(true);
    }

    /// <summary>
    /// Read a Practitioner using their ID.
    /// </summary>
    [TestMethod]
    public void TestMethod22()
    {

      string id = "1234";  //"HB-325359";

      var client = new FhirClient(url);

      //var q = new SearchParams()
      //  .
      //.Add("type", "Practitioner");
      //      .
      //      ..For(“Practitioner”).Where(“name: exact = ewout”)
      //.OrderBy(“birthDate”, SortOrder.Descending)
      //.SummaryOnly().Include(“Patient.managingOrganization”)
      //.LimitTo(20);

      var q = new SearchParams()
        .Where("id=" + id)
        .Include("Location.managingOrganization")
        .Include("Location.partof")
        .LimitTo(100); 
    //    .Include("Practitioner.practitionerRole.managingOrganization")
      //  .Include("Practitioner.practitionerRole.location");


      Bundle result = client.Search<Location>(q);

      IList<string> myLocations = new List<string>();

      foreach (var entry in result.Entry)
      {
        Location myLocation = (Location)entry.Resource;
        //myLocations.Add(myLocation.Name.ToString());
        myLocations.Add(myLocation.PartOf.TypeName.ToString());
        //myMedicationOrders.Add(medicationOrder.Medication..Medication.FirstOrDefault().Display.ToString());
      }

      string temp = "Break Here";

    }

    /// <summary>
    /// Read a Patient using their name.
    /// </summary>
    [TestMethod]
    public void TestMethod24()
    {

      string id = "f001";

      var client = new FhirClient(url);
      client.PreferredFormat = ResourceFormat.Json;

      var q = new SearchParams()
      .Where("_id=" + id)
      .Include("Organization.partOf");

        //    

      Bundle result = client.Search<Organization>(q);

      IList<string> myPatients = new List<string>();

      foreach (var entry in result.Entry)
      {
        Organization myPatient = (Organization)entry.Resource;
        //myMedicationOrders.Add(medicationOrder.Medication..Medication.FirstOrDefault().Display.ToString());
      }

      string temp = "Break Here";

    }
    //"Practitioner/"


    /// <summary>
    /// Read a Patient using their name.
    /// </summary>
    [TestMethod]
    public void TestMethod25()
    {

      string id = "1912007";

      var client = new FhirClient(url);
      client.PreferredFormat = ResourceFormat.Json;

      var q = new SearchParams()
      .Where("_id=" + id);

      var myURI = q.ToUriParamList();

      var criteria = new string[] { id };

      Bundle result = client.Search<Organization>(q);

      IList<string> myPatients = new List<string>();

      foreach (var entry in result.Entry)
      {
        Organization myPatient = (Organization)entry.Resource;
        //myMedicationOrders.Add(medicationOrder.Medication..Medication.FirstOrDefault().Display.ToString());
      }

      string temp = "Break Here";
    }
  }
}
