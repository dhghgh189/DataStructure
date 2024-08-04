using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_List_Advanced
{
    public class MyLinkedListNode<T>
    {
        public T Value;

        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;
    }

    public class MyLinkedList<T>
    {
        MyLinkedListNode<T> first;
        public MyLinkedListNode<T> First { get { return first; } }
        
        MyLinkedListNode<T> last;
        public MyLinkedListNode<T> Last { get { return last; } }

        // first 노드의 prev는 null
        public void AddFirst(T Element)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>();
            newNode.Value = Element;
            
            // 새노드의 next 연결
            newNode.Next = first;
            if (first != null)
            {
                first.Prev = newNode;
            }
            else
            {
                last = newNode;
            }

            // 새 노드를 first노드로 기억 한다.
            first = newNode;
        }

        // last 노드의 next는 null
        public void AddLast(T Element)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>();
            newNode.Value = Element;

            // 새노드의 prev 연결
            newNode.Prev = last;
            if (first != null)
            {
                last.Next = newNode;
            }
            else
            {
                first = newNode;
            }

            // 새 노드를 last노드로 기억 한다.
            last = newNode;
        }

        public void RemoveFirst()
        {
            if (first == null)
            {
                Console.WriteLine("리스트가 비었습니다.");
                return;
            }

            // first 제거
            first = first.Next;

            // 기존 first 제거후 노드가 남아있다면 
            if (first != null)
            {
                // 삭제된 기존 first 노드에 대한 참조를 제거
                first.Prev = null;
            }
            // 남아 있지 않다면 last도 초기화
            else
            {
                last = null;
            }
        }

        public void RemoveLast()
        {
            if (last == null)
            {
                Console.WriteLine("리스트가 비었습니다.");
                return;
            }

            // last 제거
            last = last.Prev;

            // 기존 last 제거후 노드가 남아있다면
            if (last != null)
            {
                // 삭제된 기존 last 노드에 대한 참조를 제거
                last.Next = null;
            }
            // 남아 있지 않다면 first도 초기화
            else
            {
                first = null;
            }
        }

        // 모든 데이터 삭제
        public void Clear()
        {
            first = null;
            last = null;
        }
    }
}
