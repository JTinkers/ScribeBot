using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using AImageFormat = System.Drawing.Imaging.ImageFormat;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using MoonSharp.Interpreter;
using ScribeBot.Engine.Containers;

namespace ScribeBot.Engine.Wrappers
{
    /// <summary>
    /// Wrapper containing functionality related to screen.
    /// </summary>
    [MoonSharpUserData]
    static class ScreenWrapper
    {
        /// <summary>
        /// Attempts to read text off of screen area using Google's Tesseract.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns>The predicted text</returns>
        public static string Recognize(int x, int y, int w, int h)
        {
            var engine = new TesseractEngine(@"Library Data/Tessdata", "eng", EngineMode.Default);

            var image = Native.API.CopyScreenArea(x, y, w, h);

            return engine.Process(image).GetText();
        }

		public static string Recognize(int x, int y, int w, int h, float scale = 1)
		{
			var engine = new TesseractEngine(@"Library Data/Tessdata", "eng", EngineMode.Default);

			var image = Native.API.CopyScreenArea(x, y, w, h);

			var scaled = new Bitmap(image, new Size((int)(image.Width * scale), (int)(image.Height * scale)));

			return engine.Process(scaled).GetText();
		}

		/// <summary>
		/// Get an area of screen as an array of colors.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <returns>2D array of pixel colors.</returns>
		public static ColorContainer[][] GetPixels(int x, int y, int w, int h)
        {
            Bitmap pixels = Native.API.CopyScreenArea(x, y, w, h);

            //Has to be array of arrays rather than 2D array - silly conversion
            ColorContainer[][] colors = new ColorContainer[w][];
            for (int i = 0; i < w; i++)
            {
                colors[i] = new ColorContainer[h];
            }

            BitmapData data = pixels.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] values = new byte[data.Stride * h];

            Marshal.Copy(data.Scan0, values, 0, data.Stride * h);

            pixels.UnlockBits(data);

            for(int j = 0; j < data.Height; j++)
            {
                for(int i = 0; i < data.Width; i++)
                {
                    colors[i][j] = new ColorContainer(values[j * data.Width * 4 + i * 4 + 2], values[j * data.Width * 4 + i * 4 + 1], values[j * data.Width * 4 + i * 4]);
                }
            }

            return colors;
        }

        /// <summary>
        /// Take a screenshot and save it to a given path.
        /// </summary>
        /// <param name="path">Savepath.</param>
        public static void Capture(string path)
        {
            int w, h;

            Screen[] screens = Screen.AllScreens;

            w = screens.ToList().Sum(i => i.Bounds.Width);
            h = screens.ToList().Max(i => i.Bounds.Height);

            Bitmap screen = new Bitmap( w, h, PixelFormat.Format32bppArgb );

            Graphics gfx = Graphics.FromImage(screen);

            gfx.CopyFromScreen(0, 0, 0, 0, new Size(w, h), CopyPixelOperation.SourceCopy);

            try
            {
                if (String.IsNullOrEmpty(path))
                    path = $@"{DateTime.Today.Day}_{DateTime.Today.Month}-{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.png";

                screen.Save($@"Data/User/{path}", AImageFormat.Png);
            }
            catch
            {
                Scripter.Execute($"error('Invalid path for screen.capture()! [Data/User/{path}]')");
            }

            gfx.Dispose();
            screen.Dispose();
        }

        /// <summary>
        /// Get total size of all your screens combied.
        /// </summary>
        /// <returns>Total size of screens.</returns>
        public static SizeContainer GetSize()
        {
            Screen[] screens = Screen.AllScreens;

            return new SizeContainer() { Width = screens.ToList().Sum(x => x.Bounds.Width), Height = screens.ToList().Max(i => i.Bounds.Height) };
        }
    }
}
