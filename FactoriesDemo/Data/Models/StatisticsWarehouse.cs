using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Shared
{
    public class StatisticsWarehouse
    {
        public DateTime Create { get; set; } 
        public string NameFactory { get; set; }
        public string NameItem { get; set; }
        public int Count { get; set; }
        public StatisticsWarehouse(string nameFactory, string nameItem, int count) 
        {
            Create = DateTime.Now;
            NameFactory = nameFactory;
            NameItem = nameItem;
            Count = count;
        }
    }
}
