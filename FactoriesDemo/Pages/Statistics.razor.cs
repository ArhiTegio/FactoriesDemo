using Factories.Shared;
using FactoriesDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Reflection;


namespace FactoriesDemo.Pages
{
    public class StatisticsModel : PageModel
    {
        public FactoriesWorksService FactoriesWork { get; set; }
        public delegate void StatisticsChangeHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e);
        public event StatisticsChangeHandler PropertyChanged;


        public StatisticsModel(FactoriesWorksService factoriesWorks)
        {
            FactoriesWork = factoriesWorks;
            factoriesWorks.Statistics.NotifyChange += Update;
            FactoriesWork.Statistics.StatisticsWarehouses.Add(new StatisticsWarehouse("A", "a", 1));
            FactoriesWork.Statistics.StatisticsWarehouses.Add(new StatisticsWarehouse("B", "b", 2));
            FactoriesWork.Start();
        }

        public void Update(TypeElement type)
        {
            if(type == TypeElement.TransportCompany)
            {
                UpdateTransportCompany();
            }
            else if(type == TypeElement.Factory)
            {
                UpdateFactory();
            }
            else if(type == TypeElement.Warehouse)
            {
                UpdateWarehouse();
            }
        }

        public void UpdateTransportCompany()
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("UpdateTransportCompany"));
        }

        public void UpdateFactory()
        {


            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("UpdateFactory"));
        }

        public void UpdateWarehouse()
        {


            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("UpdateWarehouse"));
        }

    }
}
