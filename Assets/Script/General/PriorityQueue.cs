using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PriorityQueue<T>
{
    [SerializeField] private List<T> _data;
    private IComparer<T> _comparer;

    public PriorityQueue(IComparer<T> comparer)
    {
        _data = new List<T>();
        _comparer = comparer;
    }

    public void Enqueue(T data)
    {
        _data.Add(data);
        int currentIndex = _data.Count - 1;

        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;
            
            if (_comparer.Compare(_data[currentIndex], _data[parentIndex]) >= 0)
                break;

            (_data[currentIndex], _data[parentIndex]) = (_data[parentIndex], _data[currentIndex]);

            currentIndex = parentIndex;
        }
    }

    public T Dequeue()
    {
        int lastIndex = _data.Count - 1;
        T frontData = _data[0];
        _data[0] = _data[lastIndex];
        _data.RemoveAt(lastIndex--);

        int parentIndex = 0;
        while (true)
        {
            int leftChileIndex = parentIndex * 2 + 1;
            if (leftChileIndex > lastIndex) break;
            
            int rightIndex = leftChileIndex + 1;
            int swapIndex = leftChileIndex;

            if (rightIndex <= lastIndex && _comparer.Compare(_data[rightIndex], _data[leftChileIndex]) < 0)
                swapIndex = rightIndex;
            
            if (_comparer.Compare(_data[parentIndex],_data[swapIndex]) <= 0) break;

            (_data[swapIndex], _data[parentIndex]) = (_data[parentIndex], _data[swapIndex]);
            parentIndex = swapIndex;
        }
        
        return frontData;
    }
    
    public void Clear()
    {
        _data.Clear();
    }

    public T Peek()
    {
        return _data[0];
    }

    public bool TryPeek(out T result)
    {
        var isEmpty = _data.Count <= 0;

        result = isEmpty ? default : Peek();
        return isEmpty == false;
    }

    public int Count()
    {
        return _data.Count;
    }

    public bool IsEmpty()
    {
        return _data.Count <= 0;
    }
}
