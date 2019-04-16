using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntMapGenerator.Utilities
{
    [System.Serializable]
    public class PriorityList<T> : IList<T> where T:IPrioritizable
    {
        [SerializeField]
        protected List<T> list;

        public PriorityList()
        {
            list = new List<T>();
        }

        public PriorityList(int capactiy)
        {
            list = new List<T>(capactiy);
        }

        public virtual T this[int index]
        {
            get { return list[index]; }
            set
            {
                list.Add(value);      
            }
        }

        public virtual int Count { get { return list.Count; } }

        public virtual bool IsReadOnly { get { return false; } }

        public virtual void Add(T item)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (item.Priority < list[i].Priority)
                {
                    list.Insert(i, item);
                    return;
                }
            }
            list.Add(item);
        }

        public virtual void Clear()
        {
            list.Clear();
        }

        public virtual bool Contains(T item)
        {
            return list.Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public virtual int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public virtual void Insert(int index, T item)
        {
            Add(item);
        }

        public virtual bool Remove(T item)
        {
            return list.Remove(item);
        }

        public virtual void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }

}
