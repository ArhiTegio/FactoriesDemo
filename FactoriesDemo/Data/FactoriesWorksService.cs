using Factories.Shared;
using Factories.Shared.Base;

namespace FactoriesDemo.Data
{
    public class FactoriesWorksService
    {
        public Options Options { get; set; }
        public IWarehouse Warehouse { get; set; }
        public ITransportCompany TransportCompany { get; set; }
        public List<IFactory> Factories { get; set; } = new List<IFactory>();
        public IStatistics Statistics { get; set; }

        public FactoriesWorksService()
        {
            Options = new Options();
            Warehouse = new Warehouse(Options.M);
            TransportCompany = new TransportCompany(Warehouse);
            for (int i = 0; i < Options.NumberFactories; ++i)
            {
                var name = new string(new char[] { (char)(65 + i) });
                Factories.Add(new Factory(name, (1.0 + (i + 1) / 10) * Options.N, Warehouse));
            }
            Statistics = new Statistics(Factories, Warehouse, TransportCompany);
        }

        public void Start()
        {

        }
    }
}
