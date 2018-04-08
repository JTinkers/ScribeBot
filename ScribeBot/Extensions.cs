using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScribeBot
{
    /// <summary>
    /// Class containing exxtensions for a variety of other classes
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Append RichTextBox with a multi-color text.
        /// </summary>
        /// <param name="textBox">RichTextBox to append to.</param>
        /// <param name="args">Strings prepended by colors ex: Color.Red, "text", Color.Yellow, "text2".</param>
        public static void AppendText(this RichTextBox textBox, params object[] args )
        {
            for (int i = 0; i < args.Length; i+=2)
            {
                textBox.AppendText((String)args[i+1]);
                textBox.Select(Math.Max(textBox.TextLength - args[i + 1].ToString().Length, 0), args[i + 1].ToString().Length);
                textBox.SelectionColor = (Color)args[i];
            }
        }
    }
}
