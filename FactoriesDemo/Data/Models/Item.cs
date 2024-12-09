using Factories.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Shared
{
    public class Item : IItem
    {
        public string Name { get; set; }

        public Item(string name)
        {
            Name = name;
        }

        public IItem Clone() => new Item(Name);
    }
}
