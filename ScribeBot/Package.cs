using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ScribeBot
{
    /// <summary>
    /// Class that contains script files along with author's data.
    /// </summary>
    public class Package
    {
        private string archivePath;

        /// <summary>
        /// Path to the archive that the instance of this class represents.
        /// </summary>
        public string ArchivePath { get => archivePath; set => archivePath = value; }

        /// <summary>
        /// Creates a package with given archive path.
        /// </summary>
        /// <param name="path">Path to archive.</param>
        public Package( string path )
        {
            archivePath = path;
        }

        /// <summary>
        /// Creates a package (zip archive) using supplied files.
        /// </summary>
        /// <param name="packageName">Name of file to create.</param>
        /// <param name="filePaths">Array of paths to files to insert into archive.</param>
        /// <returns>A generated package.</returns>
        public static Package Create(string packageName, string[] filePaths)
        {
            packageName = packageName.ToLower();

            //Open a filestream
            ZipArchive archive = ZipFile.Open($@"Data\Packages\{packageName}.sbpack", ZipArchiveMode.Create);

            //Create entries for every file
            filePaths.ToList().ForEach(x => archive.CreateEntryFromFile(x, Path.GetFileName(x)));

            archive.Dispose();

            return new Package($@"Data\Packages\{packageName}.sbpack"); ;
        }

        /// <summary>
        /// Returns package info stored inside info.json file.
        /// </summary>
        /// <returns>Package name, authors, description etc.</returns>
        public Dictionary<string, string> GetInfo()
        {
            StreamReader reader = new StreamReader( ZipFile.OpenRead( ArchivePath ).GetEntry( "info.json" ).Open() );

            string fileData = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(fileData);
        }

        /// <summary>
        /// Execute a package at specified entry point (defined inside info.json).
        /// </summary>
        /// <param name="asynchronous">Whether it should be executed asynchronously or not.</param>
        /// <param name="silent">Defines whether console shouldn't output the executed code.</param>
        public void Run( bool asynchronous = true, bool silent = true )
        {
            Dictionary<string, string> info = GetInfo();

            StreamReader reader = new StreamReader(ZipFile.OpenRead(ArchivePath).GetEntry(info["EntryPoint"]).Open());

            string fileData = reader.ReadToEnd();

            Scripter.ExecuteCode(fileData, asynchronous, silent);
        }
    }
}
