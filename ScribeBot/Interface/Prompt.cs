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
    public partial class Prompt : Form
    {
        public Prompt()
        {
            InitializeComponent();
        }

        private void promptEntryBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                PromptSubmit.PerformClick();

                e.Handled = true;
            }
        }
    }
}
