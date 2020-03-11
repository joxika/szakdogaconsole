using System;
using System.Collections.Generic;
using System.Text;

namespace Szakdoga_console
{
    class Mezo
    {
        public int tipus;
        public string tulajdonos;
        public int ide;
        public int energia;
        public int range;
        

        public Mezo(int tipus, string tulajdonos, int ide, int energia, int range)
        {
            this.tipus = tipus;
            this.tulajdonos = tulajdonos;
            this.ide = ide;
            this.energia = energia;
            this.range = range;
        }
    }
}
