using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Shared.Base
{
    public interface IWarehouse
    {
        public Queue<IItem> Items { get; set; }
        public int Capacity { get; init; }

        delegate void FullnessHandler();
        event FullnessHandler NotifyFullness;

        delegate void ChangeHandler();
        event ChangeHandler NotifyChange;

        public Task AddItem(IItem item);
    }
}
