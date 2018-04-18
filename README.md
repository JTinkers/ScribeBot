#**README last updated with upload of Release-0.6b**
# ScribeBot
![](https://i.imgur.com/nPWbUCM.png) 

ScribeBot is a highly scriptable automation system.

With a little knowledge of Lua, you can automate mundane tasks, create macros or even create a bot.

![https://i.imgur.com/2fD3srP.png](https://i.imgur.com/2fD3srP.png)

## Key Features
- Lua interpreter plugged to numerous APIs and libraries - create robust systems without expert knowledge.
- Simple and easy interface - it's not beautiful, but it works.
- Packaging system - keep scripts and info about them bundled togheter.
- Workshop - find and download community-made scripts with just one click.
- Built-in package editor - edit packages without having to unzip them.
- Logging system - find out what broke when you were away.

## Planned Features
- Workshop hosting that allows for more API calls.
- Autoupdater.
- Lua Manual (list of functions, types etc).
- Merge script execution into a maintained loop, allowing for usage of hotkeys, routines and cross-dependency from outside of the bundle.
- ~~Add Selenium wrapper for web-based automations.~~

## Important Notice
This program uses unmanaged code (see: https://msdn.microsoft.com/en-us/library/ms973872.aspx#manunman_topic6) and provides low-level functionality that if used improperly (intentionally or not) could affect system's security and reliability.
It's possible to write a malicious script - it's **highly advised** to open packages with package editor and read code before executing it, especially if it comes from untrusted sources.

## Function List
':' instead of '.' means that it's an instance of a class - both . and : can be used on it, but : is preferred.

- core.Version
- core.Write(text)
- core.WriteLine(text)
- core.SetFocusWindow(title)
- core.GetFocusWindow()
- core.SetWindowSize(title, w, h)
- core.GetWindowSize()
- core.SetWindowPos(title, x, y)
- core.GetWindowPos()
- core.IsWindowVisible(title)
- core.Close()
- core.GetWindowTitles()

- input.SendKeyPress(virtualKeyCode)
- input.SendKeyPress(text, delay)
- input.SendKeyPress(char)
- input.SendMousePress(number)
- input.SetCursorPos(x, y)
- input.GetCursorPos()

- screen.getPixel(x, y)
- screen.capture(savePath)
- screen.getSize()

- webDriver.create(path To ChromeDriver.exe)
- webDriver.title
- webDriver.refresh()
- webDriver.close()
- webDriver.sendKeyPress(key)
- webDriver.sendKeyRelease(key)
- webDriver.sendKeys(keySequence)
- webDriver.findElementsById(id)
- webDriver.findElementsByClass(name)
- webDriver.findElementsByLinkText(link)
- webDriver.findElementsByPartialLinkText(link)
- webDriver.findElementsByCssSelector(selector)
- webDriver.findElementsByXPath(xpath)

- webElement:findElementsById(id)
- webElement.findElementsByClass(name)
- webElement:findElementsByLinkText(link)
- webElement:findElementsByPartialLinkText(link)
- webElement:findElementsByCssSelector(selector)
- webElement:findElementsByXPath(xpath)
- webElement:submit()
- webElement.text
- webElement:click()

- interface.showPrompt(message)

Some functions that were implemented by Lua interpreter itself can be found here: http://www.moonsharp.org/additions.html

## Planned Functions
- input.isKeyDown(virtualKeyCoode)
- input.isKeyDown(char)
- input.isMouseDown(number)
- input.isKeyDown() -- but for gamepad
- audio.*
- xml.*

**Many more that have yet to be suggested!**
