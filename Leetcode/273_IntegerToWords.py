import math
class Solution:
    words_dict={
        1:"One",
        2:"Two",
        3:"Three",
        4:"Four",
        5:"Five",
        6:"Six",
        7:"Seven",
        8:"Eight",
        9:"Nine",
        10:"Ten",
        11:"Eleven",
        12:"Twelve",
        13:"Thirteen",
        14:"Fourteen",
        15:"Fifteen",
        16:"Sixteen",
        17:"Seventeen",
        18:"Eighteen",
        19:"Nineteen",
        20:"Twenty",
        30:"Thirty",
        40:"Fourty",
        50:"Fifty",
        60:"Sixty",
        70:"Seventy",
        80:"Eighty",
        90:"Ninety",
        100:"Hundred"
        }
    def numberToWords(self, num: int) -> str:
        numstr=str(num)
        res=[[],[],[],[]]
        available_space=3
        pointer_negative=-1
        for i in range(len(numstr)-1,-1,-1):
            if(available_space>0):
                res[pointer_negative].insert(0,numstr[i])
                available_space-=1
            if not available_space:
                available_space=3
                pointer_negative-=1
        ans=[]
        for i in res:
            if(len(i)==0):
                ans.append([])
            else:
                ans.append(self.getWord(''.join(i)))
        print(res)
        print(ans)
        final_answer=[]
        if(ans[0]):
            final_answer.append(ans[0])
            final_answer.append("Billion")
        if(ans[1]):
            final_answer.append(ans[1])
            final_answer.append("Million")
        if(ans[2]):
            final_answer.append(ans[2])
            final_answer.append("Thousand")
        if(ans[3]):
            final_answer.append(ans[3])
        
        print(' '.join(final_answer))
        # print(self.getWord("3"))
        # print(self.getWord("34"))
        # print(self.getWord("12"))
        # print(self.getWord("312"))
        return ' '.join(final_answer)
    
    def getWord(self,inpstr):
        output=[]
        default_value=-1
        first=default_value
        second=default_value
        third=default_value
        if(len(inpstr)>2):
            first=int(inpstr[0])
            second=int(inpstr[1])
            third=int(inpstr[2])
        elif(len(inpstr)>1):
            second=int(inpstr[0])
            third=int(inpstr[1])
        else:
            third=int(inpstr[0])
        
        # This is for TEENS
        if( (first==default_value) and second!=default_value and third!=default_value):
            combine=(second*10)+third
            val = self.words_dict.get(combine,"")
            if(val):
                return val
        
        if(first!=default_value):
            # Value at first is available
            val=self.words_dict.get(first,"")
            if(val):
                output.append(val)
                output.append(self.words_dict[100])
        if(second!=default_value):
            combine=(second*10)+third
            val = self.words_dict.get(combine,"")
            # Teen satisfies
            if(val):
                output.append(val)
                return ' '.join(output)
            second_floor=math.floor(second)*10
            val=self.words_dict.get(second_floor,"")
            if(val):
                output.append(val)
            pass 
        
        if(third!=default_value):
            val=self.words_dict.get(third,"")
            if(val):
                output.append(val)
        return ' '.join(output)
    
inp=2_123_456_678
print(Solution().numberToWords(inp))