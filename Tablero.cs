using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa
{
    public class Tablero
    {
        public int[,] Terreno { get; set; }
        public List<Punto> Puntos { get; set; }

        public List<Personaje> Personajes { get; set; }

        public Tablero()
        {
            this.Puntos = new List<Punto>();
            this.Personajes = new List<Personaje>();
            this.GenerarTerreno();
            this.InstanciarPersonaje();
        }

        private void InstanciarPersonaje()
        {
            int[] spawnPoint = this.PosicionCaminable();
            Personaje personaje = new Personaje(
                spawnPoint[0],
                spawnPoint[1]
            );

            this.Personajes.Add( personaje );
        }

        private int[] PosicionCaminable()
        {
            int[] coordenadas = new int[2];
            int x = 0;
            int y = 0;

            while (this.Terreno[x, y] != 1)
            {
                y = new Random().Next(0, this.Terreno.GetLength(0));
                x = new Random().Next(0, this.Terreno.GetLength(1));
            }

            coordenadas[0] = x;
            coordenadas[1] = y;
            return coordenadas;
        }

        private void GenerarTerreno()
        {
            this.Terreno = new int[15, 15];
            this.CrearSuperficie(this.Terreno.GetLength(0) / 5, 1);
            this.CrearSuperficie(this.Terreno.GetLength(0) / 5, 1);
            this.CrearSuperficie(this.Terreno.GetLength(0) / 7, 2);

        }

        public void CrearSuperficie(int tamano, int tipoTerreno)
        {
            int randomX = new Random().Next(tamano, this.Terreno.GetLength(1) - tamano);
            int randomY = new Random().Next(tamano, this.Terreno.GetLength(0) - tamano);

            for (int y = randomY - tamano; y <= randomY + tamano; y++)
            {
                for (int x = randomX - tamano; x <= randomX + tamano; x++)
                {
                    this.Terreno[x, y] = tipoTerreno;
                }
            }
        }

        private string MostrarCasilla(int x, int y)
        {
            foreach(Personaje personaje in this.Personajes)
            {
                if (
                    personaje.Punto.X == x &&
                    personaje.Punto.Y == y
                )
                {
                    return "P\t";
                }
            }

            return this.Terreno[x, y] + "\t";
        }

        public void MostrarTerreno()
        {
            Console.WriteLine("Terreno:");
            for (int i = 0; i < this.Terreno.GetLength(0); i++) 
            {
                for (int j = 0; j < this.Terreno.GetLength(1); j++) 
                {
                    Console.Write(this.MostrarCasilla(i, j));
                }
                Console.WriteLine();
            }
        }
    }
}
