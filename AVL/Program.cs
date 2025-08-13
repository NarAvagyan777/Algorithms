using System;
using System.Collections.Generic;
using System.Linq;
public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val)
    {
        this.val = val;
        this.left = null;
        this.right = null;
    }
}

class MyBinaryTree
{
    public TreeNode? root;

    public MyBinaryTree()
    {
        root = null;
    }
    public TreeNode GetMin(TreeNode root)
    {
        while (root.left != null)
        {
            int left = root.left;
        }
        return root;
    }
    public int Height(TreeNode? node)
    {
        if (node == null)
        {
            return -1;
        }
        int left = Height(node.left);
        int right = Height(node.right);
        return Math.Max(left, right) + 1;
    }
    public int Bf(TreeNode? node)
    {
        if (node == null)
        {
            return 0;
        }
        int res = Height(node.left) - Height(node.right);
        return res;
    }
    private TreeNode RightRotate(TreeNode z)
    {
        if (z == null)
        {
            return null;
        }
        TreeNode tmp = z.left;
        TreeNode T3 = tmp.right;

        tmp.right = z;
        z.left = T3;
        return tmp;
    }
    private TreeNode LeftRotate(TreeNode z)
    {
        if (z == null)
        {
            return null;
        }
        TreeNode tmp = z.right;
        TreeNode T3 = tmp.left;

        tmp.left = z;
        z.right = T3;
        return tmp;
    }
    public TreeNode Insert(TreeNode? node, int val)
    {
        if (node == null)
        {
            return new TreeNode(val);
        }
        if (node.val > val)
        {
            node.left = Insert(node.left, val);
        }
        else if (node.val < val)
        {
            node.right = Insert(node.right, val);
        }
        else
        {
            return node;
        }
        int res = Bf(node);
        if (res < -1 && node.right.val < val)
        {
            return LeftRotate(node);
        }
        if (res < -1 && node.right.val > val)
        {
            node.right = RightRotate(node.right);
            return LeftRotate(node);
        }
        if (res > 1 && node.left.val > val)
        {
            return RightRotate(node);
        }
        if (res > 1 && node.left.val < val)
        {
            node.left = LeftRotate(node.left);
            return RightRotate(node);
        }
        return node;
    }
    public TreeNode Delete(TreeNode node, int val)
    {
        if (node == null)
        {
            return null;
        }
        if (node.val < val)
        {
            int right = Delete(node.right, val);
        }
        if (node.val > val)
        {
            int left = Delete(node.left, val);
        }
        else
        {
            if (node.left == null) return node.right;
            if (node.right == null) return node.left;
            else
            {
                TreeNode tmp = GetMin(node.right);
                (tmp.Value, node.Value) = (node.Value, tmp.Value);
                node.right = Delete(node.right, val);
            }
        }
        int res = Bf(node);
        if (res > 1 && Bf(node.left) < 0)
        {
            node.left = LeftRotate(node.left);
            return RightRotate(node);
        }
        if (res > 1 && Bf(node.left) >= 0)
        {
            return RightRotate(node);
        }
        if (res < -1 && Bf(node.right) > 0)
        {
            node.right = RightRotate(node.right);
            return LeftRotate(node);
        }
        if (res < -1 && Bf(node.right) <= 0)
        {
            return LeftRotate(node);
        }
        return node;
        
    }

}
class Program
{
    static void Main(string[] args)
    {
        MyBinaryTree tree = new MyBinaryTree();

        int[] valuesToInsert = { 30, 20, 40, 10, 25, 35, 50, 5 };

        foreach (int val in valuesToInsert)
        {
            tree.root = tree.Insert(tree.root, val);
        }

        Console.WriteLine("Ծառի բարձրությունը՝ " + tree.Height(tree.root));
        Console.WriteLine("Շտկման գործակից արմատում՝ " + tree.Bf(tree.root));

        // Ցանկության դեպքում՝ բոլոր հանգույցների շտկման գործակիցների արտածում միջանկյալ հերթով
        Console.WriteLine("Միջանկյալ հերթով հանգույցների արտածում՝ շտկման գործակիցներով․");
        PrintInOrder(tree.root, tree);
    }

    static void PrintInOrder(TreeNode? node, MyBinaryTree tree)
    {
        if (node == null)
            return;

        PrintInOrder(node.left, tree);
        Console.WriteLine($"Հանգույց {node.val}-ի շտկման գործակիցը՝ {tree.Bf(node)}");
        PrintInOrder(node.right, tree);
    }
}

