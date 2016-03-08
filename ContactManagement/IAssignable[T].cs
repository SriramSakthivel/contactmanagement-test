using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactManagement
{
    interface IAssignable<T>
    {
        void Assign(T other);
    }
}
