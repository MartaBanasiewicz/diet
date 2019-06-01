using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przepisy_i_powiadomienia
{
    class SkladnikiPrzepisy
    {
        public int Id { get; set; }
        public int SkladnikId { get; set; }
        public int PrzepisId { get; set; }
        public int Ilosc { get; set; }
        public int Kalorie { get; set; }
    }
}
