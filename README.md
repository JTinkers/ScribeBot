**README last updated with upload of Release-0.65b**
# ScribeBot
![](https://i.imgur.com/nPWbUCM.png)

ScribeBot is a highly scriptable automation system.

With a little knowledge of Lua, you can automate mundane tasks, create macros or even create a bot.

![https://i.imgur.com/2fD3srP.png](https://i.imgur.com/2fD3srP.png)

### Join our discord server if you have questions/suggestions or a cool script to share: <a href=https://discord.gg/Scdf4QX><img src="https://discordapp.com/assets/fc0b01fe10a0b8c602fb0106d8189d9b.png" width="100"></a>

## Key Features
- Lua interpreter plugged to numerous APIs and libraries - create robust systems without expert knowledge.
- Simple and easy interface - it's not beautiful, but it works.
- Packaging system - keep scripts and info about them bundled togheter.
- Workshop - find and download community-made scripts with just one click.
- Built-in package editor - edit packages without having to unzip them.
- Logging system - find out what broke when you were away.

## Planned Changes/Features
- Workshop hosting that allows for more API calls.
- Autoupdater.
- Interface remake.
- OCR/OSR implementation.
- Lua Manual (list of functions, types etc).
- Complete remake and refactoring of certain libraries.

## Known bugs and odd-behavior
- None

## Third-party libraries:
- Selenium - used for web-based automatisations.
- Newtonsoft's Json - Used for reading info.json from packages.
- MoonSharp - used as Lua interpterer.
- Tesseract - used for OCR (not yet implemented).

## Important Notice
This program uses unmanaged code (see: https://msdn.microsoft.com/en-us/library/ms973872.aspx#manunman_topic6) and provides low-level functionality that if used improperly (intentionally or not) could affect system's security and reliability.
It's possible to write a malicious script - it's **highly advised** to open packages with package editor and read code before executing it, especially if it comes from untrusted sources.

## Code Examples

Below you can find a simplistic stopwatch script.

It'll keep counting seconds that have passed since it's been started and it'll continue doing so until you set 'count' to false.

core.processConsoleInput() is crucial here, otherwise sending 'count = false' via console won't be executed.

```lua
count = true
i = 0

while(count) do
	i = i + 1

	print(i)

	wait(1000)

	core.processConsoleInput()
end
```

## Functions

Some functions that weren't listed below: http://www.moonsharp.org/additions.html

```lua
--run a query on local sqlite database
--query: query string to execute
--returns: array of rows or an empty array if query requested no rows or matches weren't found
database.query(query)

--play a console beep of given frequency
--freq: a note from NoteFrequencies
--duration: time to play it for
audio.playNote(freq, duration)

--create an audio device for playing sounds
--returns: audiodevice instance object
audio.createDevice()

--get names of active audio devices
--returns: array of names
audio.getDeviceNames()

--get peak level of an audio device
--name: name of device to get peak level of
--returns: peak value
audio.getPeakValue(name)

--load a sound file into audio device
--path: drive path or url of the file
audiodevice:load(path)

--self-explanatory
audiodevice:pause()

--self-explanatory
audiodevice:play()

--self-explanatory
audiodevice:stop()

--get state of the device
--returns: 0 - stopped, 1 - playing, 2 - paused
audiodevice.state

--self-explanatory
audiodevice.volume

--get current version of the bot
--returns: string containing version of a bot (I always forget to update this, but I'll keep it automated later)
core.version

--process and run lines of code entered into console
core.processConsoleInput()

--get timestamp of when bot was launched
--returns: the timestamp
core.timeStarted

--write text into console
--text: text to write
core.write(text)

--write text into console and append new line
--text: text to write
core.writeLine(text)

--set focus to a window and bring it forward
--title: title of window to set focus of
core.setFocusWindow(title)

--get title of currently focused window
--returns: window title
core.getFocusWindow()

--set size of a window
--title: title of window to set size of
--w, h: self-explanatory
core.setWindowSize(title, w, h)

--get size of a window
--title: title of window to get size of
--returns: Size { Width, Height }
core.getWindowSize(title)

--set position of a window
--title: title of window to change position of
--x, y: self-explanatory
core.setWindowPos(title, x, y)

--get position of a window
--title: title of window to get position of
--returns: Point { X, Y }
core.getWindowPos(title)

--get whether window is visible or not
--title of window
--returns: true/false
core.isWindowVisible(title)

--get list of window titles
--returns: a table of all titles
core.getWindowTitles()

--close ScribeBot entirely
core.close()

--emulate key presses for a sequence of keys
--seq: sequence of keys to emulate
--delay: delay after which each key should be emulated - default: 100ms
input.sendKeyPress(seq, delay)

--emulate key press and release for a key, use hex values for other keys
--virtualkey: key from virtualkey enum to emulate
input.sendKeyPress(virtualkey)

--emulate key press
--virtualkey: key from virtualkey enum to emulate
input.sendKeyDown(virtualkey)

--emulate key release
--virtualkey: key from virtualkey enum to emulate
input.sendKeyUp(virtualkey)

--emulate mouse button press and release
--number: number of the button, 0 - left, 1 - right ...
input.sendMousePress(number)

--emulate mouse button press
--number: number of the button, 0 - left, 1 - right ...
input.sendMouseDown(number)

--emulate mouse button release
--number: number of the button, 0 - left, 1 - right ...
input.sendMouseUp(number)

--get whether key is down or not
--returns: true/false
input.isKeyDown(char)

--get whether mouse button is down or not
--returns: true/false
input.isMouseDown(number)

--set position of the cursor
--x, y: self-explanatory
input.setCursorPos(x, y)

--get position of the cursor
--returns: Point { X, Y }
input.getCursorPos()

--get color of position on a specific position
--returns: W x H array of Color { R, G, B }
screen.getPixels(x, y, w, h)

--capture screen
--savePath: path to save screenshot to
screen.capture(savePath)

--get size of the entire screen (including other monitors)
--returns: Size { Width, Height }
screen.getSize()

--get the title of current browser window
--returns: the title
webdriver.title

--get url of current web page
--returns: the url
webdriver.url

--create an instance of webdriver
--path: path to chromedriver.exe
--returns: webdriver instance object
webdriver.create(path)

--go to a specified url
--url: the url to go to
webdriver:goToUrl(url)

--refresh page
webdriver:refresh()

--close and dispose webdriver instance
webdriver:close()

--emulate key press
--key: key to emulate press of
webdriver:sendKeyPress(key)

--emulate key release
--key: key to emulate release of
webdriver:sendKeyRelease(key)

--emulate a sequence of keys
webdriver:sendKeys(keySequence)

--find DOM elements using their id
--id: id to search by
--returns: a table of webelements
webdriver:findElementsById(id)

--find DOM elements using their class
--class: class to search by
--returns: a table of webelements
webdriver:findElementsByClass(class)

--find DOM elements using their link text
--linkText: link text to search by
--returns: a table of webelements
webdriver:findElementsByLinkText(linkText)

--find DOM elements using their partial link text
--linkText: partial link text to search by
--returns: a table of webelements
webdriver:findElementsByPartialLinkText(linkText)

--find DOM elements using css selectors
--selector: selector to search by
--returns: a table of webelements
webdriver:findElementsByCssSelector(selector)

--find DOM elements using xpath
--xpath: xpath to search by
--returns: a table of webelements
webdriver:findElementsByXPath(xpath)

--find DOM elements using their names
--name: name to search by
--returns a table of webelements
webdriver:findElementsByName(name)

--get text contained within a DOM element
--returns: text contained within DOM element(duh)
webelement.text

--get whether element is enabled or not
--returns: true/false
webelement.enabled

--get whether element is displayed or not
--returns: true/false
webelement.displayed

--get the size of element
--returns: Size { Width, Height }
webelement.size

--get the location of element
--returns: Point { X, Y }
webelement.location

--clear the element, mostly used for text fields
webelement:clear()

--if DOM element is inside a form, submit form
webelement:submit()

--emulate a click on DOM element
webelement:click()

--send a key sequence
--seq: keys to emulate
webelement:SendKeys(seq)

--find DOM elements using their id
--id: id to search by
--returns: a table of webelements
webelement:findElementsById(id)

--find DOM elements using their class
--class: class to search by
--returns: a table of webelements
webelement:findElementsByClass(class)

--find DOM elements using their link text
--linkText: link text to search by
--returns: a table of webelements
webelement:findElementsByLinkText(linkText)

--find DOM elements using their partial link text
--linkText: partial link text to search by
--returns: a table of webelements
webelement:findElementsByPartialLinkText(linkText)

--find DOM elements using css selectors
--selector: selector to search by
--returns: a table of webelements
webelement:findElementsByCssSelector(selector)

--find DOM elements using xpath
--xpath: xpath to search by
--returns: a table of webelements
webelement:findElementsByXPath(xpath)

--find DOM elements using their names
--name: name to search by
--returns a table of webelements
webelement:findElementsByName(name)

--create a prompt window with specified message and value input
--message: message to show
--returns: whatever you've put into value input but converted to a string
interface.showPrompt(message)
```
