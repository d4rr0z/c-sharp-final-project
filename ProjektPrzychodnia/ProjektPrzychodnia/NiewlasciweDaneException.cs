using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPrzychodnia
{
    public class NiewlasciweDaneException : Exception
    {
        public NiewlasciweDaneException(string msg) : base(msg)
        {

        }
    }
}
