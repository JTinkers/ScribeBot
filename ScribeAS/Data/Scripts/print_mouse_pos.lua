local pos
while(true) do
	pos = Input.GetCursorPos();
	print( string.format("X: %i Y: %i", pos.X, pos.Y) )
	wait(500)
end