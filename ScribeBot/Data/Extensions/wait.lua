function wait(time)
    local callTime = os.clock() + (time/1000)
    repeat until os.clock() > callTime
end
