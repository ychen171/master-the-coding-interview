
using System.Security.AccessControl;
using System.Collections.Concurrent;
using System.Data;
Console.WriteLine("Hello world!");

class Node
{
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Value { get; set; }
    public Node(int value)
    {
        Value = value;
    }
}

class BinarySearchTree
{
    public Node Root {get;set;}
    public BinarySearchTree()
    {
    }

    public void Insert(int key)
    {
        var newNode = new Node(key);
        if (Root == null)
        {
            Root = new Node(key);
            return;
        }
        Node parentNode = null;
        var currNode = Root;
        while (currNode != null)
        {                
            parentNode = currNode;
            if (currNode.Value < key)
                currNode = currNode.Right;
            else
                currNode = currNode.Left;
        }

        if (parentNode.Value < key)
            parentNode.Right = newNode;
        else
            parentNode.Left = newNode;
    }

    // public void InsertRecursively(int key)
    // {
    //     Insert(Root, key);
    // }
    // public Node Insert(Node node, int key)
    // {
    //     if (node == null)
    //     {
    //         var newNode = new Node(key);
    //         node = newNode;
    //         return node;
    //     }
    //     if (node.Value < key)
    //         return Insert(node.Right, key);
    //     else
    //         return Insert(node.Left, key);
    // }

    public Node Search(int key)
    {
        if (Root == null) return null;
        var currNode = Root;
        while (currNode != null)
        {
            if (currNode.Value == key)
                return currNode;
            else if (currNode.Value < key)
                currNode = currNode.Right;
            else
                currNode = currNode.Left;
        }
        return null;
    }
    public Node Search(Node node, int key)
    {
        if (node == null) return null;
        if (node.Value == key) return node;
        else if (node.Value < key)
            return Search(node.Right, key);
        else
            return Search(node.Left, key);
    }
    public Node SearchRecursively(int key)
    {
        return Search(Root, key);
    }

    //          9
    //   4              20
    //1     6       15      170
    public void Remove(int key)
    {
        if (Root == null) return;
        var currNode = Root;
        Node parentNode = null;
        while (currNode != null)
        {
            // found the node
            if (currNode.Value == key)
            {
                // Option 1: No right child
                if (currNode.Right == null)
                {
                    var replacementNode = currNode.Left;
                    if (parentNode == null) 
                        Root = replacementNode;
                    else 
                    {
                        if (parentNode.Value < currNode.Value)
                            parentNode.Right = replacementNode;
                        else
                            parentNode.Left = replacementNode;
                    }
                }
                // Option 2: Right child doesn't have a left child
                else if (currNode.Right.Left == null)
                {
                    // Right child is the left most child in currentNode's right subtree
                    // rename it as "replacementNode"
                    var replacementNode = currNode.Right;
                    // populate the left child for replacementNode
                    replacementNode.Left = currNode.Left;
                    // start the replacement process
                    if (parentNode == null)
                        Root = replacementNode;
                    else
                    {
                        if (parentNode.Value < currNode.Value)
                            parentNode.Right = replacementNode;
                        else
                            parentNode.Left = replacementNode;
                    }
                }
                // Option 3: Right child has a left child
                else if (currNode.Right.Left != null)
                {
                    // find Right child's left most child (find min) and rename it as "replacementNode"
                    var leftMostNode = currNode.Right.Left;
                    var leftMostParentNode = currNode.Right;
                    while (leftMostNode.Left != null)
                    {
                        leftMostParentNode = leftMostNode;
                        leftMostNode = leftMostNode.Left;
                    }
                    // break the bond between leftMostNode and leftMostParentNode
                    // leftMostParentNode's left subtree is leftMostNode's right subtree
                    leftMostParentNode.Left = leftMostNode.Right;
                    var replacementNode = leftMostNode;
                    // populate the left child and right child for replacementNode
                    replacementNode.Left = currNode.Left;
                    replacementNode.Right = currNode.Right;
                    // start the replacement process
                    if (parentNode == null)
                        Root = replacementNode;
                    else
                    {
                        if (parentNode.Value < currNode.Value)
                            parentNode.Right = replacementNode;
                        else
                            parentNode.Left = replacementNode;
                    }
                }
                // remove currNode
                currNode = null;
            }
            // haven't found the node; continue
            else if (currNode.Value < key)
            {
                parentNode = currNode;
                currNode = currNode.Right;
            }
            else
            {
                parentNode = currNode;
                currNode = currNode.Left;
            }
        }
        return;
    }

    // public void Remove2(int key)
    // {
    //     if (Root == null) return;
    //     var currNode = Root;
    //     Node parentNode = null;
    //     while (currNode != null)
    //     {
    //         // found the node
    //         if (currNode.Value == key)
    //         {
    //             // Option 1: No child
    //             if (currNode.Left == null && currNode.Right == null)
    //             {
    //                 if (parentNode == null)
    //                     Root = null;
    //                 else
    //                 {
    //                     if (parentNode.Value < currNode.Value)
    //                         parentNode.Right = null;
    //                     else
    //                         parentNode.Left = null;
    //                 }
    //             }
    //             // Option 2: 1 child (left or right)
    //             else if (currNode.Left == null && currNode.Right != null)
    //             {
    //                 // find right child's left most child (find min) and rename it as "replacementNode"
    //                 var leftMostNode = currNode.Right;
    //                 var leftMostParentNode = currNode;
    //                 while (leftMostNode.Left != null)
    //                 {
    //                     leftMostParentNode = leftMostNode;
    //                     leftMostNode = leftMostNode.Left;
    //                 }
    //                 // break the bond between leftMostNode and leftMostParentNode
    //                 leftMostParentNode.Left = leftMostNode.Right;
    //                 var replacementNode = leftMostNode;
    //                 // Populate the right child for replacementNode
    //                 replacementNode.Right = currNode.Right;
    //                 // start the replacement process
    //                 if (parentNode == null)
    //                     Root = replacementNode;
    //                 else
    //                 {
    //                     if (parentNode.Value < currNode.Value)
    //                         parentNode.Right = replacementNode;
    //                     else
    //                         parentNode.Left = replacementNode;
    //                 }

    //             }
    //             else if (currNode.Left != null && currNode.Right == null)
    //             {
    //                 // find left child's right most child (find max) and rename it as "replacementNode"
    //                 var rightMostNode = currNode.Left;
    //                 var rightMostParentNode = currNode;
    //                 while (rightMostNode != null)
    //                 {
    //                     rightMostParentNode = rightMostNode;
    //                     rightMostNode = rightMostNode.Right;
    //                 }
    //                 // break the bond between rightMostNode and rightMostParentNode
    //                 rightMostParentNode.Right = rightMostNode.Left;
    //                 var replacementNode = rightMostNode;
    //                 // populate the left child for replacementNode
    //                 replacementNode.Left = currNode.Left;
    //                 // start the replacement process
    //                 if (parentNode == null)
    //                     Root = replacementNode;
    //                 else
    //                 {
    //                     if (parentNode.Value < currNode.Value)
    //                         parentNode.Right = replacementNode;
    //                     else
    //                         parentNode.Left = replacementNode;
    //                 }
    //             }
    //             // Option 3: 2 childs (left and right)
    //             else
    //             {


    //             }
    //         }
    //         // haven't found the node; continue
    //         else if (currNode.Value < key)
    //         {
    //             parentNode = currNode;
    //             currNode.Right = currNode;
    //         }
    //         else
    //         {
    //             parentNode = currNode;
    //             currNode.Left = currNode;
    //         }
    //     }
    // }

    public Node Successor(Node node)
    {
        // it has a right subtree, FindMin() in the right subtree
        if (node.Right != null) return FindMin(node.Right);
        // Otherwise, traverse the ancestors until find the "Right Turn"
        else
        {
            var currNode = Root; // start from Root
            Node successorNode = null; // potiential successor
            while (currNode != null && currNode.Value != node.Value)
            {
                if (currNode.Value > node.Value)
                {
                    successorNode = currNode;
                    currNode = currNode.Left;
                }
                else
                    currNode = currNode.Right;
            }
            return successorNode;
        }

    }

    public Node Predecessor(Node node)
    {
        // it has a left subtree, FindMax() in the left subtree
        if (node.Left != null) return FindMax(node.Left);
        // Otherwise, traverse the ancestors until find the "Left Turn"
        else
        {
            var currNode = Root; // start from Root
            Node predecessorNode = null; // potential predecessor
            while (currNode != null && currNode.Value != node.Value)
            {
                if (currNode.Value < node.Value)
                {
                    predecessorNode = currNode;
                    currNode = currNode.Right;
                }
                else
                    currNode = currNode.Left;
            }
            return predecessorNode;
        }
    }

    public Node FindMin()
    {
        if (Root == null) return null;
        var currNode = Root;
        while (currNode.Left != null)
        {
            currNode = currNode.Left;
        }
        return currNode;
    }

    public Node FindMin(Node node)
    {
        if (node == null) return null;
        else if (node.Left == null) return node;
        else return FindMin(node.Left);
    }

    public Node FindMax()
    {
        if (Root == null) return null;
        var currNode = Root;
        while (currNode.Right != null)
        {
            currNode = currNode.Right;
        }
        return currNode;
    }

    public Node FindMax(Node node)
    {
        if (node == null) return null;
        else if (node.Right == null) return node;
        else return FindMax(node.Right);
    }
}

static void InorderTraverseAndPrint(Node node)
{
    if (node == null) return; // base case
    InorderTraverseAndPrint(node.Left);
    Console.WriteLine(node.Value);
    InorderTraverseAndPrint(node.Right);
}

static void PreorderTraverseAndPrint(Node node)
{
    if (node == null) return; // base case
    Console.WriteLine(node.Value);
    PreorderTraverseAndPrint(node.Left);
    PreorderTraverseAndPrint(node.Right);
}

static void PostorderTraverseAndPrint(Node node)
{
    if (node == null) return; // base case
    PostorderTraverseAndPrint(node.Left);
    PostorderTraverseAndPrint(node.Right);
    Console.WriteLine(node.Value);
}

//          9
//   4              20
//1     6       15      170
static BinarySearchTree CreateBalancedTree()
{
    var tree = new BinarySearchTree();
    tree.Insert(9);
    tree.Insert(4);
    tree.Insert(6);
    tree.Insert(20);
    tree.Insert(170);
    tree.Insert(15);
    tree.Insert(1);
    return tree;
}
//                   15
//          6                   23
//  4           7                       71
//      5                           50
static BinarySearchTree CreateUnbalancedTree()
{
    var unbalancedTree = new BinarySearchTree();
    unbalancedTree.Insert(15);
    unbalancedTree.Insert(6);
    unbalancedTree.Insert(23);
    unbalancedTree.Insert(4);
    unbalancedTree.Insert(7);
    unbalancedTree.Insert(71);
    unbalancedTree.Insert(5);
    unbalancedTree.Insert(50);
    return unbalancedTree;
}

//          9
//   4              20
//1     6       15      170
var balancedTree = CreateBalancedTree();
Console.WriteLine("Inorder traverse");
InorderTraverseAndPrint(balancedTree.Root);
Console.WriteLine("Preorder traverse");
PreorderTraverseAndPrint(balancedTree.Root);
Console.WriteLine("Postorder traverse");
PostorderTraverseAndPrint(balancedTree.Root);
Node inputNode;
Node outputNode;
var keyToLookup = 6;
outputNode = balancedTree.Search(keyToLookup);
Console.WriteLine($"Search for {keyToLookup}, Return {keyToLookup == outputNode.Value}");
keyToLookup = 20;
outputNode = balancedTree.Search(keyToLookup);
Console.WriteLine($"Search for {keyToLookup}, Return {keyToLookup == outputNode.Value}");

outputNode = balancedTree.FindMin();
Console.WriteLine($"Find Min, Return {outputNode.Value}");
outputNode = balancedTree.FindMax();
Console.WriteLine($"Find Max, Return {outputNode.Value}");

inputNode = new Node(6);
outputNode = balancedTree.Successor(inputNode);
Console.WriteLine($"Successor of {inputNode.Value} is {outputNode.Value}");
outputNode = balancedTree.Predecessor(inputNode);
Console.WriteLine($"Predecessor of {inputNode.Value} is {outputNode.Value}");

//                   15
//          6                   23
//  4           7                       71
//      5                           50
BinarySearchTree unbalancedTree;
int keyToRemove;

Console.WriteLine("Creating a unbalanced tree");
unbalancedTree = CreateUnbalancedTree();
PreorderTraverseAndPrint(unbalancedTree.Root);

keyToRemove = 7;
Console.WriteLine($"Removing {keyToRemove}");
unbalancedTree.Remove(keyToRemove);
PreorderTraverseAndPrint(unbalancedTree.Root);

Console.WriteLine("Creating a unbalanced tree");
unbalancedTree = CreateUnbalancedTree();
PreorderTraverseAndPrint(unbalancedTree.Root);

keyToRemove = 6;
Console.WriteLine($"Removing {keyToRemove}");
unbalancedTree.Remove(keyToRemove);
PreorderTraverseAndPrint(unbalancedTree.Root);

Console.WriteLine("Creating a unbalanced tree");
unbalancedTree = CreateUnbalancedTree();
PreorderTraverseAndPrint(unbalancedTree.Root);

keyToRemove = 23;
Console.WriteLine($"Removing {keyToRemove}");
unbalancedTree.Remove(keyToRemove);
PreorderTraverseAndPrint(unbalancedTree.Root);

Console.WriteLine("The End");
// var anotherTree = new BinarySearchTree();
// anotherTree.InsertRecursively(9);
// anotherTree.InsertRecursively(4);
// anotherTree.InsertRecursively(6);
// anotherTree.InsertRecursively(20);
// anotherTree.InsertRecursively(170);
// anotherTree.InsertRecursively(15);
// anotherTree.InsertRecursively(1);
// TraverseAndPrint(anotherTree.Root);
// var anotherKeyToLookup = 6;
// var anotherNode = anotherTree.LookupRecursively(anotherKeyToLookup);
// Console.WriteLine($"Search for {anotherKeyToLookup}, Return {anotherKeyToLookup == anotherNode.Value}");
// anotherKeyToLookup = 20;
// anotherNode = anotherTree.LookupRecursively(anotherKeyToLookup);
// Console.WriteLine($"Search for {anotherKeyToLookup}, Return {anotherKeyToLookup == anotherNode.Value}");

