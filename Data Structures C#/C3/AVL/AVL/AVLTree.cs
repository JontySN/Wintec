using System;
using System.Text;


namespace AVL
{
    internal class AVLTree
    {
        #region Getters, Setters and Constructors
        public Node Root { get; set; }

        public AVLTree()
        {
            Root = null;
        }
        #endregion

        #region Add
        public void Add(string word)
        {
            Node node = new Node(word);

            if (Search(Root, node) != null)
            {
                Console.WriteLine($"Word '{word}' already exists in the AVL tree.");
                return;
            }

            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Root = InsertNode(Root, node);
            }

            Console.WriteLine($"Word '{word}' added to the AVL tree.");
        }
        #endregion

        #region Insert Node
        private Node InsertNode(Node tree, Node node)
        {
            if (tree == null)
            {
                return node; // Return the newly inserted node
            }
            else if (string.Compare(node.Word, tree.Word) < 0)
            {
                tree.Left = InsertNode(tree.Left, node);
                tree = BalanceTree(tree);
            }
            else if (string.Compare(node.Word, tree.Word) > 0)
            {
                tree.Right = InsertNode(tree.Right, node);
                tree = BalanceTree(tree);
            }
            return tree;
        }
        #endregion

        #region Balance Tree
        private Node BalanceTree(Node current)
        {
            int b_factor = BalanceFactor(current);
            if (b_factor > 1)
            {
                if (BalanceFactor(current.Left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (BalanceFactor(current.Right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        #endregion

        #region RotateLL
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        #endregion

        #region RotateRR
        private Node RotateRR(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        #endregion

        #region RotateLR
        private Node RotateLR(Node parent)
        {
            parent.Left = RotateRR(parent.Left);
            return RotateLL(parent);
        }
        #endregion

        #region RotateRL
        private Node RotateRL(Node parent)
        {
            parent.Right = RotateLL(parent.Right);
            return RotateRR(parent);
        }
        #endregion

        #region Get Height
        private int GetHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int left = GetHeight(current.Left);
                int right = GetHeight(current.Right);
                height = Math.Max(left, right) + 1;
            }
            return height;
        }
        #endregion

        #region Balance Factor
        private int BalanceFactor(Node current)
        {
            int left = GetHeight(current.Left);
            int right = GetHeight(current.Right);
            return left - right;
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
            // UI method call for post order
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
            // UI method call for InOrder
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

        #region Details
        public string Details()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("--- Root Node ---\n");
            sb.Append("Root Node: " + Root.ToString() + "\n\n");
            sb.Append("--- Max Tree Depth ---\n");
            sb.Append("Max Tree Depth: " + MaxTreeDepth(Root));

            return sb.ToString();
        }
        #endregion

        #region Max Tree Depth
        private int MaxTreeDepth(Node tree)
        {
            if (tree == null) return 0;
            int left = MaxTreeDepth(tree.Left);
            int right = MaxTreeDepth(tree.Right);

            return Math.Max(left, right) + 1;
        }
        #endregion

        #region Delete
        private Node Delete(Node current, Node target)
        {
            Node parent = null; // pivot node

            if (current == null)
            {
                return null; // reached bottom of tree path
            }
            else
            {
                if (string.Compare(target.Word, current.Word) < 0)
                {
                    current.Left = Delete(current.Left, target);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.Right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                else if (string.Compare(target.Word, current.Word) > 0)
                {
                    current.Right = Delete(current.Right, target);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.Left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                else
                {
                    // target found
                    if (current.Right != null)
                    {
                        parent = current.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }
                        current.Word = parent.Word; // Update the current node's word
                        current.Right = Delete(current.Right, parent);
                        if (BalanceFactor(current) == 2)
                        {
                            if (BalanceFactor(current.Left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else
                            {
                                current = RotateLR(current);
                            }
                        }
                    }
                    else
                    {
                        return current.Left; // left side not null
                    }
                }
            }
            return current;
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
                Console.WriteLine("Target: " + word + ", NODE removed: " + word);
            }
            else
            {
                Console.WriteLine("Target: " + word + ", NODE not found or Tree empty");
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
                    return tree;
                }
                if (string.Compare(node.Word, tree.Word) < 0)
                {
                    return Search(tree.Left, node);
                }
                else
                {
                    return Search(tree.Right, node);
                }
            }
            return null; // Not found
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
                Console.WriteLine("Target: " + word + ", NODE not found or Tree empty");
            }
        }
        #endregion

        #region Clear
        public void Clear()
        {
            Root = null; // Sets root to null to clear list
        }
        #endregion
    }

}
