using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hash table demo");
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            hash.Add("0", "To");
            hash.Add("1", "be");
            hash.Add("2", "or");
            hash.Add("3", "not");
            hash.Add("4", "to");
            hash.Add("5", "be");
            string checkFreq = "be";
            int freq = hash.GetFrequency(checkFreq);
            Console.WriteLine("Frequency of {0} is {1}", checkFreq, freq);
            Console.ReadKey();
        }

    }
}