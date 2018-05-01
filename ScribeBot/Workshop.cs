using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ScribeBot.Engine.Containers;

namespace ScribeBot
{
    /// <summary>
    /// Class that consists of functions that allow system to fetch packages from a remote repository aswell as download and install them.
    /// </summary>
    public static class Workshop
    {
        private static string workshopAddress = $@"https://api.github.com/repos/jonekcode/ScribeBot-Workshop/contents/";
        private static WebClient netClient = new WebClient();

        /// <summary>
        /// String containing address to the ScribeBot-Workshop script repository.
        /// </summary>
        public static string WorkshopAddress { get => workshopAddress; set => workshopAddress = value; }

        /// <summary>
        /// WebClient used for simple HTTP Requests. Mainly workshop fetching/downloading.
        /// </summary>
        public static WebClient NetClient { get => netClient; set => netClient = value; }

        /// <summary>
        /// Get list of installed packages.
        /// </summary>
        /// <returns>List of installed packages.</returns>
        public static Package[] GetInstalled()
        {
            List<Package> packages = new List<Package>();

            Directory.GetFiles($@"Data\Packages\", "*.zip").ToList().ForEach(x => packages.Add(new Package(x)));

            return packages.ToArray();
        }

        /// <summary>
        /// Fetch workshop scripts.
        /// </summary>
        /// <returns>List of downloadable packages.</returns>
        public static Dictionary<string, string> GetPackageList()
        {
            Core.WriteLine(new ColorContainer(89, 73, 163), "Fetching workshop list.", new ColorContainer(177, 31, 41), "\nWARNING: Using this function too often might get you temporarily IP banned from Github API!");

            Dictionary<string, string> list = new Dictionary<string, string>();

            NetClient.Headers["User-Agent"] = "ScribeBot - Workshop Content Fetching";

            IEnumerable<JToken> tokens = JArray.Parse(NetClient.DownloadString(WorkshopAddress)).Children();
            tokens = tokens.Where(x => !x["name"].ToString().Equals("README.md")).ToList();
            tokens.ToList().ForEach(x => list[Path.GetFileNameWithoutExtension((string)x["name"])] = (string)x["download_url"]);

            Core.WriteLine(new ColorContainer(0, 131, 63), "Workshop list fetched. Happy downloading!");

            return list;
        }

        /// <summary>
        /// Download a script from workshop.
        /// </summary>
        public static void DownloadPackage(string url, string name = "package")
        {
            Core.WriteLine(new ColorContainer(89, 73, 163), $@"Downloading workshop package: {name}");

            if (File.Exists($@"Data\Packages\{name}.zip"))
            {
                Core.WriteLine(new ColorContainer(177, 31, 41), "A package of this name already exists!");
                return;
            }

            NetClient.Headers["User-Agent"] = "ScribeBot - Workshop - Download Package";
            NetClient.DownloadFile(url, $@"Data\Packages\{name}.zip");

            Core.WriteLine(new ColorContainer(89, 73, 163), $@"Downloaded workshop package: {name}");
        }

        /// <summary>
        /// Create a .zip package from a supplied folder.
        /// </summary>
        /// <param name="folderPath">Path to folder to turn into package.</param>
        /// <param name="info">Unformatted table containing data that later will be turned to info.json.</param>
        public static void CreatePackage(string folderPath, Dictionary<string, string> info)
        {
            string json = JsonConvert.SerializeObject(info, Formatting.Indented);
            File.WriteAllText($@"{folderPath}\info.json", json);

            List<string> filePaths = new List<string>();

            Directory.GetFiles(folderPath).ToList().ForEach(x => filePaths.Add(x));

            Package.Create(Path.GetFileName(folderPath), filePaths.ToArray());
        }
    }
}
