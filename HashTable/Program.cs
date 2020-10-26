using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hash table demo");
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            string para = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            string[] paraWords = para.Split(' ');
            int pLength = paraWords.Length;
            for (int i = 0; i < pLength; i++)
            {
                hash.Add(Convert.ToString(i), paraWords[i]);
            }
            foreach (string word in paraWords)
            {
                hash.GetFrequency(word);
            }
            Console.ReadKey();
        }

    }
}