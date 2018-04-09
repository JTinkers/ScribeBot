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

namespace ScribeBot
{
    /// <summary>
    /// Class that consists of functions that allow system to fetch packages from a remote repository aswell as download and install them.
    /// </summary>
    public static class Workshop
    {
        private static WebClient netClient = new WebClient();

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

            Directory.GetFiles($@"Data\Packages\", "*.sbpack").ToList().ForEach(x => packages.Add(new Package(x)));

            return packages.ToArray();
        }

        /// <summary>
        /// Fetch workshop scripts.
        /// </summary>
        /// <returns>List of downloadable packages.</returns>
        public static Dictionary<string, string> GetPackageList()
        {
            Core.WriteLine(Core.Colors["Purple"], "Fetching workshop list.", Core.Colors["Red"], "\nWARNING: Using this function too often might get you temporarily IP banned from Github API!");

            NetClient.Headers["User-Agent"] = "ScribeBot - Workshop Content Fetching";

            JArray parsed = JArray.Parse(NetClient.DownloadString(Core.WorkshopAddress));

            Dictionary<string, string> list = new Dictionary<string, string>();

            parsed.Children().Where(x => !x["name"].ToString().Equals( "README.md" )).ToList().ForEach(x => list[Path.GetFileNameWithoutExtension( (string)x["name"] )] = (string)x["download_url"]);

            Core.WriteLine(Core.Colors["Purple"], "Workshop list fetched. Happy downloading!");

            return list;
        }

        /// <summary>
        /// Download a script from workshop.
        /// </summary>
        public static void DownloadPackage(string url, string name = "package")
        {
            Core.WriteLine(Core.Colors["Purple"], $@"Downloading workshop package: {name}");

            if (File.Exists($@"Data\Packages\{name}.sbpack"))
            {
                Core.WriteLine("A package of this name already exists!");
                return;
            }

            NetClient.Headers["User-Agent"] = "ScribeBot - Workshop - Download Package";
            NetClient.DownloadFile(url, $@"Data\Packages\{name}.sbpack");

            Core.WriteLine(Core.Colors["Purple"], $@"Downloaded workshop package: {name}");
        }
    }
}
