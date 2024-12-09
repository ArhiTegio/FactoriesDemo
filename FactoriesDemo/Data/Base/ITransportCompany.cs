using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Shared.Base
{
    public interface ITransportCompany
    {
        public List<ITruck> Trucks { get; set; }
        public IWarehouse Warehouse { get; set; }

        delegate void ChangeHandler(ITruck truck);
        event ChangeHandler NotifyChange;

        public void TakeOutItemsFromWarehouse();

    }
}
