using Factories.Shared.Base;

namespace Factories.Shared
{
    public class Options: IOptions
    {
        public int M { get; set; }
        public int N { get; set; } = new Random().Next(50, 100);
        public int NumberFactories { get; set; } = new Random().Next(3, 10);
        public List<Task> TaskFactories { get; set; } = new List<Task>();
        public Task TaskTransportCompany { get; set; }
        public IWarehouse Warehouse { get; set; }

        public Options() 
        {
            M = new Random().Next(100, 200) * Enumerable.Range(1, NumberFactories).Select(x => 1 + x / 10).Aggregate((x, y) => x + y) * N;
        }

    }
}
