using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;
using Scribe.Interface;

namespace Scribe.Wrappers
{
    [MoonSharpUserData]
    static class Interface
    {
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
