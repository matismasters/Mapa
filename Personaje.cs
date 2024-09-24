using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa
{
    public class Personaje
    {
        private static int UltimoId {  get; set; }
        public int IdPersonaje { get; set; }
        public Punto Punto { get; set; }
        public Personaje(int X, int Y) {
            this.IdPersonaje = Personaje.NuevoId();
            this.Punto = new Punto(X, Y);
        }

        private static int NuevoId()
        {
            Personaje.UltimoId += 1;
            return Personaje.UltimoId;
        }
    }
}
