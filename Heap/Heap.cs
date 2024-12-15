using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programm
{
    public class Heap
    {
        private List<int> heap;

        public Heap()
        {
            heap = new List<int>();
        }

        private int Parent(int index) => (index - 1) / 2;
        private int LeftChild(int index) => 2 * index + 1;
        private int RightChild(int index) => 2 * index + 2;

        private void SiftUp(int index)
        {
            while (index > 0 && heap[Parent(index)] > heap[index])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private void SiftDown(int index)
        {
            int minIndex = index;
            int left = LeftChild(index);
            int right = RightChild(index);

            if (left < heap.Count && heap[left] < heap[minIndex])
                minIndex = left;
            if (right < heap.Count && heap[right] < heap[minIndex])
                minIndex = right;

            if (index != minIndex)
            {
                Swap(index, minIndex);
                SiftDown(minIndex);
            }
        }

        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        public void Add(int value)
        {
            heap.Add(value);
            SiftUp(heap.Count - 1);
        }

        public int RemoveMin()
        {
            if (heap.Count == 0)
                return int.MaxValue;

            int minValue = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            if (heap.Count > 0)
                SiftDown(0);

            return minValue;
        }

        public void DecreaseKey(int index, int newValue)
        {
            if (index < 0 || index >= heap.Count)
                return;

            if (newValue > heap[index])
                return;

            heap[index] -= newValue;
            SiftUp(index);
        }

        public void IncreaseKey(int index, int newValue)
        {
            if (index < 0 || index >= heap.Count)
                return;

            if (newValue < heap[index])
                return;

            heap[index] += newValue;
            SiftDown(index);
        }

        public override string ToString()
        {
            return string.Join(", ", heap);
        }
    }
}
