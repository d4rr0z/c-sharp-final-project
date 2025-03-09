using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPrzychodnia
{
    public class ZlyNumerException : Exception
    {
        public ZlyNumerException(string msg) : base(msg)
        { 

        }
    }
}
