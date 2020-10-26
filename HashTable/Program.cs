using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HashTable Demo!");
            MapNode<string, string> hash = new MapNode<string, string>(5);
            hash.Add("0", "A");
            hash.Add("1", "y");
            hash.Add("2", "ed");
            hash.Add("3", "t");
            hash.Add("4", "g");

            string h4 = hash.Get("4");
            Console.WriteLine("4th index value: " + h4);
            //string h2 = hash.Get("2");

        }
    }
}
