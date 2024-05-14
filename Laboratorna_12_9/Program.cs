using System;

public class Node
{
    public Node left;
    public Node right;
    public int info;

    public Node(int value)
    {
        info = value;
        left = null;
        right = null;
    }
}

public class BinaryTree
{
    private Node root;

    // Функція для створення бінарного дерева
    public void CreateTree(int[] values)
    {
        foreach (int value in values)
        {
            AddNode(value);
        }
    }

    // Функція для додавання елемента в бінарне дерево
    public void AddNode(int value)
    {
        root = AddNodeRecursive(root, value);
    }

    private Node AddNodeRecursive(Node current, int value)
    {
        if (current == null)
        {
            return new Node(value);
        }

        if (value < current.info)
        {
            current.left = AddNodeRecursive(current.left, value);
        }
        else if (value > current.info)
        {
            current.right = AddNodeRecursive(current.right, value);
        }

        return current;
    }

    // Функція для виведення бінарного дерева на екран
    public void PrintTree()
    {
        PrintTreeRecursive(root, 0);
    }

    private void PrintTreeRecursive(Node current, int level)
    {
        if (current != null)
        {
            PrintTreeRecursive(current.right, level + 1);
            for (int i = 0; i < level; i++)
                Console.Write("   ");
            Console.WriteLine(current.info);
            PrintTreeRecursive(current.left, level + 1);
        }
    }

    // Функція для знаходження першого елемента бінарного дерева з мінімальним значенням за "постфіксним" обходом
    public Node FindMinPostfix()
    {
        if (root == null)
            return null;

        Node current = root;
        while (current.left != null)
        {
            current = current.left;
        }
        return current;
    }


    private void FindMinPostfixRecursive(Node current, ref Node minNode)
    {
        if (current == null)
            return;

        if (current.info < minNode.info)
            minNode = current;

        FindMinPostfixRecursive(current.left, ref minNode);
        FindMinPostfixRecursive(current.right, ref minNode);
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        int[] values = { 5, 3, 8, 2, 4, 7, 9 };
        tree.CreateTree(values);

        Console.WriteLine("Binary Tree:");
        tree.PrintTree();

        Node minNode = tree.FindMinPostfix();
        Console.WriteLine($"\nFirst minimum element in postfix traversal: {minNode.info}");
    }
}
