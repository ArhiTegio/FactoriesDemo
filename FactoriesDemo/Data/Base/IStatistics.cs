using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Shared.Base
{
    public interface IStatistics
    {
        public List<StatisticsWarehouse> StatisticsWarehouses { get; set; }
        public Dictionary<string, List<int>> StatisticsTruckingItems { get; set; }
        delegate void StatisticsChangeHandler(TypeElement type);
        event StatisticsChangeHandler NotifyChange;
        public void Factories_NotifyChange(string nameFactory, string nameItem, int count);

        public void Warehouse_NotifyChange();

        public void TransportCompany_NotifyChange(ITruck truck);
    }
}
