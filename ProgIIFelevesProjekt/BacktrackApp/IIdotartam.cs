using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACWEXB_Feleves
{
    enum Fontos { nagyon_alacsony = 1, alacsony = 2, kozepes = 3, fontos = 4, nagyon_fontos = 5 }
    interface IIdotartam
    {       
        Fontos Fontossag { get; set; } //Az adott program fontosságát írja le.
        int Kezdete { get; set; } //A program kezdeti időpontja, egy napon belüli percben.
        int Vege { get; set; } //A program végének az időpontja, ez is szintén percben van.

        bool Tartalmazza(int idopont); //Az adattagok által leírt időtartam tartalmaz-e kapott időpontot. Igaz/Hamis
        bool Atfedi(IIdotartam idotartam); //Az időpont átfedésben van-e paraméterben megadott időponttal. Igaz/Hamis
    }
}
