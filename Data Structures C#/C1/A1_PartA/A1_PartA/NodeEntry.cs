using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_PartA
{
    internal class NodeEntry
    {
        public string Word { get; set; }
        public int wordLen { get; set; }

        public NodeEntry()
        {   // Null constructor
            Word = null;
            wordLen = 0;
        }
        public NodeEntry(string word, int length)
        {   // Second constructor
            Word = word;
            wordLen = length;
        }
        public override string ToString()
        {   // Default method to export the value of the object
            return "Word: " + Word + ", Length: " + wordLen.ToString();
        }
    }
}
