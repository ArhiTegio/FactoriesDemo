using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Shared.Base
{
    public interface IOptions
    {
        public int M { get; set; }
        public int N { get; set; }
        public int NumberFactories { get; set; }
        public List<Task> TaskFactories { get; set; }
        public Task TaskTransportCompany { get; set; }
        public IWarehouse Warehouse { get; set; }
    }
}
