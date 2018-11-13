using System;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using WebApplication1.Models;

using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using System.Configuration;

//using Owin;
//using Microsoft.Owin.Security.Jwt;
//using System.IdentityModel;
//using System.IdentityModel.Tokens;
//using System.Text;

namespace WebApplication1
{
  public partial class Startup
  {
    // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
    public void ConfigureAuth(IAppBuilder app)
    {
      // Configure the db context, user manager and signin manager to use a single instance per request
      app.CreatePerOwinContext(ApplicationDbContext.Create);
      app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
      app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

      // Enable the application to use a cookie to store information for the signed in user
      // and to use a cookie to temporarily store information about a user logging in with a third party login provider
      // Configure the sign in cookie
      app.UseCookieAuthentication(new CookieAuthenticationOptions
      {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString("/Account/Login"),
        Provider = new CookieAuthenticationProvider
        {
          // Enables the application to validate the security stamp when the user logs in.
          // This is a security feature which is used when you change a password or add an external login to your account.  
          OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                  validateInterval: TimeSpan.FromMinutes(30),
                  regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
        }
      });
      app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

      // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
      app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

      // Enables the application to remember the second login verification factor such as phone or email.
      // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
      // This is similar to the RememberMe option when you log in.
      app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

      // Uncomment the following lines to enable logging in with third party login providers
      //app.UseMicrosoftAccountAuthentication(
      //    clientId: "",
      //    clientSecret: "");

      //app.UseTwitterAuthentication(
      //   consumerKey: "",
      //   consumerSecret: "");

      //app.UseFacebookAuthentication(
      //   appId: "",
      //   appSecret: "");

      //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
      //{
      //    ClientId = "",
      //    ClientSecret = ""
      //});

      //var issuer = ConfigurationManager.AppSettings["issuer"];
      //var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["secret"]);

      var issuer = "https://authorize-dstu2.smarthealthit.org";
      var audience = "patient/*.read";
      var secret = TextEncodings.Base64Url.Decode("b3c97ac8-9166-410b-bb93-d7aeca39f243");

      // Api controllers with an [Authorize] attribute will be validated with JWT
      app.UseJwtBearerAuthentication(
          new JwtBearerAuthenticationOptions
          {
            AuthenticationMode = AuthenticationMode.Active,
            AllowedAudiences = new[] { audience },
            IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
              {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
              }
          });

    }
  }
}
//var secretKey = "mysupersecret_secretkey!123";
//var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

//SymmetricSecurityKey boink = Encoding.ASCII.GetBytes(secretKey);

////app.UseJwtBearerAuthentication()
//var tokenValidationParameters = new  TokenValidationParameters
//{
//  // The signing key must match!
//  ValidateIssuerSigningKey = true,
//  IssuerSigningKey = signingKey,

//  // Validate the JWT Issuer (iss) claim
//  ValidateIssuer = true,
//  ValidIssuer = "ExampleIssuer",

//  // Validate the JWT Audience (aud) claim
//  ValidateAudience = true,
//  ValidAudience = "ExampleAudience",

//  // Validate the token expiry
//  ValidateLifetime = true,

//  // If you want to allow a certain amount of clock drift, set that here:
//  ClockSkew = TimeSpan.Zero
//};

//app.UseJwtBearerAuthentication( new JwtBearerAuthenticationOptions
//{ 
//  AutomaticAuthenticate = true,
//  AutomaticChallenge = true,
//  TokenValidationParameters = tokenValidationParameters
//});

