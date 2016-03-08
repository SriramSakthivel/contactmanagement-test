using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactManagement.Factories
{
    public interface IFactory<TOutput, TInput1, Tinput2>
    {
        TOutput Create(TInput1 input1, Tinput2 input2);
    }
}
