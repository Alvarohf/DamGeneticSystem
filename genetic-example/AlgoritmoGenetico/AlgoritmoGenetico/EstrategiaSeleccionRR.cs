using System;
using System.Collections.Generic;

class EstrategiaSeleccionRuedaRuleta : IEstrategiaSeleccion
{

    public void Seleccion(List<DNA> poblacion, List<DNA> seleccion)
    {
        double maxFit = 0;
        for (int i = 0; i < poblacion.Count; i++) { 
            if (poblacion[i].fitness > maxFit)
            {
                maxFit = poblacion[i].fitness;
            }
        }
        for (int i = 0; i < poblacion.Count; i++)
        {
            double n = Math.Round(poblacion[i].fitness / maxFit * 1000);
            for (int j = 0; j < n; j++)
            {
                seleccion.Add(poblacion[i]);
            }


        }

    }
}