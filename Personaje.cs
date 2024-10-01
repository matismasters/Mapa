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
        public List<Recurso> Mochila { get; set; }
        public Personaje(int X, int Y) {
            this.IdPersonaje = Personaje.NuevoId();
            this.Punto = new Punto(X, Y);
            this.Mochila = new List<Recurso>();
        }

        private static int NuevoId()
        {
            Personaje.UltimoId += 1;
            return Personaje.UltimoId;
        }

        public bool AgregarRecursoEnMochila(Recurso recurso)
        {
            this.Mochila.Add(recurso);
            return true;
        }

        public bool PuedeFlotar()
        {
            return this.CantidadRecurso("Madera") >= 5;
        }

        public bool PuedeTrepar()
        {
            return this.CantidadRecurso("Cuerda") >= 3;
        }

        public int CantidadRecurso(string tipo)
        {
            int cantidad = 0;
            foreach (Recurso recurso in this.Mochila)
            {
                if (recurso.Tipo == tipo)
                {
                    cantidad += 1;
                }
            }

            return cantidad;
        }
    }
}
