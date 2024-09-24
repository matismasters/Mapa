using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa
{
    public class Punto
    {
        private static int UltimoId;
        public int IdPunto { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Punto(int x, int y)
        {
            this.IdPunto = Punto.NuevoId();
            this.X = x;
            this.Y = y;
        }

        private static int NuevoId()
        {
            Punto.UltimoId += 1;
            return Punto.UltimoId;
        }
    }
}
