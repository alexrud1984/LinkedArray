using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrLink
{
    class List<T> : IList<T>
    {
        private const int grFactor = 1;
        private Node<T> head;
        private Node<T> tail;

        public int Size { get; private set; }
        public int Capacity { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index >= Size || index < 0)
                {
                    return default(T);
                }
                return head.Get(index);
            }

            set
            {
                if (index >= Size)                      
                {
                    Size = index;                       
                    Expand();                  
                    Size++;
                }
                head.Set(index,value);
            }
        }


        public List(int capacity)
        {
            Capacity = capacity;
            head = tail = new Node<T>(capacity);
            Size = 0;
        }

        public void Add(T value)
        { 
            Expand();
            tail.Add(value);
            Size++;
        }

        public T Get(int index)
        {
            return this[index];
        }

        public void Insert(int index, T value)
        {
            if (index < 0)
            {
                return;
            }

            if (index > Size)
            {
                Size = index;
            }

            Expand();                  
            head.Insert (index, value);              
            Size++;    
                                          
        }

        public void Remove(int index)
        {
            if (index >= Size || index <0)
            {
                return;
            }
            head.Remove(index);
            Size--;
        }

        //internal methods//

        private void Expand()
        {
            while (Capacity <= Size)
            {
                tail.NextNode = new Node<T>(Capacity * grFactor);
                tail = tail.NextNode;
                Capacity += (Capacity * grFactor);
            }
        }


        //Node class//
        internal class Node<Type> where Type: T
        {
            private Type[] array;
            internal int Size { get; private set;}
            internal Node<Type> NextNode { get; set;}

            internal Node(int nodeSize)
            {
                array = new Type[nodeSize];
                Size = 0;
            }
    
            internal void Add (Type value)
            {
                array[Size] = value;
                Size++;
            }

            internal Type Get(int index)
            {
                if (index < array.Length)
                {
                    return array[index];
                }
                return NextNode.Get(index - array.Length);
            }

            internal void Insert(int index, Type value)
            {
                if (index >= array.Length)
                {
                    Size = array.Length;
                    NextNode.Insert (index - array.Length, value);
                    return;
                }

                if (IsFull())
                {
                    Type temp = array[Size - 1];
                    ShiftRight(Size-1, index);
                    array[index] = value;
                    NextNode.Insert(0, temp);
                    return;
                }

                if (index > Size)
                {
                    Size = index;
                }
                ShiftRight(Size, index);
                array[index] = value;
                Size++;
            }

            internal void Remove(int index)
            {
                if (index >= Size && Size !=0)
                {
                    NextNode.Remove(index - Size);
                    return;
                }

                ShiftLeft(index);
                if (IsFull())
                {
                    if (NextNode == null || NextNode.Size == 0)
                    {
                        array[Size - 1] = default(Type);
                    }
                    else
                    {
                        array[Size - 1] = NextNode.Get(0);
                        NextNode.Remove(0);
                        return;
                    }
                }
                Size--;
            }

            internal bool IsFull()
            {
                if (Size == array.Length)
                {
                    return true;
                }
                return false;
            }

            internal void Set(int index, Type value)
            {
                if (index >= array.Length)
                {
                    Size = array.Length;
                    NextNode.Set(index - array.Length, value);
                    return;
                }

                if (index > Size)
                {
                    Size = index + 1;
                }
                array[index] = value;
            }

            //private methods//
            private void ShiftRight(int shiftFrom, int shiftTill)
            {
                for (int i = shiftFrom; i > shiftTill; i--)
                {
                    array[i] = array[i - 1];
                }
            }

            private void ShiftLeft(int shiftTo)
            {
                for (int i = shiftTo; i < Size-1; i++)
                {
                    array[i] = array[i + 1];
                }
            }

        }

    }
}
