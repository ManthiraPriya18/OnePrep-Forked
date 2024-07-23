from collections import deque

# Base
class TreeNode:
    def __init__(self,val=0,left=None,right=None):
        self.val=val 
        self.left=left
        self.right=right
def create_binary_tree(lst):
    if not lst:
        return None
    root = TreeNode(lst[0])
    queue = deque([root])
    i = 1
    while queue and i < len(lst):
        node = queue.popleft()
        if lst[i] is not None:
            left = TreeNode(lst[i])
            node.left = left
            queue.append(left)
        i += 1
        if i < len(lst) and lst[i] is not None:
            right = TreeNode(lst[i])
            node.right = right
            queue.append(right)
        i += 1
    return root


class DepthFirstSearch:
    # <root> <left> <right>
    def inorder_iteratively(self,root :TreeNode|None):
        if root is None:
            print('Tree is empty')
            return
        # Set current to root of binary tree
        current = root
        
        # Initialize stack
        stack = []
        while True:
            
            # Reach the left most Node of the current Node
            if current is not None:
                
                # Place pointer to a tree node on the stack 
                # before traversing the node's left subtree
                stack.append(current)
                current = current.left
            
            # BackTrack from the empty subtree and visit the Node
            # at the top of the stack; however, if the stack is 
            # empty you are done
            elif(stack):
                current = stack.pop()
                print(current.val, end=" ")
            
                # We have visited the node and its left 
                # subtree. Now, it's right subtree's turn
                current = current.right 
    
            else:
                break
    
    def preorder_iteratively(self,root :TreeNode|None):
        if root is None:
            print('Tree is empty')
            return
        
        stack=[]
        current=root
        while True:
            if current is not None:
                print(current.val,end="->")
                stack.append(current)
                current=current.left
            elif(stack):
                top=stack.pop()
                current=top.right
            else:
                break
                
    def postorder_iteratively(self,root:TreeNode|None):
        if root is None:
            print('Tree is empty')
            return
    
        stack1 = []
        stack2 = []
        stack1.append(root)
        
        while stack1:
            node = stack1.pop()
            stack2.append(node)
            
            if node.left:
                stack1.append(node.left)
            if node.right:
                stack1.append(node.right)
        
        while stack2:
            node = stack2.pop()
            print(node.val,end='->')
    
    def postorder_recursively(self,root :TreeNode|None):
        if (root is None): 
            return
        self.postorder_iteratively(root.left)
        self.postorder_iteratively(root.right)
        print(root.val,end="->")
    def getLeafNodes(self,root):
        ans=[]
        stack=[]
        current=root
        while True:
            if current is not None:
                stack.append(current)
                if(current.left is None and current.right is None):
                    ans.append(current.val)
                current=current.left
            elif(stack):
                top=stack.pop()
                current=top.right
            else:
                break
        print(ans)
        return ans
tree= create_binary_tree([1,2,3,4,5,6,7])
dfs=DepthFirstSearch()
dfs.postorder_iteratively(tree)
# print(tree)