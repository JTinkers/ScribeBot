using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Scribe.Interface
{
    class Window : Form
    {
        private TextBox output;
        private TextBox input;
        private TableLayoutPanel layoutPanel;
        private Panel leftPanel;
        private TabControl rightPanel;
        private TabPage settingsPage;
        private TabPage scriptsPage;

        public TextBox Input { get => input; private set => input = value; }
        public TextBox Output { get => output; private set => output = value; }
        public TableLayoutPanel LayoutPanel { get => layoutPanel; set => layoutPanel = value; }
        public Panel LeftPanel { get => leftPanel; set => leftPanel = value; }
        public TabControl RightPanel { get => rightPanel; set => rightPanel = value; }
        public TabPage SettingsPage { get => settingsPage; set => settingsPage = value; }
        public TabPage ScriptsPage { get => scriptsPage; set => scriptsPage = value; }

        public Window()
        {
            Width = 800;
            Height = 600;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            CenterToScreen();
            Padding = new Padding(4);
            MaximizeBox = false;
            Text = "Scribe";

            LayoutPanel = new TableLayoutPanel();
            LayoutPanel.Dock = DockStyle.Fill;
            LayoutPanel.ColumnCount = 2;
            LayoutPanel.RowCount = 1;
            LayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            LayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            LayoutPanel.Parent = this;

            //Left Panel - Console I/O
            LeftPanel = new Panel();
            LeftPanel.Dock = DockStyle.Fill;
            LayoutPanel.Controls.Add(LeftPanel, 0, 0);

            Output = new TextBox();
            Output.Dock = DockStyle.Fill;
            Output.Multiline = true;
            Output.ReadOnly = true;
            Output.Parent = LeftPanel;
            Output.BackColor = Color.WhiteSmoke;
            Output.BorderStyle = BorderStyle.FixedSingle;

            Input = new TextBox();
            Input.Dock = DockStyle.Bottom;
            Input.Parent = LeftPanel;
            Input.BackColor = Color.WhiteSmoke;
            Input.BorderStyle = BorderStyle.FixedSingle;

            //Right Panel - Tabs - Settings, Script Management
            RightPanel = new TabControl();
            RightPanel.Dock = DockStyle.Fill;
            LayoutPanel.Controls.Add(RightPanel, 1, 0);

            SettingsPage = new TabPage("Settings");
            SettingsPage.Dock = DockStyle.Fill;
            SettingsPage.Parent = RightPanel;
            SettingsPage.BackColor = Color.WhiteSmoke;
            SettingsPage.BorderStyle = BorderStyle.FixedSingle;

            ScriptsPage = new TabPage("Scripts");
            ScriptsPage.Dock = DockStyle.Fill;
            ScriptsPage.Parent = RightPanel;
            ScriptsPage.BackColor = Color.WhiteSmoke;
            ScriptsPage.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
