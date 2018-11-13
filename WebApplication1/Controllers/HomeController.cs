using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hl7.Fhir.FhirPath;
using Hl7.Fhir;
using Hl7.Fhir.Rest;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Runtime.Serialization.Json;

namespace WebApplication1.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {

      string baseURI = "https://fhir-api-dstu2.smarthealthit.org";

      FhirClient client = new FhirClient(baseURI);
      client.OnBeforeRequest += (object sender, BeforeRequestEventArgs e) =>
      {
        // Replace with a valid bearer token for this server
        e.RawRequest.Headers.Add("Authorization", "Bearer b3c97ac8-9166-410b-bb93-d7aeca39f243");

      };

      var cow = Request.Headers.AllKeys;

      var chicken = Request.UserAgent.ToString();

      string userAgent = "User-Agant";

      var thatThing1 = Request.ServerVariables.Get("HTTP_USER_AGENT");
      var thatThing2 = Request.IsAuthenticated;
      var thatThing3 = Request.Headers.GetValues(Request.Headers.Count - 1).ToList();
      var thatThing4 = Request.Url.UserInfo.ToString();
      var thatThing5 = Request.Url.Query.ToString();

      //"?code=8GG2LW&state=4295f71c-4e8c-2afa-eceb-c46315d29930"

      var thatThing6a = Request.QueryString["authUri"];
      var thatThing6b = Request.QueryString["response_type"];
      var thatThing6c = Request.QueryString["client_id"];
      var thatThing6d = Request.QueryString["scope"];
      var thatThing6e = Request.QueryString["aud"];
      var thatThing6f = Request.QueryString["launch"];
      var thatThing6g = Request.QueryString["code"];
      var thatThing6h = Request.QueryString["state"];
      var thatThing6i = Request.QueryString["__utma"];

      //var thatThing7 = Request.UrlReferrer.Query; //.["launch"];

      var issAndLaunchId = new NameValueCollection();

      if (Request.UrlReferrer.Query != null)
      {
        issAndLaunchId = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);
      }
      var iss = issAndLaunchId.Get("iss");
      var launch = issAndLaunchId.Get("launch");


      var thatThing8 = this.Session;
      var sessionID = this.Session.SessionID;

      // load the app parameters stored in the session

      var thatThing9 = HttpContext.Session[thatThing6h];

      var thatThing10 = this.Session[thatThing6h];

      string myAction = iss + "/metadata";

      //var myResult;

      var myClient = new HttpClient();
      

        myClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer b3c97ac8-9166-410b-bb93-d7aeca39f243");
      string complianceDocURI = "http://fhir-registry.smarthealthit.org/StructureDefinition/oauth-uris";

      var myResult = myClient.GetAsync(myAction);

      object TempObjResponse;

      HttpWebRequest request = WebRequest.Create(myAction) as HttpWebRequest;
      using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
      {
        if (response.StatusCode != HttpStatusCode.OK)
          throw new Exception(String.Format(
          "Server error (HTTP {0}: {1}).",
          response.StatusCode,
          response.StatusDescription));

        var temp = response;
        var horse = 1;
        string readerResponse;

        using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
        {
          readerResponse = reader.ReadToEnd();
        }

          //var goat = Hl7.Fhir.Serialization.FhirJsonParser.CreateFhirReader(readerString);

         DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(HttpResponse));
        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
        TempObjResponse = objResponse;
       // var jsonResponse = objResponse as Response;
        //return jsonResponse;
      }

      var pig = 1;

      //  
      //  {

      //      //Add the authorization header
      //      zclient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer b3c97ac8-9166-410b-bb93-d7aeca39f243");


      //    var zresult = zclient.GetAsync(BuildActionUri(action));

      //    string json = zresult.Content.ReadAsStringAsync();
      //    if (zresult.IsSuccessStatusCode)
      //    {
      //      return JsonConvert.DeserializeObject<T>(json);
      //    }

      //    //throw new ApiException(result.StatusCode, json);

      //}

      // VVVV OMG!!! THIS IS IT! VVVV

      var thatThing11 = HttpContext.GetOwinContext();

// ^^^ IT'S RIGHT UP THERE! ^^^

      var thatThing12 = HttpContext.GetOwinContext();

      //var thatThing12 = HttpContext.

      //var userDisplayModel = new UserDisplayModel();

      var authenticateResultz = HttpContext.GetOwinContext().Authentication.GetAuthenticationTypes();
      var authenticateResult = HttpContext.GetOwinContext().Authentication.AuthenticateAsync("Bearer");
      var bearerId = authenticateResult.Id;

      //OAuthResponse accessToken = OnAuthentication.A
      //if (authenticateResult != null)
      //{
      //  var tokenClaim = authenticateResult..Identity.Claims.FirstOrDefault(claim => claim.Type == "urn:token:github");
      //  if (tokenClaim != null)
      //  {
      //    var accessToken = tokenClaim.Value;

      //    var gitHubClient = new GitHubClient(new ProductHeaderValue("OAuthTestClient"));
      //    gitHubClient.Credentials = new Credentials(accessToken);

      //    var user = await gitHubClient.User.Current();

      //    userDisplayModel.AccessToken = accessToken;
      //    userDisplayModel.Name = user.Name;
      //    userDisplayModel.AvatarUrl = user.AvatarUrl;

      //  }
      //}

      //return View(userDisplayModel);

      //var chick1 = client.

      



      //var str = context.Session.GetString(key);
      //var obj = JsonConvert.DeserializeObject<MyType>(str);

      //var str = this.Session..GetString(key);
      //var obj = JsonConvert..DeserializeObject<MyType>(str);

      //var paramsz = Json..parse(sessionStorage[state]);  // load app session
      //var tokenUri = params.tokenUri;
      //var clientId = params.clientId;
      //var secret = params.secret;
      //var serviceUri = params.serviceUri;
      //var redirectUri = params.redirectUri;


      //client.u
      //var currentUserFhirUrl;

      //oauth2.
      //Hl7.Fhir.D FHIR.oauth2.ready(function(client){
      //  currentUserFhirUrl = client.userId;
      //});
      return View();
    }

    public ActionResult About()
    {

      FhirClient client = new FhirClient("https://fhir-api-dstu2.smarthealthit.org");
      client.OnBeforeRequest += (object sender, BeforeRequestEventArgs e) =>
      {
        // Replace with a valid bearer token for this server
        e.RawRequest.Headers.Add("Authorization", "Bearer b3c97ac8-9166-410b-bb93-d7aeca39f243");

      };

      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {


      FhirClient client = new FhirClient("https://fhir-api-dstu2.smarthealthit.org");
      client.OnBeforeRequest += (object sender, BeforeRequestEventArgs e) =>
      {
        // Replace with a valid bearer token for this server
        e.RawRequest.Headers.Add("Authorization", "Bearer b3c97ac8-9166-410b-bb93-d7aeca39f243");

      };

      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}