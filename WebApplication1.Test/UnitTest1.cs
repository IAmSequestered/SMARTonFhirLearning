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
  public class UnitTest1
  {
    #region Class Initialize
    static string[] myServers = new string[4];
    //string url = ;
    static string url;
    

    [AssemblyInitialize()]
    public static void AssemblyInit(TestContext context)
    {
    }

    [ClassInitialize()]
    public static void ClassInit(TestContext context)
    {
      myServers[0] = "https://fhir-open-api-dstu2.smarthealthit.org";
      myServers[1] = "https://fhir-open.sandboxcerner.com/dstu2/d075cf8b-3261-481d-97e5-ba6c48d3b41f";
      myServers[2] = "https://fhir-open.sandboxcerner.com/dstu2/0b8a0111-e8e6-4c26-a91c-5069cbc6b1ca";
      myServers[3] = "http://fhirtest.uhn.ca/baseDstu2";

      url = myServers[3].ToString();
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

    [AssemblyCleanup()]
    public static void AssemblyCleanup()
    { 
    }

    #endregion

    [TestMethod]
    public void TestMethod1()
    {
    }

    /// <summary>
    /// Simple get a patient by id
    /// </summary>
    [TestMethod]
    public void TestMethod2()
    {
      //var client = new FhirClient("http://spark.furore.com/fhir");

      //http://fhirtest.uhn.ca/home?encoding=null&pretty=true

      //string url = "http://spark.furore.com/fhir";
      //url = "http://fhirtest.uhn.ca/baseDstu2";
      string id = "128632";
      //id = "1867";
      id = "857";

      var client = new FhirClient(url);
      var identity = ResourceIdentity.Build("Patient", id);
      //var patient = client.Read<Patient>(identity).VersionId;

      //var patient2 = client.Read<Patient>(identity).
      var patEntryA = client.Read<Patient>(identity);

      string patientName = patEntryA.Name[0].FamilyElement[0].Value.ToString();
      string temp = "yep";

      Assert.AreEqual("Robinson", patEntryA.Name[0].FamilyElement[0].Value.ToString());

    }


    /// <summary>
    /// Simple get a patient by id
    /// </summary>
    [TestMethod]
    public void TestMethod2b()
    {

      string id = "857";

      var client = new FhirClient(url);
      var identity = ResourceIdentity.Build("Patient", id);

      var patEntryA = client.Read<Patient>(identity);

      string patientName = patEntryA.Name[0].FamilyElement[0].Value.ToString();

      Assert.AreEqual("Robinson", patEntryA.Name[0].FamilyElement[0].Value.ToString());

    }

    /// <summary>
    /// Get some patient demographics by id
    /// </summary>
    [TestMethod]
    public void GetPatientDemographicsSimple01()
    {

      string id = "857";

      var client = new FhirClient(url);
      var identity = ResourceIdentity.Build("Patient", id);

      var patEntryA = client.Read<Patient>(identity);

      string patientLastName = patEntryA.Name[0].FamilyElement[0].Value.ToString();
      string patientFirstName = patEntryA.Name[0].GivenElement[0].Value.ToString();
      string patientDOB = patEntryA.BirthDateElement.Value.ToString();

      Assert.AreEqual("Robinson", patEntryA.Name[0].FamilyElement[0].Value.ToString());

    }


    /// <summary>
    /// Get a list of appointments available for a given provider
    /// </summary>
    /// <remarks>
    /// Base url: https://fhir-open.sandboxcerner.com/dstu2/0b8a0111-e8e6-4c26-a91c-5069cbc6b1ca/Appointment?practitioner=709932&date=2006&_count=50
    /// Frome here: https://groups.google.com/forum/#!searchin/cerner-fhir-developers/appointment%7Csort:relevance/cerner-fhir-developers/eU0qH2b7OXE/-Q9mcNFdCgAJ
    /// </remarks>
    [TestMethod]
    public void TestMethod3()
    {
      //var client = new FhirClient("http://spark.furore.com/fhir");

      string url = "http://spark.furore.com/fhir";
      url = "https://fhir-open.sandboxcerner.com/dstu2";
      string id = "128632";
      id = "2961";

      var client = new FhirClient(url);
      var identity = ResourceIdentity.Build("Patient", id);
      //var patient = client.Read<Patient>(identity).VersionId;

      //var patient2 = client.Read<Patient>(identity).
      var patEntryA = client.Read<Patient>(identity);


      string temp = "yep";

      //Assert.AreEqual(patient.Name[0].FamilyElement[0].Value.ToString() , "Dureidy");

    }
    /// <summary>
    /// ** Workflow
    /// Patient requests appointment.
    ///   Patient is identified by ID
    ///   Patients default provider is searched for.
    ///   Providers 
    /// </summary>


    /// <summary>
    /// Simple get a patient by id
    /// </summary>
    [TestMethod]
    public void TestMethod4()
    {
      //var client = new FhirClient("http://spark.furore.com/fhir");

      //http://fhirtest.uhn.ca/home?encoding=null&pretty=true

      string url = "http://spark.furore.com/fhir";
      url = "https://fhir-open-api-dstu2.smarthealthit.org";

      string id = "128632";
      id = "724111";

      var client = new FhirClient(url);
      var identity = ResourceIdentity.Build("Patient", id);
      //var patient = client.Read<Patient>(identity).VersionId;

      //var patient2 = client.Read<Patient>(identity).
      Patient patEntryA = client.Read<Patient>(identity);

      HumanName zip = patEntryA.Name[patEntryA.Name.Count - 1];
      HumanName zip2 = patEntryA.Name.LastOrDefault();
      HumanName humanName = patEntryA.Name.FirstOrDefault();

      var boink = patEntryA.Name[patEntryA.Name.Count - 1].Family;

      string givenName = "";

      foreach (string given in humanName.Given)
      {
        givenName = givenName + given + " ";

      }
      givenName.TrimEnd();

      //string givenName = humanName.Given.FirstOrDefault().ToString();
      string familyName = humanName.Family.FirstOrDefault().ToString();

      string fullName = givenName + " " + familyName;

      string temp3 = boink.FirstOrDefault().ToString();

      //  string patientName1 = patEntryA.Name[patEntryA.Name.Count-1].Text;

      // string patientName2 = zip.Text;

      var patientName1 = zip.Family;
      //string cow = patientName1.
      string patientName3 = zip.Family.ToString();

      //var patientName3 = patEntryA.Name.FindLast(Predicate <HumanName> "FamilyName").
      //p.Name.First().Text

      //string patientName2 = patEntryA.Name.First().Text;
      // var patientThing = patEntryA.Name.LastIndexOf();
      //.FindLast(FamilyName<HumanName>).ToString();

      string temp = "yep";

      //Assert.AreEqual(patient.Name[0].FamilyElement[0].Value.ToString() , "Dureidy");

    }

    /// <summary>
    /// Simple get a patient by id
    /// </summary>
    [TestMethod]
    public void TestMethod5()
    {

      string id = "724111";

      var client = new FhirClient(url);
      var identity = ResourceIdentity.Build("Patient", id);

      Patient patEntryA = client.Read<Patient>(identity);

      HumanName humanName = patEntryA.Name.LastOrDefault();

      string givenName = "";

      foreach (string given in humanName.Given)
      {
        givenName = givenName + given + " ";
      }

      givenName = givenName.Trim();


      string familyName = humanName.Family.FirstOrDefault().ToString();

      string fullName = givenName + " " + familyName;

      string temp = "Break Here";

      Assert.AreEqual(fullName, "Amy C. Morgan");

    }

    /// <summary>
    /// Get all the Conditions for a patient
    /// </summary>
    [TestMethod]
    public void TestMethod6()
    {

      string id = "207";
      
      var client = new FhirClient(url);
      var identity = ResourceIdentity.Build("Patient", id);

      Patient patEntryA = client.Read<Patient>(identity);

      var q = new SearchParams();
      //q.Add("Patient.identifier", patEntryA.Identifier.FirstOrDefault().ToString());
      q.Add("patient", id);

      //This is the error I got when I had the query wrong. It didn't work when it was...
        // q.Add("Condition.patient", id);
      //"Operation was unsuccessful, and returned status BadRequest. OperationOutcome: <div xmlns=\"http://www.w3.org/1999/xhtml\">
      // <h1>Operation Outcome</h1><table border=\"0\"><tr><td style=\"font-weight: bold;\">error</td><td>[]</td><td>" +
      // "<pre>Unknown search parameter \"Condition\". Value search parameters for this search are: " +
      // "[_id, _language, asserter, body-site, category, clinicalstatus, code, date-recorded, encounter, 
      // evidence, identifier, onset, onset-info, patient, severity, stage]</pre></td></tr></table></div>"

      Bundle result = client.Search<Condition>(q);
      string theCount = "Got " + result.Entry.Count() + " records!";
      var theTotal = result.Total.Value;

      IList<Condition> aList = new List<Condition>();
      IList<string> bList = new List<string>();

      foreach (var entry in result.Entry)
      {
        Condition p = (Condition)entry.Resource;

        aList.Add(p);
        bList.Add(p.Text.ToString());


      }
      bList = bList.Distinct().ToList();

      string temp = "Break Here";

    }


    /// <summary>
    /// Get all the Conditions for a patient
    /// </summary>
    [TestMethod]
    public void TestMethod6b()
    {

      string url = "http://fhirtest.uhn.ca/baseDstu2";
      string id = "207";

      var client = new FhirClient(url);
      var identity = ResourceIdentity.Build("Patient", id);


      Patient patEntryA = client.Read<Patient>(identity);

      var q = new SearchParams();

      q.Add("patient", id);

      Bundle result = client.Search<Condition>(q);
      string theCount = "Got " + result.Entry.Count() + " records!";
      var theTotal = result.Total.Value;

      IList<Condition> aList = new List<Condition>();
      IList<string> bList = new List<string>();

      foreach (var entry in result.Entry)
      {
        Condition p = (Condition)entry.Resource;

        aList.Add(p);
        bList.Add(p.Code.Text.ToString());

        Console.WriteLine(p.Id + "" + p.Category + "     " + p.FhirCommentsElement + "   " + "\r\n");
        //Console.ReadKey();

      }
      bList = bList.Distinct().ToList();
      //var temp = patEntryA.

      string temp = "Break Here";

      }

    /// <summary>
    /// Search for a patient by name and get a list of their allergies.
    /// </summary>
    [TestMethod]
    public void TestMethod7()
    {

      string id = "724111";
      //id = "1685497";
      var client = new FhirClient(url);

      //var criteria = new string[] { "family=Morgan", "gender=female" };
      // Bundle result = client.Search<Patient>(criteria);

      //GET[base] / Observation ? patient =[id] & code[vital sign LOINC{,LOINC2,LOINC3,...}].

      var criteria = new string[] { "patient=" + id, };
      Bundle result = client.Search<Observation>(criteria);

      string myObservations;

      foreach (var entry in result.Entry)
      {
        Observation observation = (Observation)entry.Resource;
        myObservations = String.Concat(observation.Value.ToString(), " ");

        //label1.Text = label1.Text + p.Id + " " + p.Name.First().Text + "\r\n";
      }

      string temp = "Break Here";

      //var identity = ResourceIdentity.Build("Patient", id);

      ;
      //Patient patEntryA = client.Read<Patient>(identity);

      //// var patEntryAAllergies = client.Read<AllergyIntolerance>("AllergyIntolerance", patEntryA.Identifier.ToString());

      //var q = new SearchParams();
      ////q.Add("Patient.identifier", patEntryA.Identifier.FirstOrDefault().ToString());
      //q.Add("Condition.patient", id);


      //Bundle result = client.Search<Condition>(q);
      //string theCount = "Got " + result.Entry.Count() + " records!";
      //var theTotal = result.Total.Value;

      //IList<Condition> aList = new List<Condition>();
      //IList<string> bList = new List<string>();

      //foreach (var entry in result.Entry)
      //{
      //  Condition p = (Condition)entry.Resource;

      //  aList.Add(p);
      //  bList.Add(p.Text.ToString());

      //  //Console.WriteLine(p.Id + "" + p.Category + "     " + p.Substance + "   " + "\r\n");
      //  //Console.ReadKey();

      //}
      //bList = bList.Distinct().ToList();
      ////var temp = patEntryA.





      //var client = new Hl7.Fhir.Rest.FhirClient("http://52.72.172.54:8080/fhir/baseDstu2/");
      //var result = client.Read<Patient>("Patient/Patient-19454");
      //var allergyResult = client.Read<AllergyIntolerance>("AllergyIntolerance/AllergyIntolerance-19454");

    }

    /// <summary>
    /// Get a list of a patients Conditions.
    /// </summary>
    [TestMethod]
    public void TestMethod8()
    {

      string id = "99912345";
      //id = "1685497";
      var client = new FhirClient(url);


      var criteria = new string[] { "patient=" + id, };
      Bundle result = client.Search<Condition>(criteria);

      IList<string> myConditions = new List<string>();

      foreach (var entry in result.Entry)
      {
        Condition condition = (Condition)entry.Resource;
        myConditions.Add(condition.Code.Text.ToString());

      }

      string temp = "Break Here";

    }

    /// <summary>
    /// Get a list of a patients Conditions.
    /// </summary>
    [TestMethod]
    public void TestMethod8b()
    {

      string id = "99912345";
      //id = "1685497";
      var client = new FhirClient(url);

      var q = new SearchParams()
        .Where("patient=" + id);

      Bundle result = client.Search<Condition>(q);

      IList<string> myConditions = new List<string>();

      foreach (var entry in result.Entry)
      {
        Condition condition = (Condition)entry.Resource;
        myConditions.Add(condition.Code.Text.ToString());

      }

      string temp = "Break Here";

    }

    /// <summary>
    /// Get a list of a patients Immunizations.
    /// </summary>
    [TestMethod]
    public void TestMethod9()
    {

      string id = "99912345";

      var client = new FhirClient(url);

      var criteria = new string[] { "patient=" + id, };
      Bundle result = client.Search<Immunization>(criteria);

      IList<string> myImmunizations = new List<string>();

      foreach (var entry in result.Entry)
      {
        Immunization immunization = (Immunization)entry.Resource;
        myImmunizations.Add(immunization.VaccineCode.Coding.FirstOrDefault().Display.ToString());
      }

      string temp = "Break Here";

    }

    /// <summary>
    /// Get a list of a patients Procedures.
    /// </summary>
    [TestMethod]
    public void TestMethod10()
    {

      string id = "99912345";

      var client = new FhirClient(url);

      var criteria = new string[] { "patient=" + id, };
      Bundle result = client.Search<Procedure>(criteria);

      IList<string> myProcedures = new List<string>();

      foreach (var entry in result.Entry)
      {
        Procedure procedure = (Procedure)entry.Resource;
        myProcedures.Add(procedure.Code.Coding.FirstOrDefault().Display.ToString());
      }

      string temp = "Break Here";

    }
    /// <summary>
    /// Get a list of a patients Medications.
    /// </summary>
    [TestMethod]
    public void TestMethod11()
    {

      string id = "99912345";

      var client = new FhirClient(url);

      var criteria = new string[] { "patient=" + id, };
      Bundle result = client.Search<MedicationOrder>(criteria);

      IList<string> myMedicationOrders = new List<string>();

      foreach (var entry in result.Entry)
      {
        MedicationOrder medicationOrder = (MedicationOrder)entry.Resource;
        //myMedicationOrders.Add(medicationOrder.Medication..Medication.FirstOrDefault().Display.ToString());
      }

      string temp = "Break Here";

    }
    //medicationCodeableConcept
    //Practitioner

    /// <summary>
    /// Get a list of Practitioners.
    /// </summary>
    [TestMethod]
    public void TestMethod12()
    {

      string id = "99912345";

      var client = new FhirClient(url);

      //var criteria = new string[] { "patient=" + id, };
      var criteria = new string[] { "family=Smith" };
      Bundle result = client.Search<Practitioner>(criteria);

      IList<string> myProviders = new List<string>();

      foreach (var entry in result.Entry)
      {
        Practitioner medicationOrder = (Practitioner)entry.Resource;
        //myMedicationOrders.Add(medicationOrder.Medication..Medication.FirstOrDefault().Display.ToString());
      }

      string temp = "Break Here";

    }

//    var q = new Query()
//.For(“Patient”).Where(“name: exact = ewout”)
//.OrderBy(“birthDate”, SortOrder.Descending)
//.SummaryOnly().Include(“Patient.managingOrganization”)
//.LimitTo(20);

    /// <summary>
    /// Get a list of Practitioners and their organizations.
    /// *** Organizations ain't there yet!
    /// </summary>
    [TestMethod]
    public void TestMethod13()
    {

      string id = "99912345";

      var client = new FhirClient(url);

      //var q = new SearchParams()
      //  .
      //.Add("type", "Practitioner");
      //      .
      //      ..For(“Practitioner”).Where(“name: exact = ewout”)
      //.OrderBy(“birthDate”, SortOrder.Descending)
      //.SummaryOnly().Include(“Patient.managingOrganization”)
      //.LimitTo(20);


      var criteria = new string[] { "family=S" };
      Bundle result = client.Search<Practitioner>(criteria);

      IList<string> myProviders = new List<string>();

      foreach (var entry in result.Entry)
      {
        Practitioner medicationOrder = (Practitioner)entry.Resource;
        //myMedicationOrders.Add(medicationOrder.Medication..Medication.FirstOrDefault().Display.ToString());
      }

      string temp = "Break Here";

    }

    /// <summary>
    /// Read a Practitioner using their ID.
    /// </summary>
    [TestMethod]
    public void TestMethod14()
    {

      string id = "1234";

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
        .Where("_id=" + id);
      
      var myURI = q.ToUriParamList();

      var criteria = new string[] { "id=" + id };
      Bundle result = client.Search<Practitioner>(q);

      IList<string> myProviders = new List<string>();

      foreach (var entry in result.Entry)
      {
        Practitioner medicationOrder = (Practitioner)entry.Resource;
        //myMedicationOrders.Add(medicationOrder.Medication..Medication.FirstOrDefault().Display.ToString());
      }

      string temp = "Break Here";

    }

    /// <summary>
    /// Read a Practitioner using their ID.
    /// </summary>
    [TestMethod]
    public void TestMethod15()
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
        .Include("Practitioner.practitionerRole.managingOrganization")
        .Include("Practitioner.practitionerRole.location");

      var myURI = q.ToUriParamList();

      var criteria = new string[] { "id=" + id };
      Bundle result = client.Search<Practitioner>(q);

      IList<string> myProviders = new List<string>();

      foreach (var entry in result.Entry)
      {
        Practitioner medicationOrder = (Practitioner)entry.Resource;
        //myMedicationOrders.Add(medicationOrder.Medication..Medication.FirstOrDefault().Display.ToString());
      }

      string temp = "Break Here";

    }

    /// <summary>
    /// Read a Patient using their name.
    /// </summary>
    [TestMethod]
    public void TestMethod16()
    {

      string id = "99912345";

      var client = new FhirClient(url);
      client.PreferredFormat = ResourceFormat.Json;

      var q = new SearchParams()
      .Where("_id=" + id)
      .Include("Patient.careProvider");

      var myURI = q.ToUriParamList();

      var criteria = new string[] { id };
      string myString = id.ToString();
      Bundle result = client.Search<Patient>(q);

      IList<string> myPatients = new List<string>();

      foreach (var entry in result.Entry)
      {
        Patient myPatient = (Patient)entry.Resource;
        //myMedicationOrders.Add(medicationOrder.Medication..Medication.FirstOrDefault().Display.ToString());
      }

      string temp = "Break Here";

    }
    //"Practitioner/"


  /// <summary>
  /// Read a Patient using their name.
  /// </summary>
  [TestMethod]
  public void TestMethod17()
  {

    string id = "1912007";

    var client = new FhirClient(url);
    client.PreferredFormat = ResourceFormat.Json;

    var q = new SearchParams()
    .Where("_id=" + id);

    var myURI = q.ToUriParamList();

    var criteria = new string[] { id };
    string myString = id.ToString();
    Bundle result = client.Search<Practitioner>(q);

    IList<string> myPatients = new List<string>();

    foreach (var entry in result.Entry)
    {
        Practitioner myPatient = (Practitioner)entry.Resource;
      //myMedicationOrders.Add(medicationOrder.Medication..Medication.FirstOrDefault().Display.ToString());
    }

    string temp = "Break Here";
    }
  }
}

