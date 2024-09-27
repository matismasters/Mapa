using Mapa;

Tablero tablero = new Tablero();
string? input = "";
while (input != "fin")
{
    tablero.MostrarTerrenoEnConsolaConColores();
    Console.WriteLine(tablero.Personaje.Punto.X + " " + tablero.Personaje.Punto.Y);
    Console.WriteLine("Recursos: " + tablero.Recursos.Count);
    Recurso? recurso = tablero.BuscarRecurso(tablero.Personaje.Punto.X, tablero.Personaje.Punto.Y);
    if (recurso != null)
    {
        Console.WriteLine("Recurso encontrado: " + recurso.Tipo);
    }
    Console.WriteLine("Mochila: " + tablero.Personaje.Mochila.Count);
    if (tablero.Personaje.PuedeFlotar())
    {
        Console.WriteLine("Puedes flotar!");
    }
    else
    {
        Console.WriteLine("No puedes flotar!");
    }
    Console.WriteLine("Escribe 'fin' para salir. O awsd para moverte. q para levantar recurso");
    input = Console.ReadLine();
    switch (input)
    {
        case "q":
            tablero.RecogerRecurso();
            break;
        case "w":
            tablero.MoverPersonaje(0, -1);
            break;
        case "a":
            tablero.MoverPersonaje(-1, 0);
            break;
        case "s":
            tablero.MoverPersonaje(0, 1);
            break;
        case "d":
            tablero.MoverPersonaje(1, 0);
            break;
    }
    Console.Clear();
}

// Ejercicio 1: Actualmente el personaje puede aparecer sobre una montaña!
//   Solucionarlo para que el personaje solo pueda aparecer en tierra.

// Ejercicio 2: Actualmente el personaje puede caminar sobre el agua y las montañas.
//   Solucionarlo para que si intenta moverse hacia agua o montaña, no se mueva.

// Ejercicio 3: Es hora de agregar recursos! 
//  Agregar una clase Recurso, Similar a Personaje, y agregar recursos al terreno.

// Ejercicio 4: Si el personaje se para sobre un recurso, debe poder recolectarlo.
//  Si el personaje se para sobre un recurso, este desaparece y el personaje obtiene el recurso.
//  Tendras que crear una propiedad mochila en Personaje para guardar los recursos.
//  Tendras que tener una propiedad Recursos en Tablero para guardar los recursos.

// Ejercicio 5: Agregar el recurso "Cuerda" al terreno.
//  Tendras que poder recogerlo y enviarlo a la mochila

// Ejercicio 6: Si tienes al menos 2 cuerdas en la mochila, puedes trepar.

// Ejercicio 7: Aumentar la cantidad de recursos en el mapa
// Ejercicio 8: Achicar la montaña
// Ejercicio 9: Hacer isla del tesoro.
//   La isla es una unica casilla de montaña en el medio del agua.
// Ejercicio 10: Agregar un recurso "Tesoro" en la isla.
//   Si el personaje se para sobre el tesoro, gana el juego.

