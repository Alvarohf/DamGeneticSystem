using System;
using System.Collections.Generic;
namespace GeneticLibrary
{
    public class EstrategiaSeleccionRuedaRuleta : IEstrategiaSeleccion
    {

        public void Seleccion(List<DNA> poblacion, List<DNA> seleccion, bool max)
        {
            if (max)
            {
                double maxFit = 0;
                for (int i = 0; i < poblacion.Count; i++)
                {
                    if (poblacion[i].Getfitness() > maxFit)
                    {
                        maxFit = poblacion[i].Getfitness();
                    }
                }
                for (int i = 0; i < poblacion.Count; i++)
                {
                    double n = Math.Round(poblacion[i].Getfitness() / maxFit * 10000);
                    for (int j = 0; j < n; j++)
                    {
                        seleccion.Add(poblacion[i]);
                    }


                }
            }
            else
            {
                double maxFit = 0;
                for (int i = 0; i < poblacion.Count; i++)
                {
                    if (poblacion[i].Getfitness() > maxFit)
                    {
                        maxFit = poblacion[i].Getfitness();
                    }
                }
                for (int i = 0; i < poblacion.Count; i++)
                {
                    double n = Math.Round(maxFit / (poblacion[i].Getfitness() + 1) * 100);
                    for (int j = 0; j < n; j++)
                    {
                        seleccion.Add(poblacion[i]);
                    }
                }
            }

        }
    }
}
