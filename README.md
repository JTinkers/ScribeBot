# ScribeBot

![](https://i.imgur.com/1iRhIRy.gif)

ScribeBot is a highly scriptable automation system.

With a little knowledge of Lua, you can automate mundane tasks, create macros or even create a bot.

<p align="center">
	<img src="https://i.imgur.com/GqcLPoj.png" />
</p>

<p align="center">
	<b>Now with auto-updater!</b>
</p>

<p align="center">
	<img src="https://i.imgur.com/7daPYmG.png" />
</p>

<p align="center">
	<b>Here's a glance at what interface will look like in v1.0 Beta</b>
</p>

<p align="center">
	<img src="https://i.imgur.com/rDgWKLF.png" />
</p>

### Join our discord server if you have questions/suggestions or a cool script to share: <a href=https://discord.gg/nXdGWnQ><img src="https://discordapp.com/assets/fc0b01fe10a0b8c602fb0106d8189d9b.png" width="100"></a>

## Important Notice
This program uses unmanaged code ([msdn topic](https://msdn.microsoft.com/en-us/library/ms973872.aspx#manunman_topic6)) and provides low-level functionality that if used improperly (intentionally or not) could affect system's security and reliability.
It's possible to write a malicious script - it's **highly advised** to open packages with package editor and read code before executing it, especially if it comes from untrusted sources.

## Program Features
- Lua interpreter plugged to numerous APIs and libraries - create robust systems without expert knowledge.
- Simple and easy interface - it's not beautiful, but it works.
- Packaging system - keep scripts and info about them bundled together.
- Workshop - find and download community-made scripts with just one click.
- Built-in package editor - edit packages without having to unzip them.
- Logging system - find out what broke when you were away.

## Libraries
|  Library  |                         Functionality (Short)                      | Third-party dependency |
| --------- | ------------------------------------------------------------------ | ---------------------- |
| audio     | Play sounds, get device current peak level                         |          NAudio        |
| core      | Manage windows, write to console, process console input            |            -           |
| database  | Read and save data to a local database                             |          SQLite        |
| input     | Emulate keyboard/mouse input                                       |            -           |
| interface | Create 'value input request' prompts                               |            -           |
| screen    | Recognize text, capture screen, read screen pixels, manage screens |        Tesseract       |
| webdriver | Create web automations                                             |         Selenium       |

## Known bugs and odd-behavior
- None

## Code Examples

You can find a simplistic stopwatch script below.

It'll keep counting seconds that have passed since it's been started and it'll continue doing so until you set `count` to `false`.

`core.processConsoleInput()` is crucial here, otherwise sending `count = false` via console won't be executed.

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

Some functions that weren't listed below can be found [here](http://www.moonsharp.org/additions.html).

| Name | Function | Params | Returns |
| :--- | :--- | ---: | ---: |
| `audio.createDevice` | Create device for sound playing | - | AudioDevice device |
| `audio.getDeviceNames` | Get user-friendly device names | - | string[] names |
| `audio.getPeakValue` | Get peak value of a named device | string name | int peak |
| `audio.playNote` | Play note of a given frequency | (Enum)NoteFrequencies note | - |
| `core.close` | Close bot | - | - |
| `core.getFocusWindow` | Get title of currently focused window | - | string title |
| `core.setFocusWindow` | Set focus to a window of given title | string title | - |
| `core.getWindowPos` | Get position of a window | string title | Point pos |
| `core.setWindowPos` | Set position of a window | string title, number x, y | - |
| `core.getWindowSize` | Get size of a window | string title | Size size |
| `core.setWindowSize` | Set size of a window | string title, number w, h | - |
| `core.getWindowTitles` | Get titles of all windows | - | string[] titles |
| `core.isWindowVisible` | Get whether window is visible | title | bool isVisible |
| `core.processConsoleInput` | Process input entered into console | - | - |
| `core.write` | Write text to the console | string text | - |
| `core.writeLine` | Write colored (or not) text to the console | Color color, string Text ... | - |
| `core.version` | Get current bot version | - | string version |
| `database.query` | Execute a query on the local database | string query | - |
| `input.getCursorPos` | Get position of cursor | - | Point pos |
| `input.setCursorPos` | Set position of cursor | number x, y | - |
| `input.isKeyDown` | Get whether key is down | (Enum)VirtualKey key | bool isKeyDown |
| `input.isMouseDown` | Get whether mouse is down | number button | bool isMouseDown |
| `input.sendKeyDown` | Emulate key press | (Enum)VirtualKey key | - |
| `input.sendKeyUp` | Emulate key release | (Enum)VirtualKey key | - |
| `input.sendKeyPress` | Emulate key press and release | (Enum)VirtualKey key | - |
| `input.sendKeyPress` | Emulate key presses and releases | string sequence | - |
| `input.sendMouseDown` | Emulate mouse press | number button | - |
| `input.sendMouseUp` | Emulate mouse release | number button | - |
| `input.sendMousePress` | Emulate mouse press and release | number button | - |
| `interface.showPrompt` | Open window requesting value input | string message | string value |
| `screen.capture` | Capture and save screen and save to given path | string path | - |
| `screen.getPixels` | Get 2D array of all pixels in a given screen portion | number x, y, w, h | Color[][] colors |
| `screen.getSize` | Get total work-space (resolutions of all screens summed up) | - | Size size |
| `screen.recognize` | Try recognizing text on the screen | number x, y, w, h | string text |

Selenium Functions
---get the title of current browser window
---returns: the title
-webdriver.title
-
---get url of current web page
---returns: the url
-webdriver.url
-
---create an instance of webdriver
---path: path to chromedriver.exe
---returns: webdriver instance object
-webdriver.create(path)
-
---go to a specified url
---url: the url to go to
-webdriver:goToUrl(url)
-
---refresh page
-webdriver:refresh()
-
---close and dispose webdriver instance
-webdriver:close()
-
---emulate key press
---key: key to emulate press of
-webdriver:sendKeyPress(key)
-
---emulate key release
---key: key to emulate release of
-webdriver:sendKeyRelease(key)
-
---emulate a sequence of keys
-webdriver:sendKeys(keySequence)
-
---find DOM elements using their id
---id: id to search by
---returns: a table of webelements
-webdriver:findElementsById(id)
-
---find DOM elements using their class
---class: class to search by
---returns: a table of webelements
-webdriver:findElementsByClass(class)
-
---find DOM elements using their link text
---linkText: link text to search by
---returns: a table of webelements
-webdriver:findElementsByLinkText(linkText)
-
---find DOM elements using their partial link text
---linkText: partial link text to search by
---returns: a table of webelements
-webdriver:findElementsByPartialLinkText(linkText)
-
---find DOM elements using css selectors
---selector: selector to search by
---returns: a table of webelements
-webdriver:findElementsByCssSelector(selector)
-
---find DOM elements using xpath
---xpath: xpath to search by
---returns: a table of webelements
-webdriver:findElementsByXPath(xpath)
-
---find DOM elements using their names
---name: name to search by
---returns a table of webelements
-webdriver:findElementsByName(name)
-
---get text contained within a DOM element
---returns: text contained within DOM element(duh)
-webelement.text
-
---get whether element is enabled or not
---returns: true/false
-webelement.enabled
-
---get whether element is displayed or not
---returns: true/false
-webelement.displayed
-
---get the size of element
---returns: Size { Width, Height }
-webelement.size
-
---get the location of element
---returns: Point { X, Y }
-webelement.location
-
---clear the element, mostly used for text fields
-webelement:clear()
-
---if DOM element is inside a form, submit form
-webelement:submit()
-
---emulate a click on DOM element
-webelement:click()
-
---send a key sequence
---seq: keys to emulate
-webelement:SendKeys(seq)
-
---find DOM elements using their id
---id: id to search by
---returns: a table of webelements
-webelement:findElementsById(id)
-
---find DOM elements using their class
---class: class to search by
---returns: a table of webelements
-webelement:findElementsByClass(class)
-
---find DOM elements using their link text
---linkText: link text to search by
---returns: a table of webelements
-webelement:findElementsByLinkText(linkText)
-
---find DOM elements using their partial link text
---linkText: partial link text to search by
---returns: a table of webelements
-webelement:findElementsByPartialLinkText(linkText)
-
---find DOM elements using css selectors
---selector: selector to search by
---returns: a table of webelements
-webelement:findElementsByCssSelector(selector)
-
---find DOM elements using xpath
---xpath: xpath to search by
---returns: a table of webelements
-webelement:findElementsByXPath(xpath)
-
---find DOM elements using their names
---name: name to search by
---returns a table of webelements
-webelement:findElementsByName(name)

<p align="center">
	<i>README last updated with upload of Release-0.65b</i>
</p>
