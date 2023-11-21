using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utazok
{
    class Utazok
    {
        int n; //Meglátogatott városok száma első utazó
        int m; //Meglátogatott városok száma második utazó
        int adatokSzama = 0;
        public int N
        {
            get { return n; }
            set { n = value; }
        }
        public int M
        {
            get { return m; }
            set { m = value; }
        }

        Adatok[] adat;
        public Adatok[] Adat { get { return adat; } }
        Adatok[] adat1;
        public Adatok[] Adat1 { get { return adat1; } }
        Adatok[] adat2;
        public Adatok[] Adat2 { get { return adat2; } }
        public Utazok(string fajl)
        {
            string[] sorok = File.ReadAllLines(fajl);

            N = int.Parse(sorok[0]);
            adat1 = new Adatok[N];
            for (int i = 1; i <= N; i++)
            {
                Adatok adat1 = Adatok.Beolvas(sorok[i]);
                AdatokHozzaadasa(adat1, 1);
            }
            M = int.Parse(sorok[N + 1]);
            adat2 = new Adatok[M];
            adatokSzama = 0;
            for (int i = N + 2; i <= N + 1 + M; i++)
            {
                Adatok adat2 = Adatok.Beolvas(sorok[i]);
                AdatokHozzaadasa(adat2, 2);
            }
        }
        private int[] OsszNap(Adatok[] adat, int idx)
        {
            int db = 0;
            for (int i = adat[idx].Mettol; i <= adat[idx].Meddig; i++)
            {
                db++;
            }
            int[] napok = new int[db];
            napok[0] = adat[idx].Mettol;
            for (int i = 1; i < napok.Length; i++)
            {
                napok[i] = napok[i - 1] + 1;
            }
            return napok;
        }
        public int TalalkoznakE()
        {
            int db = 0;
            for (int i = 0; i < Adat1.Length; i++)
            {
                for (int j = 0; j < Adat2.Length; j++)
                {
                    if(Adat1[i].VarosNev == Adat2[j].VarosNev)
                    {
                        int[] elsonap = OsszNap(Adat1, i);
                        int[] masodiknap = OsszNap(Adat2, j);
                        if(Metszet(elsonap,masodiknap) == true)
                        {
                            db++;
                        }
                    }
                }
            }
            return db;
        }
        public string[] HolTalalkoznak()
        {
            string[] varosok = new string[TalalkoznakE() + 1];
            varosok[0] = TalalkoznakE().ToString();
            int idx = 1;
            for (int i = 0; i < Adat1.Length; i++)
            {
                for (int j = 0; j < Adat2.Length; j++)
                {
                    if (Adat1[i].VarosNev == Adat2[j].VarosNev)
                    {
                        int[] elsonap = OsszNap(Adat1, i);
                        int[] masodiknap = OsszNap(Adat2, j);
                        if (Metszet(elsonap, masodiknap) == true)
                        {
                            varosok[idx] = Adat1[i].VarosNev;
                            idx++;
                        }
                    }
                }
            }
            return varosok;
        }
        private bool Metszet(int[] egyik, int[] masik)
        {
            for (int i = 0; i < egyik.Length; i++)
            {
                for (int j = 0; j < masik.Length; j++)
                {
                    if(egyik[i] == masik[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void AdatokHozzaadasa(Adatok a, int szamossag)
        {
            if (szamossag == 1)
            {
                adat1[adatokSzama++] = a;
            }
            else if (szamossag == 2)
            {
                adat2[adatokSzama++] = a;
            }
        }
    }
}
