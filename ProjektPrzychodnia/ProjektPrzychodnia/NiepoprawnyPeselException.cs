using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPrzychodnia
{
    public class NiepoprawnyPeselException : Exception
    {
        public NiepoprawnyPeselException(string msg) : base(msg)
        {
            
        }
    }
}
