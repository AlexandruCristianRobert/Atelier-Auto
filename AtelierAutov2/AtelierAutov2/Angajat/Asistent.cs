
using System;
using System.Threading;

namespace AtelierAutov2
{
    [Serializable]
    class Asistent:Angajat
    {
        public Asistent()
        {
            Id = Interlocked.Increment(ref NextId);
            CoefAng = 1D;
        }

    }
}
