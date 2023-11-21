namespace Utazok
{
    class Adatok
    {
        int mettol; //Első nap
        int meddig; //Utolsó nap
        string varosNev; //Meglátogatott város neve

        public Adatok(int mettol, int meddig, string varosNev)
        {
            this.mettol = mettol;
            this.meddig = meddig;
            this.varosNev = varosNev;
        }

        public int Mettol { get { return mettol; } }
        public int Meddig { get { return meddig; } }
        public string VarosNev { get { return varosNev; } }
        public static Adatok Beolvas(string adatok)
        { 
            int mettol = int.Parse(adatok.Split(' ')[0]);
            int meddig = int.Parse(adatok.Split(' ')[1]);
            string varosNev = adatok.Split(' ')[2];

            return new Adatok(mettol, meddig, varosNev);
        }
    }
}
