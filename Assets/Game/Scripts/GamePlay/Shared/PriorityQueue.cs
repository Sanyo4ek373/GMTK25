﻿using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class PriorityQueue<T>
    {
        private List<(T item, int priority)> _elements = new();

        public int Count => _elements.Count;

        public void Enqueue(T item, int priority)
        {
            _elements.Add((item, priority));
        }

        public T Dequeue()
        {
            var bestIndex = 0;
            for (int i = 0; i < _elements.Count; i++)
            {
                if (_elements[i].priority < _elements[bestIndex].priority)
                    bestIndex = i;
            }

            var bestItem = _elements[bestIndex].item;
            _elements.RemoveAt(bestIndex);
            return bestItem;
        }

        public bool Contains(T item)
        {
            return _elements.Any(e => EqualityComparer<T>.Default.Equals(e.item, item));
        }
    }
}