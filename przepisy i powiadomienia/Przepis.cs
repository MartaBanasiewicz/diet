using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przepisy_i_powiadomienia
{
    class Przepis
    {
        public Przepis(int v1, string v2, int v3 = 0, int v4=0)
        {
            Id = v1;
            Nazwa = v2;
            Ulubiony = v3;
            Kalorie = v4;
        }

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Ulubiony { get; set; }
        public int Kalorie { get; set; }
    }
}
