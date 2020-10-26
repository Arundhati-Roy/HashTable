using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public class MapNode<K,V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K,V>>[] items;
        public MapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        protected int GetArrayPos(K key)
        {
            int pos = key.GetHashCode() % size;
            return Math.Abs(pos);
        }
        public V Get(K key)
        {
            int pos = GetArrayPos(key);
            LinkedList<KeyValue<K, V>> ll = GetLL(pos);
            foreach(KeyValue<K,V> item in ll)
            {
                if (item.Key.Equals(key))
                    return item.Value;
            }
            return default(V);
        }
        public void Add(K key, V value)
        {
            int pos = GetArrayPos(key);
            LinkedList<KeyValue<K, V>> ll = GetLL(pos);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            ll.AddLast(item);
        }
        public void Remove(K key,V value)
        {
            int pos = GetArrayPos(key);
            LinkedList<KeyValue<K, V>> ll = GetLL(pos);
            bool itemfound = false;
            KeyValue<K, V> foundItem = default( KeyValue<K, V>);
            foreach (KeyValue<K, V> item in ll)
            {
                if (item.Key.Equals(key))
                {
                    itemfound = false;
                    foundItem = item;
                }
            }
            if (itemfound)
                ll.Remove(foundItem);
        }
        protected LinkedList<KeyValue<K,V>> GetLL(int pos)
        {
            LinkedList<KeyValue<K, V>> ll = items[pos];
            if(ll==null)
            {
                ll = new LinkedList<KeyValue<K, V>>();
                items[pos] = ll;
            }
            return ll;

        }
    }

    public struct KeyValue<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }

    }
}
