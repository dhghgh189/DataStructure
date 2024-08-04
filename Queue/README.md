# 배열 기반 큐 구현

```cs
public class MyQueue<T>
{
    T[] array;

    int capacity;
    public int Capacity { get { return capacity; } }

    int count;
    public int Count { get { return count; } }

    // dequeue할 데이터의 위치를 가리키는 인덱스
    int front;
    // enqueue할 데이터의 위치를 가리키는 인덱스
    int rear;

    public MyQueue(int capacity = 10)
    {
        this.capacity = capacity;
        this.count = 0;
        array = new T[this.capacity];

        // 큐 구현시 공간 한개를 비워두고 구현하는게 유리함
        // (모든 공간을 써버리면 꽉 찼을때와 비었을때의 판단이 어렵기때문)
        // front와 rear가 같은 곳을 가리키는 형태가 큐가 비어있는 형태
        front = 0;
        rear = 0;
    }

    void MakeNewQueue()
    {
        // 용량을 2배로 증가
        capacity *= 2;
        // 새 배열 할당
        T[] newList = new T[capacity];

        // rear가 array의 마지막 index라면
        if (rear == array.Length-1)
        {
            // 기존값 복사
            for (int i = 0; i < array.Length; i++)
            {
                newList[i] = array[i];
            }
        }
        // rear가 array의 마지막 index가 아니라면
        else
        {
            int halfSize = capacity / 2;
            for (int i = 0; i < array.Length; i++)
            {
                if (i >= front && i <= (front + halfSize))
                {
                    newList[i + halfSize] = array[i];
                }
                else
                {
                    newList[i] = array[i];
                }
            }

            // front를 halfsize만큼 옮김
            for (int i = 0; i < halfSize; i++)
            {
                front = GetNextIndex(front);
            }
        }

        // 복사된 새 배열을 사용
        array = newList;
    }

    // 큐가 꽉찼는지 확인
    bool IsFull()
    {
        // rear 바로 앞에 front가 있으면 큐가 꽉 찬것임
        if (GetNextIndex(rear) == front)
        {
            return true;
        }

        return false;
    }

    // 큐가 비어있는지 확인
    bool IsEmpty()
    {
        // front 와 rear가 같은 곳을 가리키면 큐가 비어있는 것임
        if (front == rear)
        {
            return true;
        }

        return false;
    }

    // 다음 index를 반환
    int GetNextIndex(int index)
    {
        // 현재 index가 마지막 인덱스면
        if (index >= capacity-1)
        {
            // 첫 index로 돌아감
            return 0;
        }

        return index + 1;
    }

    // 배열 맨뒤에 데이터를 추가
    public void Enqueue(T element)
    {
        // 큐가 꽉찼으면
        if (IsFull())
        {
            // 재할당
            MakeNewQueue();
        }

        rear = GetNextIndex(rear);
        array[rear] = element;
        count++;
    }

    // 가장 처음 추가한 데이터를 반환 및 내부 배열에서 삭제
    public T Dequeue()
    {
        // 큐가 비었는지 확인
        if (IsEmpty())
        {
            Console.WriteLine("큐가 비었습니다.");
            return default;
        }

        front = GetNextIndex(front);
        T ret = array[front];
        array[front] = default;
        count--;

        return ret;
    }

    // 가장 처음 추가한 데이터를 반환, 삭제하지 않음
    public T Peek()
    {
        // 큐가 비었는지 확인
        if (IsEmpty())
        {
            Console.WriteLine("큐가 비었습니다.");
            return default;
        }

        T ret = array[GetNextIndex(front)];

        return ret;
    }

    public void Clear()
    {
        Array.Clear(array, 0, capacity);
        count = 0;

        front = 0;
        rear = 0;
    }
}
```
