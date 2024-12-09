using Factories.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Factories.Shared
{
    public class Factory : IFactory
    {
        public IItem Item { get; set; }
        public double Rate { get; set; }
        public string Name { get; set; }
        public long Count { get; set; } = 0;
        public IWarehouse Warehouse { get; set; }

        public event IFactory.ChangeHandler NotifyChange;

        public Factory(string name, double rate, IWarehouse warehouse) 
        {
            Rate = rate;
            Name = name;
            Warehouse = warehouse;
            Item = new Item(name.ToLower());
        }

        public async Task CreateItem()
        { 
            var newItem = Item.Clone();
            await Warehouse.AddItem(newItem);
            NotifyChange?.Invoke(Name, newItem.Name, 1);
        }

        public async Task<bool> Wait()
        {
            Thread.Sleep((int)(3600000 / Rate));
            return true;
        }
    }
}
