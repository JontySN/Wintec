
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    internal class DList
    {
        #region Getters, Setters, and Constructors

        private static DList dList = new DList();
        public Node Head { get; set; }

        public Node Tail { get; set; }

        public Node Current { get; set; }

        public int WordLen { get; set; }

        public int Counter { get; set; }

        public DList()
        {
            Head = null;
            Tail = null;
            Current = null;
            Counter = 0;
            WordLen = 0;
        }
        #endregion

        #region Add to Front
        private void InsertAtFront(Node node)
        {
            // 1.Check if list is null
            if (Head == null)
            { // List is empty
                Head = node;
                Tail = node;
                Current = node;
            }
            else
            {   // 2. Attach the list to the new node
                node.Next = Head;
                Head.Prev = node;

                // 3. Reassign Head to new node to keep head at top of stack
                Head = node;
                Current = node;
            }

            Counter++;
        }

        public void AddToFront(string Word, int wordLen)
        {   // UI method call
            if (!Contains(Word) && !Word.StartsWith("#"))
            {
                Node temp = new Node(Word, wordLen);
                InsertAtFront(temp);
            }
            else
            {
                Console.WriteLine("Duplicate or invalid input.");
            }
        }
        #endregion

        #region Add to Rear
        private void InsertAtRear(Node node)
        {
            // 1. Check if list is empty
            if (Head == null)
            {   // 2. Make Head, Tail and Current the new node
                Head = node;
                Tail = node;
                Current = node;
            }
            else
            {   // 3. Insert node at the end of the list
                Tail.Next = node;
                node.Prev = Tail;

                // 4. Reassign the Tail to the new node
                Tail = node;
                Current = node;
            }
            Counter++;
        }

        public void AddToEnd(string Word, int wordLen)
        {   // UI method call
            if (!Contains(Word) && !Word.StartsWith("#"))
            {
                Node temp = new Node(Word, wordLen);
                InsertAtRear(temp);
            }
            else
            {
                Console.WriteLine("Duplicate or invalid input");
            }
        }
        #endregion

        #region Add Before
        private bool InsertBefore(Node node, Node targetNode)
        {
            bool inserted = false;
            if (Head == null)
            {
                // list is empty
                return inserted;
            }

            if (targetNode.Word == Head.Word)
            {
                // insert node as new head
                InsertAtFront(node);
                inserted = true;
            }
            else
            {
                // list is not empty
                Current = Head;

                while (Current != null && !inserted)
                {
                    // traverse the list
                    if (Current.Word == targetNode.Word)
                    {
                        // target node found
                        node.Next = Current;
                        node.Prev = Current.Prev;
                        Current.Prev.Next = node;
                        Current.Prev = node;
                        inserted = true;
                        Counter++;
                    }
                    else
                    {
                        Current = Current.Next;
                    }
                }
            }
            return inserted;
        }

        public string AddBefore(string Word, int wordLen, string target)
        {
            Node newNode = new Node(Word, wordLen);
            if (Contains(Word) || Word.StartsWith("#"))
            {
                return "Duplicate or Invalid input";
            }

            Node targetNode = FindNode(target);
            if (InsertBefore(newNode, targetNode))
            {
                return "Target" + targetNode.ToString() + "found, NODE: " + newNode.ToString() + "inserted";
            }
            else
            {
                return "Target" + targetNode.ToString() + "NOT found, NODE: " + newNode.ToString() + "NOT inserted";
            }
        }
        #endregion 

        #region Add After
        private bool InsertAfter(Node node, Node targetNode)
        {
            bool inserted = false;
            if (Head == null)
            {
                // list is empty
                return inserted;
            }

            // traverse the list
            Current = Head;

            while (Current != null && !inserted)
            {
                if (Current.Word == targetNode.Word)
                {
                    // target node found
                    if (Current == Tail)
                    {
                        InsertAtRear(node);  // If it's the last node, add it at the rear.
                    }
                    else
                    {
                        node.Next = Current.Next;  // Point new node to the next node.
                        node.Prev = Current;       // Set new node's previous to current.
                        node.Next.Prev = node;  // Set the next node's previous pointer to new node.
                        Current.Next = node;
                        Current = node;        // Point current node's next to the new node.
                    }
                    inserted = true;
                    Counter++;
                }
                else
                {
                    Current = Current.Next;  // Move to the next node.
                }
            }
            return inserted;
        }

        public string AddAfter(string Word, int wordLen, string target)
        {
            Node newNode = new Node(Word, wordLen);
            if (Contains(Word) || Word.StartsWith("#"))
            {
                return "Duplicate or Invalid input";
            }

            Node targetNode = FindNode(target);
            if (InsertAfter(newNode, targetNode))
            {
                return "Target" + targetNode.ToString() + " found, NODE: " + newNode.ToString() + " inserted";
            }
            else
            {
                return "Target" + targetNode.ToString() + " NOT found, NODE: " + newNode.ToString() + " NOT inserted";
            }
        }
        #endregion

        #region Delete at front
        private Node DeleteAtFront()
        {
            if (Head == null)
            {
                return null;
            }
            else
            {
                Node nodeToRemove = new Node();
                nodeToRemove = Head;

                //Reassign head to next node in list
                Head = Head.Next;
                Head.Prev = null;
                Current = Head;
                Counter--;

                return nodeToRemove;
            }
        }

        public string DeleteFront()
        {   // UI method call
            Node nodeToRemove = new Node();
            nodeToRemove = DeleteAtFront();
            if (nodeToRemove != null)
            {   // return node deleted
                return "Found, NODE: " + nodeToRemove.ToString() + " removed";
            }
            else
            {
                return "NOT found, OR list empty";
            }
        }
        #endregion

        #region Delete at End
        private Node DeleteAtEnd()
        {
            if (Head == null)
            {
                return null;
            }
            else
            {
                Node nodeToRemove = new Node();
                nodeToRemove = Tail;

                //Reassign head to next node in list
                Tail = Tail.Prev;
                Tail.Next = null;
                Current = Tail;
                Counter--;

                return nodeToRemove;
            }
        }

        public string DeleteEnd()
        {   // UI method call
            Node nodeToRemove = null;
            nodeToRemove = DeleteAtEnd();
            if (nodeToRemove != null)
            {   // return node deleted
                return "NODE: " + nodeToRemove.ToString() + " removed";
            }
            else
            {
                return "Deletion failed - List empty";
            }
        }
        #endregion

        #region Delete Node by Word
        private Node DeleteNode(Node nodeToDelete)
        {
            Node nodeToRemove = null;
            if (Head == null)
            {   // Check if list is empty
                nodeToRemove = null;
            }
            else if (Head.Word == nodeToDelete.Word)
            {   // node to remove is the head
                nodeToRemove = Head;
                DeleteAtFront();
            }
            else if (Tail.Word == nodeToDelete.Word)
            {   // node to remove is the tail
                nodeToRemove = Tail;
                DeleteAtEnd();
            }
            else
            {   // node in middle, traverse through list
                Current = Head;
                bool deleted = false;
                while (Current != null && !deleted)
                {   // not at the end of the list or found
                    if (Current.Word == nodeToDelete.Word)
                    {   // Found node, use the previous node and next node
                        // to remove current node from list
                        nodeToRemove = Current;
                        Current.Next.Prev = Current.Prev;
                        Current.Prev.Next = Current.Next;
                        deleted = true;
                        Counter--;
                    }
                    Current = Current.Next;
                }
            }
            return nodeToRemove;
        }

        public string RemoveWord(string word)
        {
            Node nodeToDelete = FindNode(word);
            if (nodeToDelete != null)
            {
                DeleteNode(nodeToDelete);
                return $"the word '{word}' has been deleted";
            }
            else
            {
                return $"the word '{word}' is not in list or list is empty";
            }
        }

        #endregion

        #region Searching
        private int Search(Node nodeToFind)
        {
            int pos = 0; // returns position of node, or 0 if not found
            if (Head == null)
            {   // Check if list is empty
                return pos;
            }
            else
            {
                Current = Head;
                bool found = false;
                while (Current != null && !found)
                {   //traverse list 
                    if (Current.Word == nodeToFind.Word)
                    {   //found node
                        found = true;
                    }
                    else
                    {   // step to next node
                        Current = Current.Next;
                    }
                    pos++;
                }
                if (!found) { pos = 0; }
            }
            return pos;
        }

        public string Find(string Word)
        {
            int pos = 0;
            Node nodeToFind = new Node(Word, Word.Length);
            pos = Search(nodeToFind);
            if (pos >= 1 && pos <= Counter)
            {
                return "Target: " + Word.ToString() + ", NODE found at position: " + pos.ToString();
            }
            else
            {
                return "Target: " + Word.ToString() + ", NODE not found, OR list is empty";
            }
        }

        public Node FindNode(string target)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Word.ToLower() == target.ToLower()) 
                {
                    return current;
                }
                current = current.Next;
            }
            return null;  // Target not found
        }

        #endregion

        #region To Print
        public override string ToString()
        {   // Check if list is empty
            StringBuilder sb = new StringBuilder();
            if (Head == null)
            {
                sb.Append("Stack is empty\n");
                return sb.ToString();
            }
            else
            {
                Current = Head;
                int pos = 1; //Node position
                while (Current != null)
                {
                    // Node ToString override
                    sb.Append("Node: " + pos.ToString() + " -> " + Current.ToString() + "\n");
                    sb.AppendLine("Number of items: " + Counter);
                    Current = Current.Next;
                    pos++;
                }
            }
            return sb.ToString();
        }

        public void ToPrint()
        {
            if (Head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            Node current = Head;
            int pos = 1;
            while (current != null)
            {
                Console.WriteLine($"Node {pos}: {current}");
                current = current.Next;
                pos++;
            }
        }
        #endregion

        #region Validation
        private bool Contains(string word)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Word == word)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        #endregion

        #region List Clear
        public void ListClear()
        {
            Head = null;
            Tail = null;
            Current = null;
            Counter = 0;
        }
        #endregion
    }
}