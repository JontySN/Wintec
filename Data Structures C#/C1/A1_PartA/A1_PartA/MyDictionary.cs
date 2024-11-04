using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_PartA
{
    internal class DictionaryDS
    {
        Dictionary<string, NodeEntry> myDictionary { get; set; }
        public DictionaryDS()
        {
            // Instantiate the dictionary
            myDictionary = new Dictionary<string, NodeEntry>();
        }

        private void Insert(string key, NodeEntry entry)
        {
            myDictionary.Add(key, entry);
        }

        public void AddOp(string word)
        {
            //Saying if the dictionary contains the word and it doesnt start with '#'
            if (!myDictionary.ContainsKey(word) && !word.StartsWith("#"))
            {
                NodeEntry entry = new NodeEntry(word, word.Length);
                Insert(word, entry);

            }
        }

        public void FindOp(string findWord)
        {
            Console.WriteLine("=== Find items in dictionary ===");
            Console.WriteLine("Find : " + findWord);

            //returns true or false if the word is in the file using "...ContainsKey(string)" 
            Console.WriteLine("Value Exists? - " + myDictionary.ContainsKey(findWord));
            Console.WriteLine();
        }

        public void DeleteOp(string delWord)
        {
            Console.WriteLine("=== Delete items in dictionary ===");
            Console.WriteLine("Deleted: " + delWord);
            //returns true or false if the word is deleted using "...Remove(string)" 
            Console.WriteLine("Value detected - " + myDictionary.Remove(delWord));
            Console.WriteLine();
        }

        public string ToPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== File Contents ===");
            foreach (KeyValuePair<String, NodeEntry> item in myDictionary)
            {
                //Simpliest extraction of a class object
                sb.AppendLine("Key: " + item.Key + ", " + "Node Value: " + item.Value.wordLen + ", " + "Node key: " + item.Value.Word);
            }
            sb.AppendLine("Number of items: " + myDictionary.Count);
            return sb.ToString();
        }

        public void Clear()
        {
            //clears console
            myDictionary.Clear();
        }
    }
}


