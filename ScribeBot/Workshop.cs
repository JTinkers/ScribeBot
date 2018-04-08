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
        public static Dictionary<string, Dictionary<string, string>> GetPackageList()
        {
            NetClient.Headers["User-Agent"] = "ScribeBot - Workshop - List Packages";

            Dictionary<string, Dictionary<string, string>> list = new Dictionary<string, Dictionary<string, string>>();

            JToken[] packages = JArray.Parse(NetClient.DownloadString(Core.WorkshopAddress)).Children().ToArray();

            foreach (JToken package in packages)
            {
                NetClient.Headers["User-Agent"] = "ScribeBot - Workshop - Package Info";

                JToken contentList = JToken.Parse(NetClient.DownloadString((string)package["git_url"]));

                Core.WriteLine(contentList["tree"].Children().Where( x => x["path"].Equals("info.json") ).Select( x => x["url"] ).First().ToString());
            }

            return list;
        }

        /// <summary>
        /// Download a script from workshop.
        /// </summary>
        private static void DownloadPackage(string url)
        {
            NetClient.Headers["User-Agent"] = "ScribeBot - Workshop - Download Package";
            NetClient.DownloadFile(url, $@"Data\Packages\{Path.GetFileName(url)}");
        }
    }
}
