namespace CSharpOop.BinaryTree
{
    class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }      
        public int Data { get; set; }

        public TreeNode(int data)
        {
            Data = data;
        }
    }
}
