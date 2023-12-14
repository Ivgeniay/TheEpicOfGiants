using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeBase.Utility
{
    internal class Repository<T> : IEnumerable<T>
    {
        private List<T> list;

        public Repository() => list = new List<T>();
        public Repository(List<T> list) => this.list = list;
        
        internal T this[int index]
        {
            get
            {
                if (index < 0 || index >= list.Count) throw new IndexOutOfRangeException("Index is out of range");
                return list[index];
            }
            set
            {
                if (index < 0 || index >= list.Count) throw new IndexOutOfRangeException("Index is out of range");
                list[index] = value;
            }
        }

        public void Register(T item)
        {
            if (!list.Contains(item)) 
                list.Add(item);
        }

        public void Unregister(T item)
        {
            if (list.Contains(item))
                list.Remove(item);
        }

        public IEnumerator<T> GetEnumerator() => new RepositoryEnumerator(this);
        IEnumerator IEnumerable.GetEnumerator() =>  GetEnumerator();
        
        private class RepositoryEnumerator : IEnumerator<T>
        {
            private Repository<T> repository;
            private int currentIndex;

            public RepositoryEnumerator(Repository<T> repo)
            {
                repository = repo;
                currentIndex = -1;
            }

            public T Current { get => repository[currentIndex]; }

            object IEnumerator.Current { get => Current; }

            public void Dispose() { }

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < repository.list.Count;
            }

            public void Reset() => currentIndex = -1;
        }
    }
}
