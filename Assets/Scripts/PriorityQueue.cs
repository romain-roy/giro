using System;
using System.Collections.Generic;

public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> data;

    public PriorityQueue()
    {
        data = new List<T>();
    }

    public void Enqueue(T item)
    {
        data.Add(item);
        int child_index = data.Count - 1; // add element at the end
        while (child_index > 0 )
        {
            int parant_index = (child_index - 1) / 2;
            if (data[child_index].CompareTo(data[parant_index]) >= 0)
                break; // stop when child item is larger than (or equal) parent
            
            T tmp = data[child_index];
            data[child_index] = data[parant_index];
            data[parant_index] = tmp;

            child_index = parant_index;
        }
    }

    public T Dequeue()
    {
        if (data.Count == 0) throw new Exception();
        int last_index = data.Count - 1;
        T frontItem = data[0]; 
        data[0] = data[last_index];
        data.RemoveAt(last_index);
        last_index--;

        int parent_index = 0;
        while (true)
        {
            int left_child_index = 2 * parent_index + 1;
            int child_index = left_child_index;
            if (left_child_index > last_index)
                break;  // no more children
            int right_child_index = left_child_index + 1;
            if (right_child_index <= last_index && data[right_child_index].CompareTo(data[left_child_index]) < 0) 
                // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
                child_index = right_child_index;
            if (data[parent_index].CompareTo(data[child_index]) <= 0)
                break; // parent is smaller than (or equal to) smallest child
            
            T tmp = data[parent_index];
            data[parent_index] = data[child_index];
            data[child_index] = tmp;
            
            parent_index = child_index;
        }
        return frontItem;
    }

    public T Peek()
    {
        T frontItem = data[0];
        return frontItem;
    }

    public int Count()
    {
        return data.Count;
    }

    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < data.Count; ++i)
            s += data[i].ToString() + " ";
        s += "count = " + data.Count;
        return s;
    }
}