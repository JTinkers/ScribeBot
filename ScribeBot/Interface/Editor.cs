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
    public partial class Editor : Form
    {
        private Package package;

        public Package Package { get => package; set => package = value; }

        public Editor(Package import)
        {
            package = import;

            InitializeComponent();

            package.GetEntries().ToList().ForEach(x => EditorFileTree.Nodes.Add(new TreeNode(x.Name)));
        }

        private void editorFileTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            StreamReader reader = new StreamReader(ZipFile.OpenRead(Package.ArchivePath).GetEntry(e.Node.FullPath).Open());

            TabPage fileTab = new TabPage();
            fileTab.Text = e.Node.FullPath;

            FileTabControl.Controls.Add(fileTab);

            TextBox code = new TextBox();

            fileTab.Controls.Add(code);

            code.Dock = DockStyle.Fill;
            code.BorderStyle = BorderStyle.None;
            code.Margin = new Padding(0);
            code.Multiline = true;
            code.Text = reader.ReadToEnd();
        }

        private void packageRun_Click(object sender, EventArgs e)
        {
            package.Run(false, true);
        }
    }
}
