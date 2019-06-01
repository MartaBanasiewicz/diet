using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przepisy_i_powiadomienia
{
    class Skladnik
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Kalorie { get; set; }

        public Skladnik(int _id, string _nazwa, int _kalorie)
        {
            Id = _id;
            Nazwa = _nazwa;
            Kalorie = _kalorie;
        }

        public Skladnik(int id)
        {
            // pobieranie z bazy konkretnego skladnika
        }
    }
}
