using Factories.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Shared
{
    public class Truck : ITruck
    {
        public Dictionary<string, int> Items { get; set; } = new Dictionary<string, int>();
        public int Capacity { get; init; }
        public int Count { get; set; } = 0;

        public Truck(int capacity)
        {
            Capacity = capacity;
        }
    }
}
