namespace ConsoleApp1;

public class Task2
{
    public bool IsValidBST(TreeNode root)
    {
        if (root.left != null)
        {
            if (root.val <= root.left.val || !IsValidSubTree(root.left, null, root.val)) return false;
        }
        if (root.right != null)
        {
            if (root.val >= root.right.val || !IsValidSubTree(root.right, root.val, null)) return false;
        }

        return true;
    }

    private bool IsValidSubTree(TreeNode root, int? minVal, int? maxVal)
    {
        if (root.left != null)
        {
            if (root.val <= root.left.val ||
                (minVal.HasValue && root.left.val <= minVal))
            {
                return false;
            }
            if (!IsValidSubTree(root.left, minVal, root.val))
            {
                return false;
            }
        }
        if (root.right != null)
        {
            if (root.val >= root.right.val ||
                (maxVal.HasValue && root.right.val >= maxVal))
            {
                return false;
            }
            if (!IsValidSubTree(root.right, root.val, maxVal))
            {
                return false;
            }
        }

        return true;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
