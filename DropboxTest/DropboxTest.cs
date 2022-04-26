using System;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Files.Routes;
using Indaleko.Windows;
using System.Diagnostics;

// Note this code is from the dropbox tutorial at https://www.dropbox.com/developers/documentation/dotnet#tutorial
class Program
{
    static void Main(string[] args)
    {
        var task = Task.Run((Func<Task>)Program.Run);
        task.Wait();
    }

    static async Task Run()
    {
        // TODO: add this to somewhere safe, like the local registry, or a local file from which this can be loaded.
        RegistryData dropboxRegData = new RegistryData("Dropbox");

        Debug.Assert(dropboxRegData.ContainsKey("ApiKey"), "No API key registered for Dropbox");

        using (var dbx = new DropboxClient(dropboxRegData["ApiKey"].ToString()))
        {
            var full = await dbx.Users.GetCurrentAccountAsync();

            Console.WriteLine("Account id    : {0}", full.AccountId);
            Console.WriteLine("Country       : {0}", full.Country);
            Console.WriteLine("Email         : {0}", full.Email);
            Console.WriteLine("Is paired     : {0}", full.IsPaired ? "Yes" : "No");
            Console.WriteLine("Locale        : {0}", full.Locale);
            Console.WriteLine("Name");
            Console.WriteLine("  Display  : {0}", full.Name.DisplayName);
            Console.WriteLine("  Familiar : {0}", full.Name.FamiliarName);
            Console.WriteLine("  Given    : {0}", full.Name.GivenName);
            Console.WriteLine("  Surname  : {0}", full.Name.Surname);
            Console.WriteLine("Referral link : {0}", full.ReferralLink);

            if (full.Team != null)
            {
                Console.WriteLine("Team");
                Console.WriteLine("  Id   : {0}", full.Team.Id);
                Console.WriteLine("  Name : {0}", full.Team.Name);
            }
            else
            {
                Console.WriteLine("Team - None");
            }

            // Task<ListFolderLongpollResult> pollResult = Dropbox.Api.Files.Routes.ListFolderLongpollAsync("");
            // Dropbox.Api.Files.Routes.FilesUserRoutes route = new Dropbox.Api.Files.Routes.FilesUserRoutes()
            ListFolderArg listFolderArg = new ListFolderArg("", true, true, true, true);
            string cursor = dbx.Files.ListFolderGetLatestCursorAsync(listFolderArg).Result.Cursor;

            Console.WriteLine($"Lastest Cursor is: {cursor}");
            Console.WriteLine("Now begin monitoring");

            while (true)
            {
                ListFolderLongpollResult result = dbx.Files.ListFolderLongpollAsync(cursor).Result;

                if (null != result)
                {
                    Console.WriteLine("Result is: ");
                    Console.WriteLine($"\tBackoff is: {result.Backoff}");
                    Console.WriteLine($"\tResult is {result.Changes}");

                    if (result.Changes)
                    {
                        ListFolderResult delta;

                        do
                        {
                            delta = dbx.Files.ListFolderContinueAsync(cursor).Result;

                            foreach (var entry in delta.Entries)
                            {
                                Console.WriteLine(entry.PathDisplay);

                                if (entry.IsFile)
                                {
                                    GetMetadataArg mdarg = new GetMetadataArg(entry.PathDisplay, true, true, true);
                                    var md = dbx.Files.GetMetadataAsync(mdarg).Result;
                                    Console.WriteLine("\tMetadata");
                                    Console.WriteLine($"\t       Name: {md.Name}");
                                    Console.WriteLine($"\t    Deleted: {md.AsDeleted}");
                                    Console.WriteLine($"\t       Type: {md.GetType().Name}");
                                    Console.WriteLine($"\t       Hash: {md.GetHashCode()}");
                                    Console.WriteLine($"\t         Id: {md.AsFile.Id}");
                                    Console.WriteLine($"\t       Size: {md.AsFile.Size}");
                                    Console.WriteLine($"\tContentHash: {md.AsFile.ContentHash}");
                                    Console.WriteLine($"\t   Modified: {md.AsFile.ClientModified}");
                                }
                            }

                            cursor = delta.Cursor;
                        }
                        while (delta.HasMore);
                    }
                }
            }
        }
    }
}