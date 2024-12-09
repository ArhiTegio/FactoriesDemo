using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Shared.Base
{
    public interface IItem
    {
        public string Name { get; set; }

        public IItem Clone();
    }
}
