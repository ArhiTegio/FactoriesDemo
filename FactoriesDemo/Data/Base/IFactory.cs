using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Shared.Base
{
    public interface IFactory
    {
        public IItem Item { get; set; }
        public double Rate { get; set; }
        public string Name { get; set; }
        public long Count { get; set; }
        public IWarehouse Warehouse { get; set; }
        delegate void ChangeHandler(string nameFactory, string nameItem, int count);
        event ChangeHandler NotifyChange;

        public Task CreateItem();

        public Task<bool> Wait();

    }
}
