using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Threading;

namespace L03
{
    class Program
    {
        private static DriveService _service;
        private static string _token;
        static void Main(string[] args)
        {
            Initialize();
        }

        static void Initialize()
        {
            string[] scopes = new string[] {
                DriveService.Scope.Drive,
                DriveService.Scope.DriveFile
            };

            DotNetEnv.Env.Load();

            var clientId = Environment.GetEnvironmentVariable("CLIENT_ID");

            var clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                },
                scopes,
                Environment.UserName,
                CancellationToken.None,
                new FileDataStore("Daimto.GoogleDrive.Auth.Store3")
                ).Result;

            _service = new DriveService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });

            _token = credential.Token.AccessToken;

            Console.WriteLine("Token: " + credential.Token.AccessToken + "\n");

            GetMyFiles();
        }

        static void GetMyFiles()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/drive/v3/files?q='root'%20in%20parents");

            request.Credentials = CredentialCache.DefaultCredentials;
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + _token);
            request.PreAuthenticate = true;
            request.UseDefaultCredentials = true;

            using (var response = request.GetResponse())
            {
                using (Stream data = response.GetResponseStream())

                using (var reader = new StreamReader(data))
                {
                    string text = reader.ReadToEnd();

                    var myData = JObject.Parse(text);

                    foreach (var file in myData["files"])
                    {
                        if (file["mimeType"].ToString() != "application/vnd.google-apps.folder")
                        {
                            Console.WriteLine("File name: " + file["name"]);
                        }
                    }
                }
            }
        }
    }
}
