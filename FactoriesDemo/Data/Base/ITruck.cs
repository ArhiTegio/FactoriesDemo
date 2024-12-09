using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Shared.Base
{
    public interface ITruck
    {
        Dictionary<string, int> Items { get; set; }
        public int Capacity { get; init; }
        public int Count { get; set; }
    }
}
