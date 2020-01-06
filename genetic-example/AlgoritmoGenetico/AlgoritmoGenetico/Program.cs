using System;
using System.Collections.Generic;

namespace AlgoritmoGenetico
{
    class Program
    {
        static void Main(string[] args)
        {
            IEstrategiaSeleccion est = new EstrategiaSeleccionElite();
            CalculadorFitnessLineal calc = new CalculadorFitnessLineal();
            Decorator cE = new CalculadorFitnessExponencial(calc);
            Poblacion p = new Poblacion(est, cE);
            p.Simulacion();
        }
    }

}