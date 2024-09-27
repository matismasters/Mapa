using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa
{
    public class Recurso
    {
        private static int UltimoId { get; set; }
        public int IdRecurso { get; set; }
        public Punto Punto { get; set; }
        public string Tipo { get; set; }
        public Recurso(int X, int Y, string tipo)
        {
            this.IdRecurso = Recurso.NuevoId();
            this.Punto = new Punto(X, Y);
            this.Tipo = tipo;
        }

        private static int NuevoId()
        {
            Recurso.UltimoId += 1;
            return Recurso.UltimoId;
        }
    }
}
