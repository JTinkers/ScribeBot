print("Performing a test!")
wait(3000)

-- find notepad window
local titles = core.getWindowTitles();
local notepad;
for i, title in pairs( titles ) do
	if( string.find( string.lower(title), "notepad" ) or string.find( string.lower(title), "notatnik" ) ) then
		notepad = title;
		break;
	end
end

-- keys to emulate
local keys = { "KEY_T", "KEY_H", "KEY_I", "KEY_S", "SPACE", "KEY_I", "KEY_S", "SPACE", "KEY_A", "SPACE", "KEY_T", "KEY_E", "KEY_S", "KEY_T" }

-- emulate input
if( notepad ) then
	print("Notepad found!")

	core.setFocusWindow( notepad )

	wait( 250 )

	for i, key in pairs( keys ) do
		input.sendKeyPress( VirtualKeyCode[ key ] )
		wait( 100 )
	end
end