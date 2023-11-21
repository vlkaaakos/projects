using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACWEXB_Feleves
{
    class Beosztas<T> where T : IIdotartam
    {
        static List<Idopont<T>> OptimalisLista { get; set; }
        static int OptimalisListaErteke { get; set; }

        public static List<Idopont<T>> VisszalepesesKereses(List<Idopont<T>> idopontok)
        {
            bool[] elem = new bool[idopontok.Count];
            for(int i =0; i < elem.Length; i++)
            {
                elem[i] = false;
            }
            Beosztas<T>.VisszalepesesKeresesPrivat(0,idopontok,elem);
            return OptimalisLista;
        }
        private static void VisszalepesesKeresesPrivat(int szint, List<Idopont<T>> idopontok, bool[] elem)
        {
            if (szint == idopontok.Count)
            {
                OptimalisE(idopontok, elem);
            }
            else if (VanErtelmeTovabbMenni(idopontok, szint, elem))
            {
                if (AKovetkezoJo(idopontok,szint,elem))
                {
                    bool[] uj_elem = new bool[idopontok.Count];
                    Array.Copy(elem, uj_elem, idopontok.Count);
                    uj_elem[szint] = true;

                    VisszalepesesKeresesPrivat(szint + 1, idopontok, elem);
                    VisszalepesesKeresesPrivat(szint + 1, idopontok, uj_elem);
                }
                else
                {
                    VisszalepesesKeresesPrivat(szint + 1, idopontok, elem);
                }
            }
            else
            {
                OptimalisE(idopontok, elem);
            }
        }
        private static void OptimalisE(List<Idopont<T>> idopontok, bool[] elem)
        {
            if (OptimalisLista == null || OptimalisListaErteke < OptimalisErtekSzamitas(idopontok, elem))
            {
                OptimalisLista = ListaSzures(idopontok, elem);
                OptimalisListaErteke = OptimalisErtekSzamitas(idopontok, elem);
            }
        }
        private static int OptimalisErtekSzamitas(List<Idopont<T>> idopontok, bool[] elem)
        {
            int eredmeny = 0;
            for (int i = 0; i < elem.Length; i++)
            {
                if (elem[i])
                {
                    eredmeny += (int)idopontok[i].Tartalom.Fontossag;
                }
            }
            return eredmeny;
        }
        private static List<Idopont<T>> ListaSzures(List<Idopont<T>> idopontok, bool[] elem)
        {
            List<Idopont<T>> eredmenyLista = new List<Idopont<T>>();
            for(int i = 0; i < elem.Length; i++)
            {
                if (elem[i])
                {
                    eredmenyLista.Add(idopontok[i]);
                }
            }
            return eredmenyLista;
        }
        private static bool VanErtelmeTovabbMenni(List<Idopont<T>> idopontok, int index, bool[] elem)
        {
            bool eredmeny = false;
            while(!eredmeny && index < idopontok.Count)
            {
                eredmeny = AKovetkezoJo(idopontok, index, elem);

                index++;
            }
            return eredmeny;
        } 
        private static bool AKovetkezoJo(List<Idopont<T>> idopontok, int szint, bool[] elem)
        {
            if (szint == 0)
            {
                return true;
            }
            else
            {
                int index = 0;
                bool nincsAtfedes = true;

                while (index != szint + 1)
                {
                    if (elem[index] && idopontok[index].Tartalom.Atfedi(idopontok[szint].Tartalom))
                    {
                        nincsAtfedes = false;
                    }
                    index++;
                }
                return nincsAtfedes;
            }
        }
    }
}
