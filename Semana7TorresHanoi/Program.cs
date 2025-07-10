// William Zapata - UEA
// Ejercicio 2: Torres de Hanoi

using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Problema de las Torres de Hanoi ---");
        
        // Pedimos al usuario el número de discos
        Console.Write("Ingrese el número de discos: ");
        int numeroDeDiscos;
        
        // Validamos la entrada
        while (!int.TryParse(Console.ReadLine(), out numeroDeDiscos) || numeroDeDiscos <= 0)
        {
            Console.Write("Por favor, ingrese un número entero positivo: ");
        }

        // Las torres se representan con letras
        char torreOrigen = 'A';
        char torreAuxiliar = 'B';
        char torreDestino = 'C';

        Console.WriteLine($"\nMostrando los pasos para mover {numeroDeDiscos} discos de la torre {torreOrigen} a la {torreDestino}:");
        
        // Llamamos a la función recursiva que resuelve el problema
        ResolverHanoi(numeroDeDiscos, torreOrigen, torreDestino, torreAuxiliar);
    }

    public static void ResolverHanoi(int n, char origen, char destino, char auxiliar)
    {
        // Caso base: si solo hay un disco, moverlo directamente del origen al destino.
        if (n == 1)
        {
            Console.WriteLine($"Mover disco 1 de la torre {origen} a la torre {destino}");
            return;
        }

        // Paso 1 (Recursivo): Mover n-1 discos de la torre de origen a la torre auxiliar,
        // usando la de destino como apoyo. El concepto de apilar llamadas es clave aquí[cite: 85].
        ResolverHanoi(n - 1, origen, auxiliar, destino);

        // Paso 2: Mover el disco más grande (el que queda en el origen) a la torre de destino.
        Console.WriteLine($"Mover disco {n} de la torre {origen} a la torre {destino}");

        // Paso 3 (Recursivo): Mover los n-1 discos de la torre auxiliar a la torre de destino,
        // usando la de origen como apoyo.
        ResolverHanoi(n - 1, auxiliar, destino, origen);
    }
} 