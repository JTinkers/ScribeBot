using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        public Window()
        {
            InitializeComponent();

            ConsoleOutput.Font = new Font(Core.Fonts.Families[0], 10f);

            Package[] installedPackages = Workshop.GetInstalled();
            
            installedPackages.ToList().ForEach(x =>
            {
                Dictionary<string, string> packageInfo = x.GetInfo();

                PackageInfo p = new PackageInfo();
                p.NameLabel.Text = packageInfo["Name"];
                p.AuthorLabel.Text = packageInfo["Authors"];
                p.DescLabel.Text = packageInfo["Description"];

                p.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;

                InstalledPackagesList.Controls.Add(p);

                p.RunButton.Click += (o, e) =>
                {
                    x.Run(AsyncCheckbox.Checked, true);
                };
            });
        }

        private void scriptStop_Click(object sender, EventArgs e)
        {
            Scripter.ExecuteCode("lua_pcall( L, 0, LUA_MULTRET, 0 )");
        }

        private void consoleRun_Click(object sender, EventArgs e)
        {
            Scripter.ExecuteCode(ConsoleInput.Text, AsyncStringCheck.Checked, false);
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
            Core.DumpLog();
        }

        private void workshopFetchButton_Click(object sender, EventArgs e)
        {
            WorkshopFetchButton.Text = "Fetching..";
            WorkshopFetchButton.Enabled = false;

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

                            Package[] installedPackages = Workshop.GetInstalled();

                            InstalledPackagesList.Controls.Clear();

                            installedPackages.ToList().ForEach(x =>
                            {
                                Dictionary<string, string> packageInfo = x.GetInfo();

                                PackageInfo i = new PackageInfo();
                                i.NameLabel.Text = packageInfo["Name"];
                                i.AuthorLabel.Text = packageInfo["Authors"];
                                i.DescLabel.Text = packageInfo["Description"];

                                i.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;

                                InstalledPackagesList.Controls.Add(i);

                                i.RunButton.Click += (ob, ed) =>
                                {
                                    x.Run(AsyncCheckbox.Checked, true);
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

            if( !String.IsNullOrEmpty( PackageFolderSelectDialog.SelectedPath ) )
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
                    ["EntryPoint"] = PackageEntryPoint.Text
                };

                Workshop.CreatePackage(PackageFolderSelectDialog.SelectedPath, info);
            }
            else
                Core.WriteLine(Core.Colors["Red"], "Fill all fields before creating a package!");
        }
    }
}
