using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_PartB
{
    internal class Node
    {
        public string Word { get; set; }
        public int wordLen { get; set; }

        public Node()
        {   // Null constructor
            Word = null;
            wordLen = 0;
        }
        public Node(string word, int wordlen)
        {   // Second constructor
            Word = word;
            wordLen = wordlen;
        }
        public override string ToString()
        {   // Default method to export the value of the object
            return "Word: " + Word + ", Length: " + wordLen.ToString();
        }
    }
}
