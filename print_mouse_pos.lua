pos = null
while(true) do
	pos = input.getCursorPos();
	print( string.format("X: %i Y: %i", pos.X, pos.Y) )
	wait(500)
end
