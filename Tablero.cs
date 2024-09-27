using System.Runtime.CompilerServices;

namespace Mapa
{
    public class Tablero
    {
        public int[,] Terreno { get; set; }
        public List<Punto> Puntos { get; set; }
        public Personaje Personaje { get; set; }
        public List<Recurso> Recursos { get; set; }  
        public Tablero()
        {
            this.Puntos = new List<Punto>();
            this.Recursos = new List<Recurso>();
            this.GenerarTerreno();
            this.InstanciarPersonaje();
            this.GenerarRecursos();
        }

        private void GenerarRecursos()
        {
            int cantidadRecursos = new Random().Next(5, 10);
            for (int i = 0; i < cantidadRecursos; i++)
            {
                int[] spawnPoint = this.PosicionCaminable();
                Recurso recurso = new Recurso(
                    spawnPoint[0],
                    spawnPoint[1],
                    "Madera"
                );

                this.Recursos.Add(recurso);
            }
        }

        private void InstanciarPersonaje()
        {
            int[] spawnPoint = this.PosicionCaminable();
            Personaje personaje = new Personaje(
                spawnPoint[0],
                spawnPoint[1]
            );

            this.Personaje = personaje;
        }

        private int[] PosicionCaminable()
        {
            int[] coordenadas = new int[2];
            int x = 0;
            int y = 0;

            while (this.Terreno[y, x] != 1)
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
            this.Terreno = new int[25, 25];

            // Creo tierra
            this.CrearSuperficie(this.Terreno.GetLength(0) / 5, 1);
            this.CrearSuperficie(this.Terreno.GetLength(0) / 5, 1);

            // Creo montañas
            this.CrearSuperficie(this.Terreno.GetLength(0) / 4, 2);
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

        public void MoverPersonaje(int masX, int masY)
        {
            int nuevaX = this.Personaje.Punto.X + masX;
            int nuevaY = this.Personaje.Punto.Y + masY;

            if (this.AfueraDeTablero(nuevaX, nuevaY))
            {
                return;
            }
            if (this.EsPosicionCaminable(this.Personaje, nuevaX, nuevaY) == true)
            {
                this.Personaje.Punto.X = nuevaX;
                this.Personaje.Punto.Y = nuevaY;
            }

        }

        private bool EsPosicionCaminable(Personaje personaje, int x, int y)
        {
            if (this.AfueraDeTablero(x, y))
            {
                return false;
            }

            int terrenoCasilla = this.Terreno[y, x];
            return terrenoCasilla == 1 || 
                (terrenoCasilla == 0 && personaje.PuedeFlotar());
        }

        private bool AfueraDeTablero(int x, int y)
        {
            return x < 0 || x >= this.Terreno.GetLength(0) ||
                y < 0 || y >= this.Terreno.GetLength(1);
        }

        public Recurso? BuscarRecurso(int x, int y)
        {
            foreach (Recurso recurso in this.Recursos)
            {
                if (recurso.Punto.X == x && recurso.Punto.Y == y)
                {
                    return recurso;
                }
            }

            return null;
        }

        public bool RecogerRecurso()
        {
            Recurso? recurso = this.BuscarRecurso(this.Personaje.Punto.X, this.Personaje.Punto.Y);
            if (recurso != null)
            {
                this.Personaje.AgregarRecursoEnMochila(recurso);
                this.Recursos.Remove(recurso);
                return true;
            }

            return false;
        }

        public void MostrarTerrenoEnConsolaConColores()
        {
            for (int i = 0; i < this.Terreno.GetLength(0); i++)
            {
                for (int j = 0; j < this.Terreno.GetLength(1); j++)
                {
                    // Comprobar si hay un recurso en la casilla
                    Recurso? recurso = this.BuscarRecurso(j, i);
                    if (recurso != null)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow; // Amarillo para recursos
                    }

                    // Comprobar si hay un personaje en la casilla
                    bool personajePresente = false;
                    if (this.Personaje.Punto.X == j && this.Personaje.Punto.Y == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Red; // Rojo para personajes
                        personajePresente = true;
                    }

                    if (personajePresente == false && recurso == null)
                    {
                        // Colorear el terreno según el tipo
                        switch (this.Terreno[i, j])
                        {
                            case 0:
                                Console.BackgroundColor = ConsoleColor.Blue; // Azul para no caminables
                                break;
                            case 1:
                                Console.BackgroundColor = ConsoleColor.Green; // Verde para caminables
                                break;
                            case 2:
                                Console.BackgroundColor = ConsoleColor.DarkGray; // Gris oscuro para terreno especial
                                break;
                        }
                    }

                    Console.Write("  "); // Espacio para representar la casilla
                }
                Console.WriteLine();
                Console.ResetColor(); // Restablecer los colores por cada línea
            }
        }
    }
}
