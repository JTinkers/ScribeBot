# ScribeBot
ScribeBot is a scriptable automation system.

With a little knowledge of Lua, you can automate mundane tasks, create macros or even create a game bot.

## Usage
- Run ScribeBot.exe
- Select from a list of scripts (stored in /Data/Scripts)
- Check (or don't) the 'Asynchronous' option
- Hit 'Run'

## Writting for ScribeBot
The program is currently a work in progress and might get updated with new features over time.

It currently consists of several functions listed below (functions will be renamed to fit Lua conventions in the future).

## Functions (A more comprehensive list coming soon)

- Core.Version
- Core.Write(text)
- Core.WriteLine(text)
- Core.SetFocusWindow(windowTitle)
- Core.GetFocusWindow()
- Core.SetWindowSize(windowTitle, width, height)
- Core.GetWindowSize(windowTitle)
- Core.SetWindowPos(windowTitle, x, y)
- Core.GetWindowPos(windowTitle)
- Core.IsWindowVisible(windowTitle)
- Core.Close()

- Input.SendKeyPress(key)
- Input.SendMousePress(nButton)
- Input.SetCursorPos(x, y)
- Input.GetCursorPos()

- Interface.ShowPrompt(message)

## Known bugs/odd behaviour
- If you don't check the 'Asynchronous' option, the script will run on the same thread as the interface - rendering it unusable until the script is done.
- If you check the 'Asynchronous' option, syntax errors might not be properly passed to the console (which isn't big of a deal, just get yourself a proper editor with a linter)
