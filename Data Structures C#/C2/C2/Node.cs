using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    internal class Node
    {
        public string Word { get; set; }

        public int wordLen { get; set; }

        public Node Next { get; set; }

        public Node Prev { get; set; }

        public Node()
        {
            Next = null;
            Prev = null;
        }

        public Node(string key, int data)
        {
            this.Word = key;
            this.wordLen = data;
            Next = null;
            Prev = null;
        }
        public override string ToString()
        {
            // Sets default method to export the value of the object
            return "Word: " + Word + ", Length: " + wordLen.ToString();
        }
    }
}