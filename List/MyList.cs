using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_List_Advanced
{
    public class MyList<T>
    {
        T[] list;

        int capacity;
        public int Capacity { get { return capacity; } }

        int count;
        public int Count { get { return count; } }

        public MyList(int capacity = 10) 
        {
            this.capacity = capacity;
            this.count = 0;
            list = new T[this.capacity];
        }

        void MakeNewList()
        {
            // 용량을 2배로 증가
            capacity *= 2;
            // 새 배열 할당
            T[] newList = new T[capacity];
            // 기존값 복사
            for (int i = 0; i < count; i++)
            {
                newList[i] = list[i];
            }
            // 복사된 새 배열을 사용
            list = newList;
        }

        public void Add(T element)
        {
            // 용량을 넘으면 2배 크기의 배열을 재 할당
            if (count >= capacity)
            {
                MakeNewList();
            }

            list[count++] = element;
        }

        // element와 일치하는 요소 중 처음 만난 한개만 지움
        // 요소가 존재해서 지웠으면 true, 요소가 존재하지 않았으면 false 반환
        // 지운 요소 위치의 뒷쪽에 있는 요소들을 앞으로 하나씩 당김
        public bool Remove(T element)
        {
            int removeIndex = -1;
            for (int i = 0; i < count; i++)
            {
                if (list[i].Equals(element))
                {
                    removeIndex = i;
                    break;
                }
            }

            // element와 일치하는 요소가 없음
            if (removeIndex == -1)
                return false;

            Replace(removeIndex);
            count--;

            return true;
        }

        // 배열의 index 매개변수 위치에 있는 요소를 삭제
        // 존재하지 않는 index 예외처리 필요
        // 지운 요소 위치의 뒷쪽에 있는 요소들을 앞으로 하나씩 당김
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("Exception : Out of index!");
                return;
            }

            Replace(index);
            count--;
        }

        // 값 삭제로 인한 모든 요소 재배치 
        void Replace(int removeIndex)
        {
            for (int i = removeIndex; i < count; i++)
            {
                // 마지막 index면 0으로
                if (i >= count - 1)
                {
                    list[i] = default;
                }
                // 마지막 index가 아니면 다음 index에 있는 요소를 당겨온다.
                else
                {
                    list[i] = list[i + 1];
                }
            }
        }

        // 모든값과 count를 초기화
        public void Clear()
        {
            Array.Clear(list, 0, capacity);
            count = 0;
        }
    }
}
