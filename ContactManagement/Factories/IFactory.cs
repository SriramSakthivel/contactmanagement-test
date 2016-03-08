using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactManagement.Factories
{
    public interface IFactory<TOutput>
    {
        TOutput Create();
    }
}
