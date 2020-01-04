using System;
using System.Collections.Generic;

namespace AlgoritmoGenetico
{
    class Program
    {
        static void Main(string[] args)
        {
            DNA punto = new DNA();
            Console.WriteLine(punto.X);
            IEstrategiaSeleccion est = new EstrategiaSeleccionElite();
            Poblacion p = new Poblacion(est);
            p.Simulacion();
        }
    }

}