from typing import List


class Solution:
    def spiralMatrixIII(self, rows: int, cols: int, rStart: int, cStart: int) -> List[List[int]]:
        res=[]
        r,c=rStart,cStart
        step=1
        cc=0
        res.append([r,c])
        while len(res)<(rows*cols):
            for i in range(c+1,step+1):
                # Right
                if(0<=r<rows and 0<=i<cols):
                    res.append([r,i])
            c+=(1*step)
            print("Row,Col After Right",[r,c])

            # Down
            for i in range(r+1,step+1):
                if(0<=i<rows and 0<=c<cols):
                    res.append([i,c])
            r+=(1*step)
            print("Row,Col After Down",[r,c])

            
            # Left
            for i in range(c+1,(2*step)+1):
                if(0<=r<rows and 0<=i<cols):
                    res.append([r,i])
            c-=(2+step)
            print("Row,Col After Left",[r,c])

            
            # Up
            for i in range(r+1,(2*step)+1):
                if(0<=i<rows and 0<=c<cols):
                    res.append([i,c])
            r-=(2+step)
            print("Row,Col After UP",[r,c])
            
            step+=1
            cc+=1
            if(cc==100):
                print("Breaking")
                break
        print(res)
        return []
    
rows = 1
cols = 4
rStart = 0
cStart = 0
print(Solution().spiralMatrixIII(rows,cols,rStart,cStart))

""" sds
    [0(-2,-2),0( 0,-1),0(-2,0),0(-2,1),0(-2,2),0(-2,3)]
    [0(-1,-2),0(-1,-1),0(-1,0),0(-1,1),0(-1,2),0(-1,3)]
    [0( 0,-2),0( 0,-1),1( 0,0),2( 0,1),3( 0,2),4( 0,3)]
    [0( 1,-2),0( 1,-1),0( 1,0),0( 1,1),0( 1,2),0( 1,3)]
    [0( 2,-2),0( 2,-1),0( 2,0),0( 2,1),0( 2,2),0( 2,3)]
fw """

""" 
Right 1 Right 3
Down  1 Down  3
Left  2 Left  4
Up    2 Up    4 
"""