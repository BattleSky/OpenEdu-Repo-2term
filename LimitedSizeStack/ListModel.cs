using System;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;

namespace TodoApplication
{
    public class ListModel<TItem>
    {
        public List<TItem> Items { get; }
        public int Limit;
        public int CountOfOperations = 0;
        public LimitedSizeStack<Tuple<string, int, TItem>> LastOperations;

        public ListModel(int limit)
        {
            Items = new List<TItem>();
            Limit = limit;
            LastOperations = new LimitedSizeStack<Tuple<string, int, TItem>>(limit);
            }

        public void AddItem(TItem item)
        {
            Items.Add(item);
            LastOperations.Push(new Tuple<string, int, TItem>("added",Items.Count - 1, item));
            if (CountOfOperations < Limit)
                CountOfOperations++;
        }

        public void RemoveItem(int index)
        {
            LastOperations.Push(new Tuple<string, int, TItem>("removed", index, Items[index]));
            Items.RemoveAt(index);
            if (CountOfOperations < Limit)
                CountOfOperations++;
        }

        public bool CanUndo()
        {
            return CountOfOperations > 0;
        }

        public void Undo()
        {
            CountOfOperations--;
            var opeartion = LastOperations.Pop();
            
            switch (opeartion.Item1)
            {
                case "added":
                    Items.Remove(opeartion.Item3);
                    break;
                case "removed":
                    Items.Insert(opeartion.Item2, opeartion.Item3);
                    break;
            }
        }
    }
}
