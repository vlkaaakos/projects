using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACWEXB_Feleves
{
    class NincsIlyenElemException : Exception
    {

    }
    class Idopont<T> where T : IIdotartam
    {
        public T Tartalom { get; set; }
        public Idopont<T> Kovetkezo { get; set; }
    }

    class LancoltLista<T> where T : IIdotartam
    {
        public LancoltLista()
        {
            Figyelo += this.Ujraszamolo;
        }
        bool OptimalisEgy { get; set; }
        bool OptimalisKetto { get; set; }
        bool OptimalisHarom { get; set; }
        bool OptimalisNegy { get; set; }
        bool OptimalisOt { get; set; }

        bool FontosEgy { get; set; }
        bool FontosKetto { get; set; }
        bool FontosHarom { get; set; }
        bool FontosNegy { get; set; }
        bool FontosOt { get; set; }

        public delegate void ModositasFigyelo();
        public event ModositasFigyelo Figyelo;
        private void Ujraszamolo()
        {
            FontosKiiro(this.FontosEgy, this.FontosKetto, this.FontosHarom, this.FontosNegy, this.FontosOt);
            OptimalisBeosztas(this.OptimalisEgy, this.OptimalisKetto, this.OptimalisHarom, this.OptimalisNegy, this.OptimalisOt);
        }

        private Idopont<T> fej;

        public void Beszuras(T Tartalom)
        {
            Idopont<T> uj = new Idopont<T> { Tartalom = Tartalom };

            if (fej == null)
            {
                uj.Kovetkezo = fej;
                fej = uj;
            }
            else
            {
                Idopont<T> bal = null;
                Idopont<T> jobb = fej;

                while (jobb != null && uj.Tartalom.Fontossag >= jobb.Tartalom.Fontossag)
                {
                    bal = jobb;
                    jobb = jobb.Kovetkezo;
                }

                if (bal == null)
                {
                    uj.Kovetkezo = fej;
                    fej = uj;
                }
                else if(jobb == null || uj.Tartalom.Fontossag < jobb.Tartalom.Fontossag)
                {
                    uj.Kovetkezo = jobb;
                    bal.Kovetkezo = uj;
                }
            }
        }
        public void FontossagiTorles(Fontos fontossag)
        {
            Idopont<T> e = null;
            Idopont<T> p = fej;
            int torolt = 0;

            while (p != null)
            {
                if (p.Tartalom.Fontossag == fontossag)
                {
                    if (e == null)
                    {
                        fej = fej.Kovetkezo;
                        p = fej;
                    }
                    else if(p.Kovetkezo == null)
                    {
                        e.Kovetkezo = null;
                        p = null;
                    }
                    else
                    {
                        e.Kovetkezo = p.Kovetkezo;
                        p = p.Kovetkezo;
                    }
                    torolt++;
                }
                else
                {
                    e = p;
                    p = p.Kovetkezo;
                }
            }

            if (torolt > 0)
            {
                Console.WriteLine($"A törlés sikeres. A(z) {fontossag} fontosságú törölt elemek száma: {torolt}");
            }
            else
            {
                throw new NincsIlyenElemException();
            }
        }
        public void IdopontHatarTorles(int kezdete, int vege)
        {
            Idopont<T> e = null;
            Idopont<T> p = fej;
            int torolt = 0;

            while (p != null)
            {
                if (p.Tartalom.Kezdete > kezdete && p.Tartalom.Vege < vege || 
                    p.Tartalom.Vege > kezdete && p.Tartalom.Kezdete < vege ||
                    p.Tartalom.Kezdete < kezdete && p.Tartalom.Vege > vege)
                {
                    if (e == null)
                    {
                        fej = fej.Kovetkezo;
                        p = fej;
                    }
                    else if(p.Kovetkezo == null)
                    {
                        e.Kovetkezo = null;
                        p = null;
                    }
                    else
                    {
                        e.Kovetkezo = p.Kovetkezo;
                        p = p.Kovetkezo;
                    }
                    torolt++;
                }
                else
                {
                    e = p;
                    p = p.Kovetkezo;
                }
            }

            if (torolt > 0)
            {
                Console.WriteLine($"\nA törlés sikeres. A {kezdete} perc és {vege} perc között törölt elemek száma: {torolt}");
            }
            else
            {
                throw new NincsIlyenElemException();
            }
        }
        public void FontosKiiro(bool egy, bool ketto, bool harom, bool negy, bool ot)
        {
            List<Idopont<T>> kiirando = FontosLevalogatas(egy,ketto,harom,negy,ot);
            Console.WriteLine("");
            for (int i = 0; i < kiirando.Count; i++)
            {
                Console.WriteLine($"A program fontossága: {kiirando[i].Tartalom.Fontossag}, " +
                    $"megfelelő időpont: {kiirando[i].Tartalom.Kezdete} perctől {kiirando[i].Tartalom.Vege} percig.");
            }
        }
        public List<Idopont<T>> FontosLevalogatas(bool egy, bool ketto, bool harom, bool negy, bool ot)
        {
            this.FontosEgy = egy;
            this.FontosKetto = ketto;
            this.FontosHarom = harom;
            this.FontosNegy = negy;
            this.FontosOt = ot;

            List<Idopont<T>> idopontok = new List<Idopont<T>>();

            if (egy == true)
            {
                Idopont<T> e = null;
                Idopont<T> p = fej;
                bool talalat = false;

                while(p != null)
                {
                    if (p.Tartalom.Fontossag == Fontos.nagyon_alacsony)
                    {
                        talalat = true;
                        idopontok.Add(p);
                    }

                    e = p;
                    p = p.Kovetkezo;
                }
                
                if (talalat == false)
                {
                    throw new NincsIlyenElemException();
                }
            }
            if (ketto == true)
            {
                Idopont<T> e = null;
                Idopont<T> p = fej;
                bool talalat = false;

                while (p != null)
                {
                    if (p.Tartalom.Fontossag == Fontos.alacsony)
                    {
                        talalat = true;
                        idopontok.Add(p);
                    }

                    e = p;
                    p = p.Kovetkezo;
                }

                if (talalat == false)
                {
                    throw new NincsIlyenElemException();
                }
            }
            if (harom == true)
            {
                Idopont<T> e = null;
                Idopont<T> p = fej;
                bool talalat = false;

                while (p != null)
                {
                    if (p.Tartalom.Fontossag == Fontos.kozepes)
                    {
                        talalat = true;
                        idopontok.Add(p);
                    }

                    e = p;
                    p = p.Kovetkezo;
                }

                if (talalat == false)
                {
                    throw new NincsIlyenElemException();
                }
            }
            if (negy == true)
            {
                Idopont<T> e = null;
                Idopont<T> p = fej;
                bool talalat = false;

                while (p != null)
                {
                    if (p.Tartalom.Fontossag == Fontos.fontos)
                    {
                        talalat = true;
                        idopontok.Add(p);
                    }

                    e = p;
                    p = p.Kovetkezo;
                }

                if (talalat == false)
                {
                    throw new NincsIlyenElemException();
                }
            }
            if (ot == true)
            {
                Idopont<T> e = null;
                Idopont<T> p = fej;
                bool talalat = false;

                while (p != null)
                {
                    if (p.Tartalom.Fontossag == Fontos.nagyon_fontos)
                    {
                        talalat = true;
                        idopontok.Add(p);
                    }

                    e = p;
                    p = p.Kovetkezo;
                }

                if (talalat == false)
                {
                    throw new NincsIlyenElemException();
                }
            }

            return idopontok;
        }
        public void OptimalisBeosztas(bool egy, bool ketto, bool harom, bool negy, bool ot)
        {
            this.OptimalisEgy = egy;
            this.OptimalisKetto = ketto;
            this.OptimalisHarom = harom;
            this.OptimalisNegy = negy;
            this.OptimalisOt = ot;

            List<Idopont<T>> idopontok = FontosLevalogatas(egy, ketto, harom, negy, ot);
            List<Idopont<T>> eredmeny = Beosztas<T>.VisszalepesesKereses(idopontok);

            for(int i = 0; i < eredmeny.Count; i++)
            {
                Console.WriteLine($"\nA {i + 1}. program optimális időpontja: {eredmeny[i].Tartalom.Kezdete} " +
                                  $"perctől {eredmeny[i].Tartalom.Vege} percig.");
            }
        }
        public void FontosModosito(int kezdete, int vege, Fontos fontossag)
        {
            Idopont<T> e = null;
            Idopont<T> p = fej;

            while (p != null && p.Tartalom.Kezdete != kezdete && p.Tartalom.Vege != vege)
            {
                e = p;
                p = p.Kovetkezo;
            }
            if (p != null)
            {
                p.Tartalom.Fontossag = fontossag;
                Console.WriteLine($"\nA(z) {kezdete} perctől {vege} percig tartó program {fontossag} fontosságú lett!");
                Figyelo?.Invoke();
            }
            else
            {
                throw new NincsIlyenElemException();
            }
        }
    }
}
