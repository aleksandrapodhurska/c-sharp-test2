using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Numerics;

namespace test_2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public class MyCollection<T> where T : struct
    {
        private IList<T> _myCollection { get; set;}

        private MyCollection(IList<T> collection)
        {
            if (collection.Count > 0)
            {
                _myCollection = collection;
            }
        }

        public void AddItem(T item)
        {
            _myCollection.Add(item);
        }


        public T GetSingleItem(int index)
        {
            if(_myCollection.Count < index)
            {
                return _myCollection.ElementAt(index - 1);
            }

            return _myCollection.ElementAt(0);
        }

        public ICollection<T> SortDescending()
        {
            return (ICollection<T>)_myCollection.OrderDescending();
        }
    }

}

