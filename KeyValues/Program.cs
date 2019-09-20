using System;
using System.Collections.Generic;

namespace KeyValues
{
    public struct KeyValue<T> //The generic parameter is T.
    {
        public readonly string Key;
        public readonly T Value;  //Value is instantiated with a data type of T
        public KeyValue(string key, T value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
    public class MyDictionary<T>
    {
        int tracker = 0;
        KeyValue<T>[] structArray = new KeyValue<T>[5];
        public T this[string index]
        {
            get
            {
                for (int i = 0; i < structArray.Length; i ++)
                {
                    if (structArray[i].Key == index)
                    {
                        //Printing out the keys and values helps me visualize what is happening
                        Console.WriteLine("From the indexer");
                        Console.WriteLine(structArray[i].Value);
                        Console.WriteLine(structArray[i].Key + "\n");
                        return structArray[i].Value;
                    }
                }
                throw new KeyNotFoundException(index);
            }
            set
            {
                for (int i = 0; i < structArray.Length; i++)
                {
                    if (structArray[i].Key == index)
                    {
                        structArray[i] = new KeyValue<T>(index, value);
                        return;
                    }
                    else if (structArray[i].Key == null)
                    {
                        structArray[i] = new KeyValue<T>(index, value);
                        return;
                    }
                }
              
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //We can put any data type inside of MyDictionary<x> but object seems the most appropriate
            var d = new MyDictionary<object>();
            try
            {
                Console.WriteLine(d["Cats"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            d["Cats"] = 42;
            d["Dogs"] = 17;
            Console.WriteLine($"From the main method \n {(int)d["Cats"]}, {(int)d["Dogs"]}\n \n");
        }
    }
}
