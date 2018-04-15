using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Remake this
namespace ScribeBot.Interface
{
    public partial class PackageEditor : Form
    {
        private Package package;

        public Package Package { get => package; set => package = value; }

        public PackageEditor()
        {
            InitializeComponent();
        }

        public void OpenPackage(Package import)
        {
            package = import;

            FileTabControl.Controls.Clear();

            FileTree.Nodes.Clear();

            package.GetFiles().ToList().ForEach(x => FileTree.Nodes.Add(new TreeNode(x.Name)));

            Show();
        }

        private void editorFileTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            StreamReader reader = new StreamReader(Package.GetFileStream(e.Node.FullPath, ZipArchiveMode.Read));

            foreach (Control control in FileTabControl.Controls)
            {
                if (control.Text == e.Node.FullPath)
                    return;
            }

            TabPage fileTab = new TabPage();
            fileTab.Text = e.Node.FullPath;
            FileTabControl.Controls.Add(fileTab);

            TextBox code = new TextBox();
            code.Dock = DockStyle.Fill;
            code.BorderStyle = BorderStyle.None;
            code.Margin = new Padding(0);
            code.Multiline = true;
            code.Text = reader.ReadToEnd();
            code.AcceptsTab = true;
            code.Font = new Font(Core.Fonts.Families[0], 10f);
            fileTab.Controls.Add(code);
        }

        private void packageRun_Click(object sender, EventArgs e)
        {
            Core.MainWindow.Invoke(new Action(() => Core.MainWindow.Activate()));

            package.Run(true, true);
        }

        private void PackageEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();

            e.Cancel = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
