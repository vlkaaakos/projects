using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACWEXB_Feleves
{
    class FurdoszobaTakaritas : Idotartam
    {
        public FurdoszobaTakaritas() :base(Fontos.kozepes, 15, 250)
        {
        }
    }
    class NappaliTakaritas : Idotartam
    {
        public NappaliTakaritas() :base(Fontos.fontos, 120, 410)
        {
        }
    }
    class KonyhaTakaritas : Idotartam
    {
        public KonyhaTakaritas() :base(Fontos.nagyon_fontos, 100, 350)
        {
        }
    }
    class HaloszobaTakaritas : Idotartam
    {
        public HaloszobaTakaritas() :base(Fontos.kozepes, 350, 613)
        {
        }
    }
    class Mosas : Idotartam
    {
        public Mosas() :base(Fontos.kozepes, 10, 240)
        {
        }
    }
    class RuhakTeregetese : Idotartam
    {
        public RuhakTeregetese() : base(Fontos.nagyon_alacsony, 320, 360)
        {
        }
    }
    class RuhakBeszedese : Idotartam
    {
        public RuhakBeszedese() :base(Fontos.alacsony, 365, 385)
        {
        }
    }
    class Tanulas : Idotartam
    {
        public Tanulas() : base(Fontos.nagyon_fontos, 100, 640)
        {
        }
    }
    class VideoJatekozas : Idotartam
    {
        public VideoJatekozas() :base(Fontos.alacsony, 1200, 1470)
        {
        }
    }
    class KonyvOlvasas : Idotartam
    {
        public KonyvOlvasas() :base(Fontos.kozepes, 740, 950)
        {
        }
    }
    class Meditalas : Idotartam
    {
        public Meditalas() : base(Fontos.alacsony, 900, 960)
        {
        }
    }
    class Bevasarlas : Idotartam
    {
        public Bevasarlas() :base(Fontos.fontos, 1100, 1300)
        {
        }
    }
    class Fozes : Idotartam
    {
        public Fozes() :base(Fontos.kozepes, 750, 900)
        {
        }
    }
    class Edzes : Idotartam
    {
        public Edzes() :base(Fontos.fontos, 540, 760)
        {
        }
    }
    class Pihenes : Idotartam
    {
        public Pihenes() :base(Fontos.nagyon_fontos, 1150, 1400)
        {
        }
    }
}
