if __name__ == '__main__':
    readPath  = "Book.txt"
    writePath  = "BookFormatted.txt"
    
    w = open(writePath, "a", encoding='utf-8')
    #lens =[]
    f = open(readPath, "r", encoding='utf-8')
    line = ""
    lineLen = 0
    while 1:
        # read by character
    
        char = f.read(1)
        lineLen+=1
        #print(char)

        if char != "\n" and char != "\t":
            line+= char
        else:
            line+= " "
        if char == ".":
            line = line.strip()
            line+='\n'
            if lineLen>=40 and lineLen<=80 and line[0]!= "\"" and line[0]!="-" and line[0]!= "*" and line[0]!= "(" and line[0]!=")" and line[0] != "”" and line[0]!= "—" and line[0]!="_" and line[0]!="’"and line[0]!="’":
                w.write(line)
            lineLen = 0
            line = ""

        if not char:
            break  
        
 
    f.close()
    w.close()
    
