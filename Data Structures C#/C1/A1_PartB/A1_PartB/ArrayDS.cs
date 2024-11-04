using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_PartB
{
    internal class ArrayDS
    {
        private static int ARRAY_SIZE = 1000;

        private int ASize { get; set; }

        private Node[] ArrayNodes;

        public ArrayDS()
        {
            ArrayNodes = new Node[ARRAY_SIZE];
            ASize = 0;
        }

        private void InsertNode(Node node)
        {
            //method to insert the node
            int index = 0;
            bool inserted = false;

            while (index < ArrayNodes.Length && !inserted)
            {
                //within array size and inserting node
                if (ArrayNodes[index] == null)
                {
                    //found unallocated location
                    ArrayNodes[index] = node;
                    ASize++; //keeps count of inserted nodes
                    inserted = true;
                }
                index++;
            }
        }

        public void Add(string value, int valueLength)
        {
            //method to call
            Node node = new Node(value, valueLength);
            InsertNode(node);
        }

        private string ToPrintSort(Node[] input)
        {
            StringBuilder sb = new StringBuilder();
            if (input == null)
            {
                //array structure is empty
                return null;
            }

            for (int i = 0; i < input.Length; i++)
            {
                //step through the array outputting all nodes
                sb.Append("[" + i + "] ->");
                if (input[i] == null)
                {
                    //null locations need to be handled
                    sb.Append("empty\n");
                }
                else
                {
                    sb.Append(input[i].ToString() + "\n");
                }
            }
            sb.Append("\nNumber of items: " + ASize.ToString());

            return sb.ToString();
        }

        public string ToPrint()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (ArrayNodes == null)
            { // array structure is empty
                return null;
            }

            //for (int i = 0; i < ArrayNodes.Length; i++)
            for (int i = 0; i < ASize; i++)
            { // step through the array outputting all nodes

                stringBuilder.Append("[" + i + "] -> ");
                if (ArrayNodes[i] == null)
                { // null locations need to be handled
                    stringBuilder.Append("empty\n");
                }
                else
                {
                    stringBuilder.Append(ArrayNodes[i].ToString() + "\n");
                }
            }
            stringBuilder.Append("\nNumber of items: " + ASize.ToString());

            return stringBuilder.ToString();
        }

        //merge sort (O(logn)
        private Node[] MergeSortOp(Node[] input, int left, int right)
        { // Private Merge method to find middle pivot
            int mid;
            if (left < right)
            {
                // Binary split the array by finding mid point
                mid = (left + right) / 2;
                // Recursively call the method until each element is split
                // into its own cell
                MergeSortOp(input, left, mid);
                MergeSortOp(input, mid + 1, right);

                // Merge elements in split arrays
                input = Merge(input, left, mid, right);
            }
            return input;
        }

        private Node[] Merge(Node[] input, int left, int mid, int right)
        {
            int n1 = mid - left + 1; //number of elements in LeftArray
            int n2 = right - mid; // number of elements in RightArray

            Node[] LeftArray = new Node[n1]; // create temp arrays for left and right
            Node[] RightArray = new Node[n2];

            for (int i = 0; i < n1; i++)
            { // copy all elements left of mid split, into a temporary array
                LeftArray[i] = input[left + i];
            }

            for (int i = 0; i < n2; i++)
            { // Copy all elements right of mid split into a temporary array
                RightArray[i] = input[mid + i + 1];
            }

            // x = index for LeftArray, y = index for RightArray,
            // z = the index for the merged array
            int x = 0, y = 0, z = left;
            while (x < n1 && y < n2)
            {
                if (LeftArray[x].wordLen < RightArray[y].wordLen)
                {
                    input[z] = LeftArray[x];
                    x++;
                }
                else
                {
                    input[z] = RightArray[y];
                    y++;
                }
                z++;
            }

            // Copying the remaining elements of LeftArray
            while (x < n1)
            {
                input[z] = LeftArray[x];
                x++;
                z++;
            }

            // Copying the remaining elements of RightArray
            while (y < n2)
            {
                input[z] = RightArray[y];
                y++;
                z++;
            }
            return input;
        }
        public string MergeSort()
        { // UI Call
            StringBuilder sb = new StringBuilder();

            // Use a reference so that the array is not altered
            Node[] input = ArrayNodes;
            input = MergeSortOp(input, 0, ASize - 1);

            sb.Append(ToPrintSort(input));
            return sb.ToString();
        }

        //selection sort (n2)
        public string SelectionSort()
        {
            //use a reference so that the array is not altered
            Node[] input = ArrayNodes;
            StringBuilder sb = new StringBuilder();

            for (var i = 0; i < ASize; i++)
            {
                var min = i; //maintain next position for comparison and number
                for (var j = i + 1; j < ASize; j++)
                {
                    if (input[min].wordLen > input[j].wordLen)
                    {
                        //found the lowest number
                        min = j;
                    }
                }

                if (min != i)
                {
                    //swap the numbers
                    Node lowerValue = input[min];
                    input[min] = input[i];
                    input[i] = lowerValue;
                }
            }
            sb.Append(ToPrint());
            return sb.ToString();
        }
    }
}
