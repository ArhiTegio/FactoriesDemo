using Factories.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Shared
{
    public class Statistics: IStatistics
    {
        public List<IFactory> Factories { get; set; }
        public IWarehouse Warehouse { get; set; }
        public ITransportCompany TransportCompany { get; set; }

        public List<StatisticsWarehouse> StatisticsWarehouses { get; set; } = new List<StatisticsWarehouse>();
        public Dictionary<string, List<int>> StatisticsTruckingItems { get; set; } = new Dictionary<string, List<int>>();

        public Statistics(List<IFactory> factories, IWarehouse warehouse, ITransportCompany transportCompany)
        {
            foreach(var factory in factories)
            {
                factory.NotifyChange += Factories_NotifyChange;
            }
            warehouse.NotifyChange += Warehouse_NotifyChange;
            transportCompany.NotifyChange += TransportCompany_NotifyChange;

            Factories = factories;
            Warehouse = warehouse;
            TransportCompany = transportCompany;
        }

        public event IStatistics.StatisticsChangeHandler NotifyChange;

        public void Factories_NotifyChange(string nameFactory, string nameItem, int count)
        {
            if(StatisticsWarehouses.Count == 0)
            {
                StatisticsWarehouses.Add(new StatisticsWarehouse(nameFactory, nameItem, count));
            }
            else if (StatisticsWarehouses[StatisticsWarehouses.Count - 1].NameFactory.Equals(nameFactory))
            {
                StatisticsWarehouses[StatisticsWarehouses.Count - 1].Count += count;
            }

            NotifyChange?.Invoke(TypeElement.Factory);
        }

        public void Warehouse_NotifyChange()
        {
            NotifyChange?.Invoke(TypeElement.Warehouse);
        }

        public void TransportCompany_NotifyChange(ITruck truck)
        {
            foreach(var val in truck.Items)
            {
                if(StatisticsTruckingItems.ContainsKey(val.Key))
                {
                    StatisticsTruckingItems[val.Key].Add(val.Value);
                }
                else
                {
                    StatisticsTruckingItems.Add(val.Key, new List<int>() { val.Value });
                }
            }

            NotifyChange?.Invoke(TypeElement.TransportCompany);
        }
    }
}
