using System;
using System.Text;

namespace BST
{
    internal class BSTree
    {
        #region Getters, Setters, And Constructors
        public Node Root { get; set; }

        public BSTree()
        {
            Root = null;
        }
        #endregion

        #region Add
        public void Add(string word)
        {   // UI call
            Node node = new Node(word);

            if (Root == null)
            {
                Root = node;
                Console.WriteLine($"Word: '{word}' added to the tree.");
            }
            else
            {
                InsertNode(Root, node);
            }
        }
        #endregion

        #region Insert Node
        public void InsertNode(Node tree, Node node)
        {
            if (string.Compare(node.Word, tree.Word) < 0)
            {
                if (tree.Left == null)
                {
                    tree.Left = node;
                    Console.WriteLine($"Word: '{node.Word}' added to the tree.");
                }
                else
                {
                    InsertNode(tree.Left, node);
                }
            }
            
            else if (string.Compare(node.Word, tree.Word) > 0)
            {
                if (tree.Right == null)
                {
                    tree.Right = node;
                    Console.WriteLine($"Word: '{node.Word}' added to the tree.");
                }
                else
                {
                    InsertNode(tree.Right, node);
                }
            }
            else
            {
                // Word is a duplicate
                Console.WriteLine($"Error: Word '{node.Word}' already exists in the tree.");
            }
        }
        #endregion

        #region Traverse PreOrder
        private string TraversePreOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(node.ToString() + " ");
                sb.Append(TraversePreOrder(node.Left));
                sb.Append(TraversePreOrder(node.Right));
            }
            return sb.ToString();
        }
        #endregion

        #region PreOrder
        public string PreOrder()
        {   // UI method for preorder
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("TREE is EMPTY");
            }
            else
            {
                sb.Append(TraversePreOrder(Root));
            }
            return sb.ToString();
        }
        #endregion

        #region Traverse PostOrder
        private string TraversePostOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(TraversePostOrder(node.Left));
                sb.Append(node.ToString() + " ");
                sb.Append(TraversePostOrder(node.Right));
            }
            return sb.ToString();
        }
        #endregion

        #region Post Order
        public string PostOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("TREE is EMPTY");
            }
            else
            {
                sb.Append(TraversePostOrder(Root));
            }

            return sb.ToString();
        }
        #endregion

        #region Traverse InOrder
        private string TraverseInOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(TraverseInOrder(node.Left));
                sb.Append(TraverseInOrder(node.Right));
                sb.Append(node.ToString() + " ");
            }
            return sb.ToString();
        }
        #endregion

        #region InOrder
        public string InOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("TREE is EMPTY");
            }
            else
            {
                sb.Append(TraverseInOrder(Root));
            }

            return sb.ToString();
        }
        #endregion

        #region Delete
        private Node Delete(Node tree, Node node)
        {
            if (tree == null)
            {
                return tree;
            }
            if (string.Compare(node.Word, tree.Word) < 0)
            {
                // Traverse left side to find node
                tree.Left = Delete(tree.Left, node);
            }
            else if (string.Compare(node.Word, tree.Word) > 0)
            {
                // Traverse right side to find node
                tree.Right = Delete(tree.Right, node);
            }
            else
            {
                // Found node to delete
                if (tree.Left == null)
                {
                    return tree.Right;
                }
                else if (tree.Right == null)
                {
                    return tree.Left;
                }
                else
                {
                    tree.Word = MinValue(tree.Right);

                    tree.Right = Delete(tree.Right, new Node(tree.Word));
                }
            }
            return tree;
        }
        #endregion

        #region MinValue
        private string MinValue(Node node)
        {
            // Find the minimum node in the right side of the tree
            string minval = node.Word;
            while (node.Left != null)
            {
                // Traverse the tree replacing the minval with the 
                // node on the left side of the tree
                minval = node.Left.Word;
                node = node.Left;
            }
            return minval;
        }
        #endregion

        #region Remove
        public void Remove(string word)
        {
            Node node = new Node(word);
            node = Search(Root, node);

            if (node != null)
            {
                Root = Delete(Root, node);
                Console.WriteLine("Target: " + word + ", NODE removed");
            }
            else
            {
                Console.WriteLine("Target: " + word + ", NODE not found");
            }
        }
        #endregion

        #region Search
        private Node Search(Node tree, Node node)
        {
            if (tree != null)
            {
                if (node.Word == tree.Word)
                {
                    // Found node
                    return tree;
                }
                if (string.Compare(node.Word, tree.Word) < 0)
                {
                    // Traverse left side
                    return Search(tree.Left, node);
                }
                else
                {
                    // Traverse right side
                    return Search(tree.Right, node);
                }
            }
            // Not found
            return null;
        }
        #endregion

        #region Find
        public void Find(string word)
        {
            Node node = new Node(word);
            node = Search(Root, node);

            if (node != null)
            {
                Console.WriteLine("Target: " + word + ", NODE found: " + node.ToString());
            }
            else
            {
                Console.WriteLine("Target: " + word + ", NODE not found or tree is empty");
            }
        }
        #endregion

        #region Clear
        public void Clear()
        {
            Root = null;
        }
        #endregion
    }
}
