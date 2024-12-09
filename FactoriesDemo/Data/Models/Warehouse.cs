using Factories.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Shared
{
    public class Warehouse : IWarehouse
    {
        public Queue<IItem> Items { get; set; } = new Queue<IItem>();
        public int Capacity { get; init; } = 0;
        public object obj { get; set; }

        public event IWarehouse.FullnessHandler NotifyFullness;
        public event IWarehouse.ChangeHandler NotifyChange;

        public Warehouse(int capacity) 
        {
            Capacity = capacity;
        }

        public async Task AddItem(IItem item)
        {
            lock (obj)
            {
                Items.Enqueue(item);
            }
            NotifyChange?.Invoke();
            if(Items.Count >= Capacity)
            {
                NotifyFullness?.Invoke();
            }
        }
    }
}
