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
using ScribeBot.Engine.Containers;

//TO-DO: Remake this entire class
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

            try
            {
                ZipArchive archive = ZipFile.Open($@"Data\Packages\{packageName}.zip", ZipArchiveMode.Create);

                filePaths.ToList().ForEach(x => archive.CreateEntryFromFile(x, Path.GetFileName(x)));

                archive.Dispose();

                Core.WriteLine(new ColorContainer(0, 131, 63), $@"Package {packageName}.zip created!");
            }
            catch( Exception e )
            {
                Core.WriteLine(new ColorContainer(177, 31, 41), e.Message);
            }

            return new Package($@"Data\Packages\{packageName}.zip"); ;
        }

        /// <summary>
        /// Returns package info stored inside info.json file.
        /// </summary>
        /// <returns>Package name, authors, description etc.</returns>
        public Dictionary<string, string> GetInfo()
        {
            ZipArchive archive = ZipFile.OpenRead(ArchivePath);

            StreamReader reader = new StreamReader(archive.GetEntry("info.json").Open());

            string contents = reader.ReadToEnd();

            //Neccessary force-disposal and close to preven IO exceptions.
            reader.Dispose();
            archive.Dispose();

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(contents);
        }
        
        /// <summary>
        /// Read contents of a specific file entry inside a package.
        /// </summary>
        /// <param name="fileName">Name of entry to get contents of.</param>
        /// <returns>Contents as a string.</returns>
        public string ReadFileContents(string fileName)
        {
            ZipArchive archive = ZipFile.OpenRead(ArchivePath);

            StreamReader reader = new StreamReader(archive.GetEntry(fileName).Open());

            string contents = reader.ReadToEnd();

            reader.Dispose();
            archive.Dispose();

            return contents;
        }

        /// <summary>
        /// Write content to a specific file entry inside a package.
        /// </summary>
        /// <param name="fileName">Name of entry to set contents of.</param>
        /// <param name="contents">Contents to write.</param>
        public void WriteFileContents(string fileName, string contents)
        {
            ZipArchive archive = ZipFile.Open(ArchivePath, ZipArchiveMode.Update);

            archive.GetEntry(fileName).Delete();
            archive.CreateEntry(fileName);

            StreamWriter writer = new StreamWriter(archive.GetEntry(fileName).Open());

            writer.Write(contents);

            writer.Dispose();
            archive.Dispose();
        }

        /// <summary>
        /// Execute a package at specified entry point (defined inside info.json).
        /// </summary>
        /// <param name="silent">Defines whether console shouldn't output the executed code.</param>
        public void Run(bool silent = true)
        {
            Dictionary<string, string> info = GetInfo();

            Scripter.Execute(ReadFileContents(info["EntryPoint"]), silent);
        }

        /// <summary>
        /// Get files inside a package.
        /// </summary>
        /// <returns>Entries as a ZipArchiveEntry array.</returns>
        public ZipArchiveEntry[] GetFiles()
        {
            ZipArchive archive = ZipFile.OpenRead(ArchivePath);

            ZipArchiveEntry[] entries = archive.Entries.ToArray();

            archive.Dispose();

            return entries;
        }
    }
}
