using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;
using ScribeBot.Interface;

namespace ScribeBot.Wrappers
{
    /// <summary>
    /// Class containing functions that allow for creation and usage of WinForms interfaces exposed to Lua environment.
    /// </summary>
    [MoonSharpUserData]
    static class Interface
    {
        /// <summary>
        /// Display a popup with the message and an entry box. Data entered into the entry box will be passed back to Lua environment upon submission.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string ShowPrompt( string message )
        {
            Prompt prompt = new Prompt();
            prompt.PromptMessage.Text = message;
            prompt.PromptSubmit.Click += (o, e) =>
            {
                prompt.Close();
            };

            prompt.ShowDialog();

            return prompt.PromptEntryBox.Text;
        }
    }
}
