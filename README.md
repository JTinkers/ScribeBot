# ScribeBot
![](https://i.imgur.com/nPWbUCM.png) 

ScribeBot is a scriptable automation system.

With a little knowledge of Lua, you can automate mundane tasks, create macros or even create a second bot.

![https://i.imgur.com/bZckWI6.png](https://i.imgur.com/bZckWI6.png)

## Important Notice
This program uses unmanaged code (see: https://msdn.microsoft.com/en-us/library/ms973872.aspx#manunman_topic6) and provides low-level functionality that if used improperly (intentionally or not) could affect system's security and reliability. 

**Only download scripts from trusted sources and check the code before you run it.**

## Usage
- Run ScribeBot.exe
- Select from a list of scripts (stored in /Data/Scripts)
- Check (or don't) the 'Asynchronous' option
- Hit 'Run'

## Writting for ScribeBot
The program is currently a work in progress and might get updated with new features over time.

It currently consists of several functions listed below (functions will be renamed to fit Lua conventions in the future).

## Functions (A more comprehensive list coming soon)

- core.version
- core.write(text)
- core.writeLine(text)
- core.setFocusWindow(windowTitle)
- core.getFocusWindow()
- core.setWindowSize(windowTitle, width, height)
- core.getWindowSize(windowTitle)
- core.setWindowPos(windowTitle, x, y)
- core.getWindowPos(windowTitle)
- core.isWindowVisible(windowTitle)
- core.getWindowTitles()
- core.close()

- input.sendKeyPress(key)
- input.sendMousePress(nButton)
- input.setCursorPos(x, y)
- input.getCursorPos()

- interface.showPrompt(message)

## Lua-ext Functions (A list of functions implemented into Lua itself)

- wait(time)
- table.print(t)

## Known bugs/odd behaviour
- If you don't check the 'Asynchronous' option, the script will run on the same thread as the interface - rendering it unusable until the script is done.
- If you check the 'Asynchronous' option, syntax errors might not be properly passed to the console (which isn't big of a deal, just get yourself a proper editor with a linter)

