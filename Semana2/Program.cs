using System;

namespace FigurasGeometricas
{
    // Clase para un Círculo (encapsulación correcta)
    public class Circulo
    {
        private readonly double _radio; // Campo readonly para seguridad

        public Circulo(double radio)
        {
            _radio = radio > 0 ? radio : throw new ArgumentException("El radio debe ser positivo.");
        }

        // Método para calcular el área (precisión con Math.PI)
        public double CalcularArea() => Math.PI * Math.Pow(_radio, 2);

        // Método para calcular el perímetro
        public double CalcularPerimetro() => 2 * Math.PI * _radio;

        // Propiedad de solo lectura
        public double Radio => _radio;
    }

    // Clase para un Rectángulo (validación mejorada)
    public class Rectangulo
    {
        private readonly double _base;
        private readonly double _altura;

        public Rectangulo(double baseRect, double altura)
        {
            _base = baseRect > 0 ? baseRect : throw new ArgumentException("La base debe ser positiva.");
            _altura = altura > 0 ? altura : throw new ArgumentException("La altura debe ser positiva.");
        }

        public double CalcularArea() => _base * _altura;
        public double CalcularPerimetro() => 2 * (_base + _altura);

        // Propiedades autoimplementadas (C# 9+)
        public double Base => _base;
        public double Altura => _altura;
    }

    // Clase principal (ejemplo de uso)
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("--- CÍRCULO ---");
                var circulo = new Circulo(5.0);
                Console.WriteLine($"Radio: {circulo.Radio}");
                Console.WriteLine($"Área: {circulo.CalcularArea():F2}");      // 78.54
                Console.WriteLine($"Perímetro: {circulo.CalcularPerimetro():F2}\n"); // 31.42

                Console.WriteLine("--- RECTÁNGULO ---");
                var rectangulo = new Rectangulo(4.0, 6.0);
                Console.WriteLine($"Base: {rectangulo.Base}, Altura: {rectangulo.Altura}");
                Console.WriteLine($"Área: {rectangulo.CalcularArea():F2}");      // 24.00
                Console.WriteLine($"Perímetro: {rectangulo.CalcularPerimetro():F2}"); // 20.00
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}