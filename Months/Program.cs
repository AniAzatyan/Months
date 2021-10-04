using System;
using System.Collections;

namespace Months
{
    class Program
    {
        static void Main(string[] args)
        {
            Months months = new Months();
            int number = months["April"];
            Console.WriteLine(number);
            foreach (var item in months)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class Months 
    {
        private string[] _items = new string[] {"January","February","March","April","May","June",
            "July","August","September","October","November","December" };
        public int this[string key]
        {
            get
            {
                return GetIndexOfMonth(key);
            }
        }

        private int GetIndexOfMonth(string key)
        {
            int defaultmonth = 0;
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] == key)
                    defaultmonth = i;
            }
            defaultmonth++;
            return defaultmonth;
        }
        public _MonthsEnumerator GetEnumerator()
        {
            return new _MonthsEnumerator(_items, _items.Length);
        }
    }
    public class _MonthsEnumerator
    {
        private int _counter = 0;
        private readonly int _size;
        private readonly string[] _source;
        public _MonthsEnumerator(string[] source, int size)
        {
            _source = source;
            _size = size;
        }
        public object Current => _source[_counter++];

        public bool MoveNext()
        {
            return _counter < _size;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}