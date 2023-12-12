using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Numerics;
using test_2;

namespace test_2
{

    class Program
    {
        static void Main(string[] args)
        {
            SomeService service = new SomeService(); //subscriber
            service.StartSomeProcess();
            service.OperationDone += FinishSomeProcess;

        }

        public class MyCollection<T> where T : struct
        {
            private IList<T> _myCollection { get; set; }

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
                if (_myCollection.Count < index)
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

        //handler
        public static void FinishSomeProcess(object sender, SomeProcess arg) => Console.WriteLine($"Process has run with args: {arg.x}");


        //publisher
        public class SomeService
        {
            public event EventHandler<SomeProcess> OperationDone; // eventhandler

            SomeProcess process = new SomeProcess("Custom process");
            public void StartSomeProcess()
            {
                Console.WriteLine($"Process has started...");
                OnProcessCompleted(process);
            }

            protected void OnProcessCompleted(SomeProcess arg)
            {
                OperationDone?.Invoke(this, arg);
            }
        }

        public class SomeProcess : EventArgs
        {
            public string x { get; set; }

            public SomeProcess(string x)
            {
                this.x = x;
            }
        }

    }
}