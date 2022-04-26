using Indaleko.Windows;
class RegTest
{
    static void Main(string[] args)
    {
        RegistryData dropboxData = new RegistryData("Dropbox");

        Console.WriteLine("Test started");

        if (!dropboxData.ContainsKey("ApiKey"))
        {
            Console.WriteLine("API key for Service is not present in the registry");
        }

        foreach (var key in dropboxData.GetValues())
        {
            Console.WriteLine($"{key.Key} : {key.Value}");
        }

        Console.WriteLine("Test ended");
    }
}