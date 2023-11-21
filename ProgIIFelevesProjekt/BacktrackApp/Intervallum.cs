using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACWEXB_Feleves
{
    abstract class Idotartam : IIdotartam
    {
        public Fontos Fontossag { get; set; }
        public int Kezdete { get; set; }
        public int Vege { get; set; }
        public Idotartam(Fontos fontossag, int kezdete, int vege)
        {
            this.Fontossag = fontossag;
            this.Kezdete = kezdete;
            this.Vege = vege;
        }
        public bool Tartalmazza(int idopont)
        {
            return this.Kezdete < idopont && idopont < this.Vege;
        }
        public bool Atfedi(IIdotartam idotartam)
        {
            return this.Tartalmazza(idotartam.Kezdete) || this.Tartalmazza(idotartam.Vege) 
                   || idotartam.Tartalmazza(this.Kezdete) || idotartam.Tartalmazza(this.Vege);
        }
    }
}
