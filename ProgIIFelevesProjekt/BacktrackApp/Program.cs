using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACWEXB_Feleves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LancoltLista<IIdotartam> Lista = new LancoltLista<IIdotartam>();

            FurdoszobaTakaritas furdoszobaTakaritas = new FurdoszobaTakaritas();
            NappaliTakaritas nappaliTakaritas = new NappaliTakaritas();
            KonyhaTakaritas konyhaTakaritas = new KonyhaTakaritas();
            HaloszobaTakaritas haloszobaTakaritas = new HaloszobaTakaritas();
            Mosas mosas = new Mosas();
            RuhakTeregetese ruhakTeregetese = new RuhakTeregetese();
            RuhakBeszedese ruhakBeszedese = new RuhakBeszedese();
            Tanulas tanulas = new Tanulas();
            VideoJatekozas videoJatekozas = new VideoJatekozas();
            KonyvOlvasas konyvOlvasas = new KonyvOlvasas();
            Meditalas meditalas = new Meditalas();
            Bevasarlas bevasarlas = new Bevasarlas();
            Fozes fozes = new Fozes();
            Edzes edzes = new Edzes();
            Pihenes pihenes = new Pihenes();

            Lista.Beszuras(furdoszobaTakaritas);
            Lista.Beszuras(nappaliTakaritas);
            Lista.Beszuras(konyhaTakaritas);
            Lista.Beszuras(haloszobaTakaritas);
            Lista.Beszuras(mosas);
            Lista.Beszuras(ruhakTeregetese);
            Lista.Beszuras(ruhakBeszedese);
            Lista.Beszuras(tanulas);
            Lista.Beszuras(videoJatekozas);
            Lista.Beszuras(konyvOlvasas);
            Lista.Beszuras(meditalas);
            Lista.Beszuras(bevasarlas);
            Lista.Beszuras(fozes);
            Lista.Beszuras(edzes);
            Lista.Beszuras(pihenes);
            ;

            Lista.FontossagiTorles(Fontos.alacsony);
            Lista.IdopontHatarTorles(400, 550);
            Lista.FontosKiiro(true, false, true, true, true);
            Lista.OptimalisBeosztas(true, false, true, true, true);
            Lista.FontosModosito(15, 250, Fontos.nagyon_fontos);
        }
    }
}
