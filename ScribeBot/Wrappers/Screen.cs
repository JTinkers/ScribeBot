using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Forms = System.Windows.Forms;

namespace ScribeBot.Wrappers
{
    /// <summary>
    /// Wrapper containing functionality related to screen.
    /// </summary>
    [MoonSharpUserData]
    static class Screen
    {
        /// <summary>
        /// Take a screenshot and save it to a given path.
        /// </summary>
        /// <param name="path">Save path.</param>
        public static void Capture(string path)
        {
            int w, h;

            Forms.Screen[] screens = Forms.Screen.AllScreens;

            w = screens.ToList().Sum(i => i.Bounds.Width);
            h = screens.ToList().Max(i => i.Bounds.Height);

            Bitmap screen = new Bitmap( w, h, PixelFormat.Format32bppArgb );
            Graphics gfx = Graphics.FromImage(screen);

            gfx.CopyFromScreen(0, 0, 0, 0, new Size(w, h), CopyPixelOperation.SourceCopy);

            try
            {
                if (String.IsNullOrEmpty(path))
                    path = $@"{DateTime.Today.Day}_{DateTime.Today.Month}-{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.png";

                screen.Save($@"Data/User/{path}", ImageFormat.Png);
            }
            catch(Exception e)
            {
                Scripter.ExecuteString($"error('Invalid path for screen.capture()! [Data/User/{path}]')");
            }

            gfx.Dispose();
            screen.Dispose();
        }

        public static Types.Size GetSize()
        {
            int w, h;

            Forms.Screen[] screens = Forms.Screen.AllScreens;

            w = screens.ToList().Sum(x => x.Bounds.Width);
            h = screens.ToList().Max(i => i.Bounds.Height);

            return new Types.Size() { Width = w, Height = h };
        }
    }
}
