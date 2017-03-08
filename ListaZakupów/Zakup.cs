using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaZakupów
{
    class Zakup
    {
        public String Nazwa { get; set; }
        public int Ilosc { get; set; }
        public String Jednostka { get; set; }
        public String PrefMarak { get; set; }
        public int CenaMax { get; set; }
    }
}
