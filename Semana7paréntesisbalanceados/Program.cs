using System;
using System.Collections.Generic;

class VerificadorBalance
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Verificador de Paréntesis Balanceados ---");
        
        string expresionCorrecta = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
        string expresionIncorrecta = "{7 + (8 * 5) - [9 - 7)]}";

        // Prueba con la primera expresión
        Console.WriteLine($"\nAnalizando: {expresionCorrecta}");
        if (EstanSimbolosBalanceados(expresionCorrecta))
        {
            Console.WriteLine("Resultado: Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Resultado: Fórmula NO balanceada.");
        }

        // Prueba con la segunda expresión
        Console.WriteLine($"\nAnalizando: {expresionIncorrecta}");
        if (EstanSimbolosBalanceados(expresionIncorrecta))
        {
            Console.WriteLine("Resultado: Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Resultado: Fórmula NO balanceada.");
        }
    }

    public static bool EstanSimbolosBalanceados(string expresion)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char caracter in expresion)
        {
            if (caracter == '(' || caracter == '{' || caracter == '[')
            {
                pila.Push(caracter);
            }
            else if (caracter == ')' || caracter == '}' || caracter == ']')
            {
                if (pila.Count == 0)
                {
                    return false;
                }
                
                char ultimoSimbolo = pila.Pop();

                if ((caracter == ')' && ultimoSimbolo != '(') ||
                    (caracter == '}' && ultimoSimbolo != '{') ||
                    (caracter == ']' && ultimoSimbolo != '['))
                {
                    return false;
                }
            }
        }
        
        return pila.Count == 0;
    }
} 