using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Zigzag Binary tree traveral
//**************************

public class Node
{

    public int value;
    public Node leftChild;
    public Node rightChild;
}

public class BinarySearchTree
{
    Node root;

    public Node Insert(int value)
    {
        return Insert(ref root, value);
    }

    public void Delete(int value)
    {

    }

    public Node Search(int value)
    {
        return Search(root, value);
    }

    private Node Insert(ref Node root, int value)
    {
        if (root != null && root.value == value)
        {
            throw new ArgumentException("Duplicates not allowed");
        }

        if (root == null)
        {
            var newNode = new Node();
            newNode.value = value;
            newNode.leftChild = null;
            newNode.rightChild = null;

            root = newNode;
            return root;
        }

        if (root.value < value)
        {
            return Insert(ref root.rightChild, value);
        }
        else //(root.value > value)
        {
            return Insert(ref root.leftChild, value);
        }
    }

    public int HeightOfBinaryTree()
    {
        return HeightOfBinaryTree(root);
    }

    public void LevelOrderTraversal()
    {
        LevelOrderTraversal(root);
    }

    public void PrintNodesOnaGivenLevel(int level)
    {
        PrintNodesAtGivenLevel(root, level);
    }

    private Node Search(Node root, int value)
    {
        if (root != null)
        {
            if (root.value == value)
                return root;
            else if (root.value < value)
                Search(root.rightChild, value);
            else if (root.value > value)
                Search(root.leftChild, value);
        }
        return null;
    }

    private int HeightOfBinaryTree(Node root)
    {
        if (root == null)
        {
            return 0;
        }
        return Math.Max(HeightOfBinaryTree(root.leftChild), HeightOfBinaryTree(root.rightChild)) + 1;
    }

    // Iterative
    private void LevelOrderTraversal(Node root)
    {
        if (root != null)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while(queue.Count != 0)
            {
                Node temp = queue.Dequeue();
                Console.Write(temp.value);
                Console.Write(' ');

                if (temp.leftChild != null)
                    queue.Enqueue(temp.leftChild);
                if (temp.rightChild != null)
                    queue.Enqueue(temp.rightChild);
            }
        }
    }

    //private void Print nodes at a given level
    private void PrintNodesAtGivenLevel(Node root, int level)
    {
        if (root == null)
            return;
        if (level == 1)
        {
            Console.Write(root.value);
            Console.Write(' ');
        }
        else
        {
            PrintNodesAtGivenLevel(root.leftChild, level - 1);
            PrintNodesAtGivenLevel(root.rightChild, level - 1);
        }
    }

    //Print Nodes level by level (each level on new line)

    //Print nodes at distance k from root

    public void ZigZagTraversal()
    {

    }

    
}


public class Driver
{
    public static void Main()
    {
        BinarySearchTree bst = new BinarySearchTree();
        // Insert in the tree. Read from file. Each line represents a node
        using (StreamReader reader = new StreamReader(@"Trees\BST\TreeInput.txt"))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                bst.Insert(Convert.ToInt32(line));
            }
        }

        // Height of Binary Tree
        int height = bst.HeightOfBinaryTree();

        //Level Order Traversal
        bst.LevelOrderTraversal();
        Console.WriteLine();

        //Print nodes at a given level
        bst.PrintNodesOnaGivenLevel(3);
        Console.WriteLine();

        //Search for an element in the tree

        //Delete from tree

        Console.Read();
    }
}