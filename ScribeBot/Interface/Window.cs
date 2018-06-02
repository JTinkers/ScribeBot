using Newtonsoft.Json.Linq;
using ScribeBot.Engine.Containers;
using ScribeBot.Engine.Wrappers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScribeBot.Interface
{
    /// <summary>
    /// Main interface window.
    /// </summary>
    public partial class Window : Form
    {
        private List<string> commands = new List<string>();
        public Window()
        {
            InitializeComponent();

            InfoVersion.Text = Core.Version;

            ConsoleOutput.Font = new System.Drawing.Font(Core.Fonts.Families[0], 10f);

            Package[] installedPackages = Workshop.GetInstalled();

            installedPackages.ToList().ForEach(x =>
            {
                Dictionary<string, string> packageInfo = x.GetInfo();

                PackageInfo p = new PackageInfo();
                p.NameLabel.Text = packageInfo["Name"];
                p.AuthorLabel.Text = packageInfo["Authors"];
                p.DescLabel.Text = packageInfo["Description"];
                p.Package = x;

                p.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;

                InstalledPackagesList.Controls.Add(p);

                p.RunButton.Click += (o, e) =>
                {
                    x.Run(true);
                };
            });

            var hoverColor = new ColorContainer(0, 0, 0);
            var cursorPos = new PointContainer(0, 0);

            var timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += (s, a) =>
            {
                if (this == null)
                    return;

                cursorPos = InputWrapper.GetCursorPos();
                hoverColor = ScreenWrapper.GetPixels(cursorPos.X, cursorPos.Y, 1, 1)[0][0];
                
                Invoke(new Action(() =>
                {
                    ColorDisplay.Text = $"R: {hoverColor.R} G: {hoverColor.G} B: {hoverColor.B}";
                    CursorPosDisplay.Text = $"X: {cursorPos.X} Y: {cursorPos.Y}";
                }));
            };
            timer.Start();
        }

        private void scriptStop_Click(object sender, EventArgs e)
        {
            Scripter.Stop();
        }

        private void consoleRun_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ConsoleInput.Text))
                return;

            Scripter.InjectLine(ConsoleInput.Text);


            commands.Insert(0, ConsoleInput.Text);

            ConsoleInput.Text = "";
        }

        private void consoleInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ConsoleRun.PerformClick();
                e.Handled = true;
            }
        }

        private void consoleInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                int i = commands.FindIndex(x => x == ConsoleInput.Text) + 1;

                if (commands.Count > 0 && i < commands.Count)
                    ConsoleInput.Text = commands[i];

                e.Handled = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                int i = commands.FindIndex(x => x == ConsoleInput.Text) - 1;

                if (commands.Count > 0 && i >= 0)
                    ConsoleInput.Text = commands[i];

                e.Handled = true;
            }
        }

        private void consoleOutput_TextChanged(object sender, EventArgs e)
        {
            ConsoleOutput.ScrollToCaret();
        }

        private void consoleClearButton_Click(object sender, EventArgs e)
        {
            ConsoleOutput.Clear();
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            Scripter.Stop();

            Core.DumpLog();

            if (Core.Editor.InvokeRequired)
            {
                Core.Editor.BeginInvoke(new Action(() =>
                {
                    Core.Editor.Close();
                }));
            }
        }

        private void workshopFetchButton_Click(object sender, EventArgs e)
        {
            WorkshopFetchButton.Text = "Fetching..";
            WorkshopFetchButton.Enabled = false;

            BrowserPackageList.Controls.Clear();

            Task.Run(() =>
            {
                Dictionary<string, string> packages = Workshop.GetPackageList();

                Invoke(new Action(() =>
                {
                    WorkshopFetchButton.Text = "Fetch";
                    WorkshopFetchButton.Enabled = true;

                    foreach (KeyValuePair<string, string> package in packages)
                    {
                        PackageInfoMinimal p = new PackageInfoMinimal();
                        p.NameLabel.Text = package.Key;

                        p.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;

                        BrowserPackageList.Controls.Add(p);

                        p.DownloadButton.Click += (o, ce) =>
                        {
                            p.DownloadButton.Text = "Downloading..";
                            p.DownloadButton.Enabled = false;

                            WorkshopFetchButton.Enabled = false;

                            Workshop.DownloadPackage(package.Value, package.Key);

                            p.DownloadButton.Text = "Download";
                            p.DownloadButton.Enabled = true;

                            WorkshopFetchButton.Text = "Fetch";
                            WorkshopFetchButton.Enabled = true;

                            InstalledPackagesList.Controls.Clear();

                            Workshop.GetInstalled().ToList().ForEach(x =>
                            {
                                Dictionary<string, string> packageInfo = x.GetInfo();

                                PackageInfo i = new PackageInfo();
                                i.NameLabel.Text = packageInfo["Name"];
                                i.AuthorLabel.Text = packageInfo["Authors"];
                                i.DescLabel.Text = packageInfo["Description"];
                                i.Package = x;

                                i.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;

                                InstalledPackagesList.Controls.Add(i);

                                i.RunButton.Click += (ob, ed) =>
                                {
                                    x.Run(true);
                                };
                            });
                        };
                    }
                }));
            });
        }

        private void packageSelectFolder_Click(object sender, EventArgs e)
        {
            //We need separate thread for this, one with STA state
            //This will be a crude but effective workaround
            Thread fileDialogThread = new Thread(() =>
            {
                PackageFolderSelectDialog.ShowDialog();

                Thread.CurrentThread.Abort();
            });

            fileDialogThread.TrySetApartmentState(ApartmentState.STA);
            fileDialogThread.Start();
            fileDialogThread.Join();

            if (!String.IsNullOrEmpty(PackageFolderSelectDialog.SelectedPath))
            {
                PackageCreateFolder.Enabled = true;
            }
        }

        private void packageCreateFolder_Click(object sender, EventArgs e)
        {
            List<TextBox> fields = new List<TextBox>() { PackageName, PackageAuthors, PackageDescription, PackageEntryPoint };

            if (fields.All(x => !String.IsNullOrEmpty(x.Text)))
            {
                Dictionary<string, string> info = new Dictionary<string, string>()
                {
                    ["Name"] = PackageName.Text,
                    ["Authors"] = PackageAuthors.Text,
                    ["Description"] = PackageDescription.Text,
                    ["Contact"] = "",
                    ["EntryPoint"] = PackageEntryPoint.Text
                };

                Workshop.CreatePackage(PackageFolderSelectDialog.SelectedPath, info);

                InstalledPackagesList.Controls.Clear();

                Workshop.GetInstalled().ToList().ForEach(x =>
                {
                    Dictionary<string, string> packageInfo = x.GetInfo();

                    PackageInfo i = new PackageInfo();
                    i.NameLabel.Text = packageInfo["Name"];
                    i.AuthorLabel.Text = packageInfo["Authors"];
                    i.DescLabel.Text = packageInfo["Description"];
                    i.Package = x;

                    i.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;

                    InstalledPackagesList.Controls.Add(i);

                    i.RunButton.Click += (ob, ed) =>
                    {
                        x.Run(true);
                    };
                });
            }
            else
                Core.WriteLine(new ColorContainer(177, 31, 41), "Fill all fields before creating a package!");
        }

        private void openPackagesFolderButton_Click(object sender, EventArgs e)
        {
            Process.Start($@"{Path.GetDirectoryName(Application.ExecutablePath)}\Data\Packages");
        }

        private void checkUpdate_Click(object sender, EventArgs e)
        {
            Core.WriteLine(new ColorContainer(89, 73, 163), "Checking for updates.", new ColorContainer(177, 31, 41), "\nWARNING: Using this function too often might get you temporarily IP banned from Github API!");

            using (var client = new WebClient())
            {
                client.Headers["User-Agent"] = "ScribeBot - Update Fetching";

                IEnumerable<JToken> tokens = JArray.Parse(client.DownloadString(Core.ReleaseAddress)).Children();

                var latestVersion = float.Parse(Regex.Match(tokens.First()["tag_name"].ToString(), @"\d+[.]\d+").Value);
                var currentVersion = float.Parse(Regex.Match(Core.Version, @"\d+[.]\d+").Value);

                if (latestVersion > currentVersion)
                {
                    Core.WriteLine(new ColorContainer(89, 73, 163), $"New version is available: {tokens.First()["tag_name"]}.\nClick 'Update' to download and install the update.\nData folder will be backed up before the process.");
                    downloadUpdate.Enabled = true;
                }
                else
                    Core.WriteLine(new ColorContainer(89, 73, 163), "You have the latest version. No update is neccessary.");
            }
        }

        private void downloadUpdate_Click(object sender, EventArgs e)
        {
            if(!File.Exists($"Updater {Core.Version}.exe") && File.Exists("Updater.exe"))
                File.Copy("Updater.exe", $"Updater {Core.Version}.exe");

            Thread.Sleep(1000);

            Process.Start($"Updater {Core.Version}.exe");

            Core.Close();
        }
    }
}
