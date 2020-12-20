using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AtelierAutov2
{
    [Serializable]
    public class Director : Angajat
    {

        public Director()
        {
            Id = Interlocked.Increment(ref NextId);
            CoefAng = 2D;
        }

        
    }
}
