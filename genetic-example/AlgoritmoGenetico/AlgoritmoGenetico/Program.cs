using System;
using System.Collections.Generic;

namespace AlgoritmoGenetico
{
    class Program
    {
        static void Main(string[] args)
        {
            Poblacion p;
            CreadorPoblacion creador = new CreadorPoblacion();
            PoblacionBuilder pE = new PoblacionEliteBuilder();
            PoblacionBuilder pR = new PoblacionRuedaRuletaBuilder();
            creador.SetPoblacionBuilder(pE);
            creador.CrearPoblacion();
            p = creador.GetPoblacion();
            p.Simulacion();
        }
    }

}