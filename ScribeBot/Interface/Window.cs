using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            Task.Run(() =>
            {
                Workshop.GetPackageList();

                Invoke(new Action(() =>
                {
                    WorkshopFetchButton.Text = "Fetch";
                }));
            });
        }
    }
}
