
namespace AVL
{
    internal class Node
    {
        public string Word { get; set; }
        public int WordLen { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node()
        {
            Word = string.Empty; //chatgpt to help
            WordLen = 0;
            Left = null;
            Right = null;
        }

        public Node(string word)
        {
            this.Word = word;
            this.WordLen = word.Length;
            Left = null;
            Right = null;
        }

        public override string ToString()
        {
            return "Word: " + Word + ", Length: " + WordLen.ToString();
        }
    }
}
