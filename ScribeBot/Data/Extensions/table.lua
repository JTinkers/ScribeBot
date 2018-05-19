function table.print(t)
    if not t then return false end

    print("Table = \n{")
    for k, v in pairs(t) do
        print(string.format("\t%s = %s%s", k, v, (k == #t and "") or ","))
    end
    print("}")
end
