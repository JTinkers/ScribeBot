using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScribeBot
{
    public static class Extensions
    {
        public static void AppendText(this RichTextBox textBox, params object[] args )
        {
            for (int i = 0; i < args.Length; i+=2)
            {
                textBox.AppendText(args[i]);
                textBox.Select(textBox.TextLength - args[i].ToString().Length, args[i].ToString().Length);
                textBox.SelectionColor = (Color)args[i + 1];
            }
        }
    }
}
