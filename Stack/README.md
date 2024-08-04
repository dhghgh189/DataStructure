# 배열 기반 스택 구현

```cs
public class MyStack<T>
{
    T[] array;

    int capacity;
    public int Capacity { get { return capacity; } }

    int count;
    public int Count { get { return count; } }

    public MyStack(int capacity = 10)
    {
        this.capacity = capacity;
        this.count = 0;
        array = new T[this.capacity];
    }

    void MakeNewArray()
    {
        // 용량을 2배로 증가
        capacity *= 2;
        // 새 배열 할당
        T[] newList = new T[capacity];
        // 기존값 복사
        for (int i = 0; i < count; i++)
        {
            newList[i] = array[i];
        }
        // 복사된 새 배열을 사용
        array = newList;
    }

    // 맨 뒤에 데이터 추가
    public void Push(T element)
    {
        // 용량을 넘으면 2배 크기의 배열을 재 할당
        if (count >= capacity)
        {
            MakeNewArray();
        }

        array[count++] = element;
    }

    // 가장 마지막에 추가한 데이터 반환 및 내부 배열에서 삭제한다.
    public T Pop()
    {
        if (count <= 0)
        {
            Console.WriteLine("스택이 비었습니다.");
            return default;
        }

        T ret = array[count-1];
        array[count - 1] = default;
        count--;

        return ret;
    }

    // 가장 마지막에 추가한 데이터 반환, 내부 배열에서 삭제하지 않는다.
    public T Peek()
    {
        if (count <= 0)
        {
            Console.WriteLine("스택이 비었습니다.");
            return default;
        }

        T ret = array[count - 1];

        return ret;
    }

    // 모든값과 count를 초기화
    public void Clear()
    {
        Array.Clear(array, 0, capacity);
        count = 0;
    }
}
```
