using Factories.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Shared
{
    public class TransportCompany : ITransportCompany
    {
        public List<ITruck> Trucks { get; set; } = new List<ITruck>();
        public IWarehouse Warehouse { get; set; }

        public event ITransportCompany.ChangeHandler NotifyChange;

        public TransportCompany(IWarehouse warehouse)
        {
            Warehouse = warehouse;
            var rand = new Random();
            var countTrucks = rand.Next(2, 10);
            for(int i = 0;i < countTrucks; ++i)
            {
                Trucks.Add(new Truck(rand.Next(20, 50)));
            }
            warehouse.NotifyFullness += TakeOutItemsFromWarehouse;
        }

        public void TakeOutItemsFromWarehouse()
        {
            if (Trucks.Count > 0)
            {
                int pos = 0;
                var isEmpty = false;
                while (true)
                {
                    Trucks[pos].Items.Clear();
                    if(Warehouse.Items.Count <= Trucks[pos].Capacity)
                    {
                        isEmpty = true;
                    }
                    while(true)
                    {
                        if(Warehouse.Items.Count == 0)
                        {
                            break;
                        }
                        if (Warehouse.Items.TryDequeue(out var item))
                        {
                            if (Trucks[pos].Items.ContainsKey(item.Name))
                            {
                                Trucks[pos].Items[item.Name] += 1;
                            }
                            else
                            {
                                Trucks[pos].Items.Add(item.Name, 1);
                            }

                        }
                        if (Trucks[pos].Capacity <= Trucks[pos].Count)
                        {
                            break;
                        }
                    }


                    NotifyChange?.Invoke(Trucks[pos]);

                    pos++;
                    if(pos > Trucks.Count - 1)
                    {
                        pos = 0;
                    }

                    if (isEmpty) break;
                    Thread.Sleep(1000);
                }
            }            
        }
    }
}
