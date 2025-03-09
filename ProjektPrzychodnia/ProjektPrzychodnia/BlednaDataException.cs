using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPrzychodnia
{
    public class BlednaDataException : Exception
    {
        public BlednaDataException(string msg) : base(msg)
        {

        }
    }
}
