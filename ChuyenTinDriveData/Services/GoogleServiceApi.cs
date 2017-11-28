using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Plus.v1;

namespace ChuyenTinDriveData.Services
{
    public static class GoogleServiceApi
    {
        /// <summary>Retrieves the Client Configuration from the server path.</summary>
        /// <returns>Client secrets that can be used for API calls.</returns>
        public static GoogleClientSecrets GetClientConfiguration()
        {
            using (var stream = new FileStream("~/App_Data/client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                return GoogleClientSecrets.Load(stream);
            }
        }

        /// <summary>
        /// Gets a Google+ service object for making authorized API calls to Google+ endpoints.
        /// </summary>
        /// <param name="credentials">The OAuth 2 credentials to use to authorize the client.</param>
        /// <returns>
        /// A <see cref="PlusService">PlusService</see>"/> object for API calls authorized to the
        /// user who corresponds with the credentials.
        /// </returns>
        public static PlusService GetPlusService(TokenResponse credentials)
        {
            IAuthorizationCodeFlow flow =
                new GoogleAuthorizationCodeFlow(
                    new GoogleAuthorizationCodeFlow.Initializer
                    {
                        ClientSecrets = GetClientConfiguration().Secrets,
                        Scopes = new[] { PlusService.Scope.PlusLogin }
                    });

            UserCredential credential = new UserCredential(flow, "me", credentials);

            return new PlusService(
                new Google.Apis.Services.BaseClientService.Initializer()
                {
                    ApplicationName = "ChuyenTinServiceAccount",
                    HttpClientInitializer = credential
                });
        }
    }
}