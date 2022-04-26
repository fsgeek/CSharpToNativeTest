// Copyright 2018 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// [START drive_quickstart]
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriveQuickstart
{
    class GoogleDriveTest
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/drive-dotnet-quickstart.json
        static string[] Scopes = { DriveService.Scope.Drive, DriveService.Scope.DriveAppdata, DriveService.Scope.DriveFile, DriveService.Scope.DriveMetadata, DriveService.Scope.DriveMetadataReadonly, DriveService.Scope.DrivePhotosReadonly, DriveService.Scope.DriveReadonly, DriveService.Scope.DriveScripts};
        static string ApplicationName = "Indaleko";

        static void Main(string[] args)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "drive",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            Console.WriteLine("DriveService:");
            Console.WriteLine($"\tAbout: {service.About}");

            DrivesResource.ListRequest driveListRequest = service.Drives.List();
            IList<Google.Apis.Drive.v3.Data.Drive> driveList = driveListRequest.Execute().Drives;
            Console.WriteLine($"Google Drives: {driveList.Count}");

            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            Console.WriteLine("Files:");
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    Console.WriteLine("{0} ({1})", file.Name, file.Id);
                }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
            // Console.Read();

            var requestxx = service.Changes.GetStartPageToken();
            var response = requestxx.Execute();
            var savedStartPageToken = response.StartPageTokenValue;

            string pageToken = savedStartPageToken;

            while (pageToken != null)
            {
                var request = service.Changes.List(pageToken);
                request.Spaces = "drive";

                var changes = request.Execute();
                foreach (var change in changes.Changes)
                {
                    Console.WriteLine($"Change found for file: {change.FileId}");
                }
                if (changes.NewStartPageToken != null)
                {
                    savedStartPageToken = changes.NewStartPageToken;
                }
                pageToken = changes.NextPageToken;
            }

            // https://github.com/enestas/google-drive-api-using/blob/master/GoogleDriveExample/GoogleDriveAPI.cs
            var root = service.Files.Get("root").Execute();
            Console.WriteLine($"File ID for root is {root.Id}");
            Console.WriteLine($"File Name for root is {root.Name}");

            Channel channel = new Channel()
            {
                Id = Guid.NewGuid().ToString(),
                Type = "web_hook",
                Address = "address",
                Token = "token",
                Expiration = new DateTimeOffset(DateTime.Now.AddMinutes(10)).ToUnixTimeMilliseconds(),
            };

            var watchRequest = service.Changes.Watch(channel, savedStartPageToken);
            watchRequest.SupportsAllDrives = true;
            watchRequest.DriveId = root.Id;
            watchRequest.RestrictToMyDrive = true;

            watchRequest.Execute();

            Console.WriteLine($"channel is {channel.ToString()}");

        }
    }
}
// [END drive_quickstart]