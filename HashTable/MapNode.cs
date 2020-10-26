using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public struct KeyValue<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    }

    class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            var linkedList = GetLinkedList(position);
            var item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }

        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            var linkedList = GetLinkedList(position);
            bool itemFound = false;
            var foundItem = default(KeyValue<K, V>);
            foreach (var item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
        public void RemoveValue(V value)
        {
            foreach (LinkedList<KeyValue<K, V>> list in items)
            {
                if (list == null)
                    continue;
                foreach (KeyValue<K, V> obj in list)
                {
                    if (obj.Equals(null))
                    {
                        continue;
                    }
                    if (obj.Value.Equals(value))
                    {
                        Remove(obj.Key);
                        break;
                    }
                }
            }
        }

        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            var linkedList = GetLinkedList(position);
            foreach (var item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }

        public void Set(K key, V value)
        {
            int position = GetArrayPosition(key);
            var linkedList = GetLinkedList(position);
            KeyValue<K, V> temp = new KeyValue<K, V>();
            foreach (var item in linkedList)
                if (item.Key.Equals(key))
                {
                    temp = item;

                }
            temp.Value = value;
        }

        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            var linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }

        public int GetFrequency(V value)
        {
            int frequency = 0;
            foreach (LinkedList<KeyValue<K, V>> list in items)
            {
                if (list == null)
                {
                    continue;
                }
                foreach (KeyValue<K, V> obj in list)
                {
                    if (obj.Equals(null))
                    {
                        continue;
                    }
                    if (obj.Value.Equals(value))
                    {
                        frequency++;
                    }
                }
            }
            Console.WriteLine("Word '{0}' appears {1} times", value, frequency);
            return frequency;
        }
    }

}