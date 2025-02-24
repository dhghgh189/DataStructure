namespace Study
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> heap = new List<T>();

        // O(logN)
        public void Push(T data)
        {
            // 1. 힙의 맨 끝에 새 데이터를 추가한다.
            heap.Add(data);

            int now = heap.Count - 1;

            // 2. 부모와 비교해서 정렬한다.
            // now가 0이되면 루트이므로 더 비교할게 없으니 종료하게 된다.
            while (now > 0)
            {
                // 부모의 index를 구하는 공식
                int next = (now - 1) / 2;
                if (heap[now].CompareTo(heap[next]) < 0)
                    break; // 종료 조건

                // 두 값을 교체
                T temp = heap[now];
                heap[now] = heap[next];
                heap[next] = temp;

                // 현재 index 갱신
                now = next;
            }
        }

        // O(logN)
        public T Pop()
        {
            // 0. 반환할 데이터 저장
            T ret = heap[0];

            // 1. 마지막 데이터를 루트로 이동시킨다.
            int lastIndex = heap.Count - 1;
            heap[0] = heap[lastIndex];
            heap.RemoveAt(lastIndex);
            lastIndex--;

            // 2. 자식들과 비교하여 정렬한다.
            // 
            int now = 0;
            while (true)
            {
                int left = (now * 2) + 1;
                int right = (now * 2) + 2;

                // 현재 가장 큰 값이 어디있는지 저장할 변수
                // 부모(now)부터 시작
                int next = now;

                // 2-1. 왼쪽값이 현재보다 크면 왼쪽으로 이동
                // 오른쪽 비교도 필요하므로 실제 값을 교체하는게 아니라
                // next에 left 위치를 저장만 해둔다.
                if (left <= lastIndex && heap[left].CompareTo(heap[next]) > 0)
                    next = left;
                // 2-2. 오른쪽값이 현재보다 크면 오른쪽으로 이동
                // 왼쪽을 포함해서 비교하기 위해 else if가 아닌 if문을 그대로 사용
                if (right <= lastIndex && heap[right].CompareTo(heap[next]) > 0)
                    next = right;

                // 왼쪽 오른쪽 모두 부모보다 작으면 종료
                if (next == now)
                    break;

                // 부모(now)와 자식(next)값 교체
                T temp = heap[now];
                heap[now] = heap[next];
                heap[next] = temp;

                // 현재 index 갱신
                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return heap.Count;
        }
    }
}
