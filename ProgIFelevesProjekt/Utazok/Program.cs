using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utazok
{
    class Program
    {
        static void Main(string[] args)
        {
            Utazok utazok = new Utazok("utazobe.txt");
            string[] eredmeny = utazok.HolTalalkoznak();

            //További tesztek:
            //Utazok utazok1 = new Utazok("utazobe1.txt");
            //string[] eredmeny = utazok1.HolTalalkoznak();

            //Utazok utazok2 = new Utazok("utazobe2.txt");
            //string[] eredmeny = utazok2.HolTalalkoznak();

            //Utazok utazok3 = new Utazok("utazobe3.txt");
            //string[] eredmeny = utazok3.HolTalalkoznak();

            File.WriteAllLines("utazoki.txt", eredmeny, Encoding.Default);
            ;
        }
    }
}
