using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AtelierAutov2
{
    [Serializable]
    public class Mecanic:Angajat
    {


        public Mecanic()
        {
            Id = Interlocked.Increment(ref NextId);
            CoefAng = 1.5D;
        }
    }
}
