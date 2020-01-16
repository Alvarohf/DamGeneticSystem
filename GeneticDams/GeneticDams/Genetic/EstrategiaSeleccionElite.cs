using System.Collections.Generic;
namespace GeneticLibrary
{
    public class EstrategiaSeleccionElite : IEstrategiaSeleccion
    {

        /// <summary>
        ///Para crear la matriz de reproduccion:
        ///Ordenamos los indivuos mediante su fitness
        ///Tomamos la mitad de la poblacion como matriz de reproduccion
        ///implementa el patron strategy
        /// </summary>
        /// <param name="poblacion"></param>
        /// <param name="seleccion"></param>
        /// <param name="max"></param>
        public void Seleccion(List<DNA> poblacion, List<DNA> seleccion, bool max)
        {
            if (max)
            {
                poblacion.Sort(new DNAComparame());
                poblacion.Reverse();
                for (int i = 0; i < poblacion.Count / 2; i++)
                {
                    seleccion.Add(poblacion[i]);
                }
            }
            else
            {
                poblacion.Sort(new DNAComparame());
                for (int i = 0; i < poblacion.Count / 2; i++)
                {
                    seleccion.Add(poblacion[i]);
                }
            }

        }
    }

    public class DNAComparame : Comparer<DNA>
    {
        // Compares by Length, Height, and Width.
        public override int Compare(DNA x, DNA y)
        {
            return x.Getfitness().CompareTo(y.Getfitness());

        }

    }
}